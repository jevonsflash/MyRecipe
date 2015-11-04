﻿using MyRecipe.Command;
using MyRecipe.Helper;
using MyRecipe.Model;
using MyRecipe.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyRecipe.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand GoSearchCommand { get; set; }


        private MapServer mapser = new MapServer();
        private CookServer cookser = new CookServer();

        private string keywords;

        public string Keywords
        {
            get { return keywords; }
            set
            {
                keywords = value;
                NotifyPropertyChanged("Keywords");

            }
        }


        private List<BaseMap> sectionCategory;

        public List<BaseMap> SectionCategory
        {
            get { return sectionCategory; }
            set
            {
                sectionCategory = value;
                NotifyPropertyChanged("SectionCategory");
            }
        }
        private List<CookShowItem> sectionPopular;

        public List<CookShowItem> SectionPopular
        {
            get { return sectionPopular; }
            set
            {
                sectionPopular = value;
                NotifyPropertyChanged("SectionPopular");
            }
        }
        private List<CookShowItem> sectionSearch;


        public List<CookShowItem> SectionSearch
        {
            get { return sectionSearch; }
            set
            {
                sectionSearch = value;
                NotifyPropertyChanged("SectionSearch");
            }
        }


        public MainPageViewModel()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            GetJSON(StaticURLHelper.CookList, dic, Ht_FileWatchEvent);
            GetSectionCategory();
            GoSearchCommand = new DelegateCommand();
            GoSearchCommand.ExecuteAction = new Action<object>(GoSearch);



        }

        public async Task GetSectionCategory()
        {
            SectionCategory = await mapser.ReadFilterMap("Cook");
        }

        private void GetJSON(string url, Dictionary<string, string> dic, HttpHelper.FileWatchEventHander de)
        {
            HttpHelper ht = new HttpHelper();
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += de;

        }

        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            SectionPopular = cookser.CookShowDeserializer(e.Node);
        }

        private void Ht_FileWatchEvent2(object sender, CompleteEventArgs e)
        {
            SectionSearch = cookser.CookListDeserializer(e.Node);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }


        private void GoSearch(object parameter)
        {
            string kw = Keywords;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("name", kw);
            GetJSON(StaticURLHelper.CookByName, dic, Ht_FileWatchEvent2);

        }
    }
}
