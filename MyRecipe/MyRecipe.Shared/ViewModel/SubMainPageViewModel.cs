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
    public class SubMainPageViewModel: ViewModelBase
    {
        private List<CookShowItem> currentCategoryItems;
        private CookServer cookser = new CookServer();
        public DelegateCommand GoNavigationCommand { get; set; }

        public List<CookShowItem> CurrentCategoryItems
        {
            get { return currentCategoryItems; }
            set
            {
                currentCategoryItems = value;
                RaisePropertyChanged("CurrentCategoryItems");
            }
        }

        public SubMainPageViewModel()
        {
            Messenger.Default.Register<string>(this, StaticMsgToken.NavigationA, InitData);
            GoNavigationCommand = new DelegateCommand();
            GoNavigationCommand.ExecuteAction = new Action<object>(GoNavigation);

        }

        private void InitData(string id)
        {
            string url = StaticURLHelper.CookList;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", id);
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
