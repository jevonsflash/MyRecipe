using MyRecipe.Model;
using MyRecipe.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MyRecipe
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainPageViewModel data = new MainPageViewModel();
            this.DataContext = data;

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = (sender as CookShowItem).id;
            Helper.NavigationHelpr.NavigateTo(typeof(DetailPage), id);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            int id = (e.ClickedItem as CookShowItem).id;
            Helper.NavigationHelpr.NavigateTo(typeof(DetailPage), id);

        }
    }
}
