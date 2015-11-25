using GalaSoft.MvvmLight.Messaging;
using MyRecipe.Helper;
using MyRecipe.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介绍

namespace MyRecipe
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class FoodDetailPage : Page
    {
        public FoodDetailPage()
        {
            this.InitializeComponent();
            this.DataContext = new FoodDetailPageViewModel();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var t = e.Parameter.ToString();
            Messenger.Default.Send<string>(t, StaticMsgToken.NavigationB);
            StatusBar sb = StatusBar.GetForCurrentView();
            sb.HideAsync();

        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            StatusBar sb = StatusBar.GetForCurrentView();
            sb.ShowAsync();

            base.OnNavigatedFrom(e);
        }

        private void BTNBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WV_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (args.NewValue != null)
            {
                string content = args.NewValue as string;
                this.WV.NavigateToString(content);
            }

        }
    }
}
