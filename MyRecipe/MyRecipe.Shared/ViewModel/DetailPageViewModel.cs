using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MyRecipe.Command;
using MyRecipe.Helper;
using MyRecipe.Model;
using MyRecipe.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyRecipe.ViewModel
{
    public class DetailPageViewModel : ViewModelBase
    {

        private CookServer cookser = new CookServer();
        public DelegateCommand GoBackCommand { get; set; }


        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        private CookShowItem cookItem;


        public CookShowItem CookItem
        {
            get { return cookItem; }
            set
            {
                cookItem = value;
                RaisePropertyChanged("CookItem");
            }
        }

        private List<string> food;

        public List<string> Food
        {
            get { return food; }
            set
            {
                food = value;
                RaisePropertyChanged("Food");

            }
        }

        private List<Uri> image;

        public List<Uri> Image
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged("Image");
            }
        }

        public DetailPageViewModel()
        {
            //注册消息
            Messenger.Default.Register<string>(this, StaticMsgToken.NavigationA, InitData);
            GoBackCommand = new DelegateCommand();
            GoBackCommand.ExecuteAction = new Action<object>(GoBack);

        }

        private void GoBack(object obj)
        {
            NavigationHelper.GoBack();
        }

        /// <summary>
        /// 初始化数据(收到消息触发)
        /// </summary>
        /// <param name="id"></param>
        private void InitData(string id)
        {
            string url = StaticURLHelper.CookShow;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            GetJSON(url, dic, Ht_FileWatchEvent);
        }
        /// <summary>
        /// 请求Json数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <param name="de"></param>
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
                CookItem = cookser.CookObjectDeserializer(e.Node);

                List<string> foodlist = new List<string>();
                List<Uri> imagelist = new List<Uri>();
                string[] foodarr = CookItem.food.Split(',');
                string[] imagearr = CookItem.images;
                foreach (var item in foodarr)
                {
                    foodlist.Add(item);
                }
                foreach (var item in imagearr)
                {
                    imagelist.Add(new Uri(item));

                }
                Food = foodlist;
                Image = imagelist;

            });
        }

    }
}
