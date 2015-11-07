using MyRecipe.Command;
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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;

namespace MyRecipe.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public event EventHandler CanExecuteChanged;
        public DelegateCommand GoSearchCommand { get; set; }
        public DelegateCommand GoNavigationCommand { get; set; }

        private MapServer mapser = new MapServer();
        private CookServer cookser = new CookServer();

        private string keywords;

        public string Keywords
        {
            get { return keywords; }
            set
            {
                keywords = value;
                RaisePropertyChanged("Keywords");

            }
        }


        private List<BaseMap> sectionCategory;

        public List<BaseMap> SectionCategory
        {
            get { return sectionCategory; }
            set
            {
                sectionCategory = value;
                RaisePropertyChanged("SectionCategory");
            }
        }
        private List<CookShowItem> sectionPopular;

        public List<CookShowItem> SectionPopular
        {
            get { return sectionPopular; }
            set
            {
                sectionPopular = value;
                RaisePropertyChanged("SectionPopular");
            }
        }
        private List<CookShowItem> sectionSearch;


        public List<CookShowItem> SectionSearch
        {
            get { return sectionSearch; }
            set
            {
                sectionSearch = value;
                RaisePropertyChanged("SectionSearch");
            }
        }


        public MainPageViewModel()
        {
            DispatcherHelper.Initialize();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            GetJSON(StaticURLHelper.CookList, dic, Ht_FileWatchEvent);
            GetSectionCategory();
            GoSearch(null);
            GoSearchCommand = new DelegateCommand();
            GoSearchCommand.ExecuteAction = new Action<object>(GoSearch);
            GoNavigationCommand = new DelegateCommand();
            GoNavigationCommand.ExecuteAction = new Action<object>(GoNavigation);
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
            DispatcherHelper.CheckBeginInvokeOnUI(() => { SectionPopular = cookser.CookShowDeserializer(e.Node); });
        }

        private void Ht_FileWatchEvent2(object sender, CompleteEventArgs e)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => { SectionSearch = cookser.CookListDeserializer(e.Node); });
        }


        private void GoSearch(object parameter)
        {
            string kw = Keywords;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("name", kw);
            GetJSON(StaticURLHelper.CookByName, dic, Ht_FileWatchEvent2);

        }

        private void GoNavigation(object parameter)
        {
            int id = (parameter as CookShowItem).id;
            Type  t= typeof(DetailPage);
            Helper.NavigationHelper.NavigateTo(t, id);

        }
    }
}
