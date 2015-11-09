using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
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

        public DetailPageViewModel()
        {
            Messenger.Default.Register<string>(this, StaticMsgToken.Navigation, InitData);
        } 

        private void InitData(string id)
        {
            string url = StaticURLHelper.CookShow;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            GetJSON(StaticURLHelper.CookShow, dic, Ht_FileWatchEvent);
        }

        private void GetJSON(string url, Dictionary<string, string> dic, HttpHelper.FileWatchEventHander de)
        {
            HttpHelper ht = new HttpHelper();
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += de;

        }
        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            CookItem = cookser.CookObjectDeserializer(e.Node);

            List<string> foodlist = new List<string>();
            string[] foodarr = CookItem.food.Split(',');
            foreach (var item in foodarr)
            {
                foodlist.Add(item);
            }
            Food = foodlist;
        }

    }
}
