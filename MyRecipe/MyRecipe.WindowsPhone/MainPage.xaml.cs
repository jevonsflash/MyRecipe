using MyRecipe.Model;
using MyRecipe.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
            this.DataContext = new MainPageViewModel();


        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //int id = (e.ClickedItem as CookShowItem).id;
            //Helper.NavigationHelper.NavigateTo(typeof(DetailPage), id);

        }

        private void TBMainSearch_Loaded(object sender, RoutedEventArgs e)
        {
            InitTextBlockStyle(sender, false);

        }

        private static void InitTextBlockStyle(object sender, bool isFoc)
        {
            Color whiteColor = Colors.White;
            SolidColorBrush whiteBrush = new SolidColorBrush(whiteColor);
            Color transparentColor = Colors.Transparent;
            SolidColorBrush transparentBrush = new SolidColorBrush(transparentColor);
            //SolidColorBrush PhoneBackgroundBrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
            (sender as Control).Background = transparentBrush;
            (sender as Control).Foreground = whiteBrush;

        }
    }
}
