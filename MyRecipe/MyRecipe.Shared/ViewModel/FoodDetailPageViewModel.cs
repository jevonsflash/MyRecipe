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
using Windows.UI.Xaml;

namespace MyRecipe.ViewModel
{
    public class FoodDetailPageViewModel : ViewModelBase
    {
        public DelegateCommand GoBackCommand { get; set; }

        private FoodServer foodser = new FoodServer();

        private FoodShowItem foodItem;


        public FoodShowItem FoodItem
        {
            get { return foodItem; }
            set
            {
                foodItem = value;
                RaisePropertyChanged("FoodItem");
            }
        }

        private string webViewData;

        public string WebViewData
        {
            get { return webViewData; }
            set
            {
                webViewData = value;
                RaisePropertyChanged("WebViewData");
            }
        }

        private Visibility isMsgVisible;

        public Visibility IsMsgVisible
        {
            get { return isMsgVisible; }
            set
            {
                isMsgVisible = value;
                RaisePropertyChanged("IsMsgVisible");
            }
        }

        public FoodDetailPageViewModel()
        {
            Messenger.Default.Register<string>(this, StaticMsgToken.NavigationB, InitData);
            GoBackCommand = new DelegateCommand();
            GoBackCommand.ExecuteAction = new Action<object>(GoBack);
            IsMsgVisible = Visibility.Collapsed;

        }
        private void GoBack(object obj)
        {
            NavigationHelper.GoBack();
        }

        private void InitData(string name)
        {
            string url = StaticURLHelper.FoodByName;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("name", name);
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
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                FoodItem = foodser.FoodObjectDeserializer(e.Node);
                if (FoodItem != null)
                {
                    WebViewData = FoodItem.summary + FoodItem.message;
                    IsMsgVisible = Visibility.Collapsed;
                }
                else
                {
                    IsMsgVisible = Visibility.Visible;
                }
            });
        }

    }
}
