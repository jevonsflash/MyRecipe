﻿

#pragma checksum "D:\Project\C#\test\MyRecipe\MyRecipe\MyRecipe.WindowsPhone\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "526F1EEDC728739A12E25BE0ACFF2219"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyRecipe
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 84 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ListView_ItemClick;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 74 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.TBMainSearch_Loaded;
                 #line default
                 #line hidden
                #line 75 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.TBMainSearch_Loaded;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 51 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ListView_ItemClick;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


