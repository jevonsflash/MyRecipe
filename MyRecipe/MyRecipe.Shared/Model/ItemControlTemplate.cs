using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipe.Model
{
    public class CategoryItem
    {
        public string Title { get; set; }
        public List<SubCategoryItem> Items { get; set; }

    }
    public class SubCategoryItem
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
    }

}
