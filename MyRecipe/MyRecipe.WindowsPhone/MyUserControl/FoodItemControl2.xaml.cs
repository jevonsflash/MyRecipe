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
    public sealed partial class FoodItemControl2 : UserControl
    {
        public FoodItemControl2()
        {
            this.InitializeComponent();
        }

        private void GVCon_ItemClick(object sender, ItemClickEventArgs e)
        {
            string name = e.ClickedItem as string;
            Helper.NavigationHelper.NavigateTo(typeof(FoodDetailPage), name);

        }
    }
}
