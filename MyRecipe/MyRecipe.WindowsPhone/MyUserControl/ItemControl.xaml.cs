using MyRecipe.Model;
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

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上有介绍

namespace MyRecipe.MyUserControl
{
    public sealed partial class ItemControl : UserControl
    {
        public bool IsFlod { get; set; } = true;
        public ItemControl()
        {
            this.InitializeComponent();
            Loaded += ItemControl_Loaded;

        }

        private void ItemControl_Loaded(object sender, RoutedEventArgs e)
        {
            InitGrid();
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            IsFlod = !IsFlod;
            InitGrid();

        }

        private void InitGrid()
        {
            if (IsFlod)
            {
                this.GVCon.MaxHeight = 0;
            }
            else
            {
                this.GVCon.MaxHeight = double.MaxValue;
            }
        }

        private void GVCon_ItemClick(object sender, ItemClickEventArgs e)
        {
            int id = (e.ClickedItem as BaseMap).id;
            Helper.NavigationHelper.NavigateTo(typeof(DetailPage), id);
        }
    }
}
