using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyRecipe.MyUserControl
{
    public partial class MsgBoxControl : UserControl
    {
        public MsgBoxControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty MsgTextProperty
         = DependencyProperty.Register(
             "MsgText",
             typeof(string),
             typeof(MsgBoxControl),
             new PropertyMetadata("", OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as MsgBoxControl).TBMessage.Text = e.NewValue as string;
        }

        public string MsgText
        {
            get
            {
                return GetValue(MsgTextProperty) as string;
            }
            set
            {
                SetValue(MsgTextProperty, value);
            }
        }

    }

}
