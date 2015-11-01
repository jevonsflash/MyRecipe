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
        public ItemControl()
        {
            this.InitializeComponent();
        }

        private void BTNFlip_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.BTNFlip.IsChecked)
            {
                this.GVCon.MaxHeight = 0;
            }
            else
            {
                this.GVCon.MaxHeight = double.MaxValue;

            }

        }
    }
}
