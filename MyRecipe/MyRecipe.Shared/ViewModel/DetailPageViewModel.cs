using MyRecipe.Helper;
using MyRecipe.Model;
using MyRecipe.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyRecipe.ViewModel
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {

        private CookServer cookser = new CookServer();
        public event PropertyChangedEventHandler PropertyChanged;


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private CookShowItem cookItem;


        public CookShowItem CookItem
        {
            get { return cookItem; }
            set
            {
                cookItem = value;
                NotifyPropertyChanged("CookItem");
            }
        }


        public DetailPageViewModel()
        {
            string url = StaticURLHelper.CookShow;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", Id.ToString());
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
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
