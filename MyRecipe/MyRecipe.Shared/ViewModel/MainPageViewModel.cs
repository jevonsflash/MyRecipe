using MyRecipe.Helper;
using MyRecipe.Model;
using MyRecipe.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyRecipe.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged ,ICommand
    {
        
        private MapServer mapser = new MapServer();
        private CookServer cookser = new CookServer();
        

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
        private List<CookShowItem> sectionLatest;


        public List<CookShowItem> SectionLatest
        {
            get { return sectionLatest; }
            set
            {
                sectionLatest = value;
                NotifyPropertyChanged("SectionLatest");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public MainPageViewModel()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            GetJSON(StaticURLHelper.CookList, dic);
            GetSectionCategory();

        }
        public async Task GetSectionCategory()
        {

            sectionCategory = await mapser.ReadFilterMap("cook");
        }

        private void GetJSON(string url, Dictionary<string, string> dic)
        {
            HttpHelper ht = new HttpHelper();
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += Ht_FileWatchEvent;
        }

        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            sectionPopular = cookser.CookShowDeserializer(e.Node);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
