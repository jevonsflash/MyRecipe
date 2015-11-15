using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MyRecipe.Command;
using MyRecipe.Helper;
using MyRecipe.Model;
using MyRecipe.Server;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace MyRecipe.ViewModel
{
    public class SubMainPageViewModel : ViewModelBase
    {
        private CookServer cookser = new CookServer();
        public DelegateCommand GoNavigationCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        private List<CookShowItem> currentCategoryItems;

        public List<CookShowItem> CurrentCategoryItems
        {
            get { return currentCategoryItems; }
            set
            {
                currentCategoryItems = value;
                RaisePropertyChanged("CurrentCategoryItems");
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        public SubMainPageViewModel()
        {
            Messenger.Default.Register<BaseMap>(this, StaticMsgToken.NavigationA, InitData);
            GoNavigationCommand = new DelegateCommand();
            GoNavigationCommand.ExecuteAction = new Action<object>(GoNavigation);
            GoBackCommand = new DelegateCommand();
            GoBackCommand.ExecuteAction = new Action<object>(GoBack);

        }


        private void GoBack(object obj)
        {
            NavigationHelper.GoBack();
        }

        private void InitData(BaseMap param)
        {
            Title = param.name;
            string url = StaticURLHelper.CookList;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", param.id.ToString());
            GetJSON(url, dic, Ht_FileWatchEvent);
        }

        private void GetJSON(string url, Dictionary<string, string> dic, HttpHelper.FileWatchEventHander de)
        {
            HttpHelper ht = new HttpHelper();
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += de;

        }

        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => { CurrentCategoryItems = cookser.CookShowDeserializer(e.Node); });
        }
        private void GoNavigation(object parameter)
        {
            int id = ((parameter as ItemClickEventArgs).ClickedItem as CookShowItem).id;
            Type t = typeof(DetailPage);
            Helper.NavigationHelper.NavigateTo(t, id);

        }

    }
}
