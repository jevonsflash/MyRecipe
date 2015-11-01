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
            this.HubSection1.DataContext = new ContentTemplate();
        }
    }
    public class ContentTemplate
    {
        public ContentTemplate()
        {
            List<SubCategoryItem> list = new List<SubCategoryItem>();
            list.Add(new SubCategoryItem() { Title = "一个" });
            list.Add(new SubCategoryItem() { Title = "这是第" });
            list.Add(new SubCategoryItem() { Title = "这是第" });
            list.Add(new SubCategoryItem() { Title = "这是第4个" });
            list.Add(new SubCategoryItem() { Title = "这是第5个" });
            Content = new List<CategoryItem>();
            Content.Add(new CategoryItem() { Title = "hehe", Items = list });
            Content.Add(new CategoryItem() { Title = "hehe2", Items = list });
            Content.Add(new CategoryItem() { Title = "hehe3", Items = list });
        }
        public List<CategoryItem> Content { get; set; }
    }
}
