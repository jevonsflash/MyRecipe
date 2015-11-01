using MyRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipe.Helper
{
    public static class StaticURLHelper
    {
        public static string DiseaseShow = "http://www.tngou.net/api/disease/show";
        public static string DiseaseShowByPlace = "http://www.tngou.net/api/disease/place";
        public static string DiseaseShowByDepartment = "http://www.tngou.net/api/disease/department";
        public static string DiseaseList = "http://www.tngou.net/api/disease/list";

        public static string SymptomShow = "http://www.tngou.net/api/symptom/show";
        public static string SymptomShowByPlace = "http://www.tngou.net/api/symptom/place";
        public static string SymptomShowByDepartment = "http://www.tngou.net/api/symptom/department";
        public static string SymptomList = "http://www.tngou.net/api/symptom/list";

        public static string CheckShow = "http://www.tngou.net/api/check/show";
        public static string CheckShowByPlace = "http://www.tngou.net/api/check/place";
        public static string CheckShowByDepartment = "http://www.tngou.net/api/check/department";
        public static string CheckShowClassify = "http://www.tngou.net/api/check/list";
        public static string CheckList = "http://www.tngou.net/api/check/list";

        public static string OperationShow = "http://www.tngou.net/api/operation/show";
        public static string OperationShowByPlace = "http://www.tngou.net/api/operation/place";
        public static string OperationShowByDepartment = "http://www.tngou.net/api/operation/department";
        public static string OperationList = "http://www.tngou.net/api/operation/list";

        public static string DrugShow = "http://www.tngou.net/api/drug/show";
        public static string DrugShowBySearch = "http://www.tngou.net/api/search";
        public static string DrugShowByNumber = "http://www.tngou.net/api/drug/number";
        public static string DrugShowByCode = "http://www.tngou.net/api/drug/code";
        public static string DrugList = "http://www.tngou.net/api/drug/list";
        public static string DrugShowClassify = "http://www.tngou.net/api/drug/classify";

        public static string LoreShow = "http://www.tngou.net/api/lore/show";
        public static string LoreList = "http://www.tngou.net/api/lore/list";
        public static string InfoShow = "http://www.tngou.net/api/info/show";
        public static string InfoList = "http://www.tngou.net/api/info/list";


        public static UrlResult GetURL(string typeName)

        {
            UrlResult oResult = new UrlResult();
            switch (typeName)
            {
                case "Symptom":
                    oResult.Show = StaticURLHelper.SymptomShow;
                    oResult.List = StaticURLHelper.SymptomList;
                    oResult.Filter1 = StaticURLHelper.SymptomShowByPlace;
                    oResult.Filter2 = StaticURLHelper.SymptomShowByDepartment;
                    break;
                case "Disease":
                    oResult.Show = StaticURLHelper.DiseaseShow;
                    oResult.List = StaticURLHelper.DiseaseList;
                    oResult.Filter1 = StaticURLHelper.DiseaseShowByPlace;
                    oResult.Filter2 = StaticURLHelper.DiseaseShowByDepartment;
                    break;
                case "Check":
                    oResult.Show = StaticURLHelper.CheckShow;
                    oResult.List = StaticURLHelper.CheckList;
                    oResult.Filter1 = StaticURLHelper.CheckShowByPlace;
                    oResult.Filter2 = StaticURLHelper.CheckShowByDepartment;
                    oResult.Filter3 = StaticURLHelper.CheckShowClassify;
                    break;
                case "Operation":
                    oResult.Show = StaticURLHelper.OperationShow;
                    oResult.List = StaticURLHelper.OperationList;
                    oResult.Filter1 = StaticURLHelper.OperationShowByPlace;
                    oResult.Filter2 = StaticURLHelper.OperationShowByDepartment;
                    break;

                case "Drug":
                    oResult.Show = StaticURLHelper.DrugShow;
                    oResult.List = StaticURLHelper.DrugShowBySearch;
                    oResult.Filter1 = StaticURLHelper.DrugShowClassify;
                    break;
                case "DrugNumber":
                    oResult.Show = StaticURLHelper.DrugShow;
                    oResult.List = StaticURLHelper.DrugShowByNumber;
                    oResult.Filter1 = StaticURLHelper.DrugShowClassify;
                    break;
                case "DrugCode":
                    oResult.Show = StaticURLHelper.DrugShow;
                    oResult.List = StaticURLHelper.DrugShowByCode;
                    oResult.Filter1 = StaticURLHelper.DrugShowClassify;

                    break;

                case "Info":
                    oResult.Show = StaticURLHelper.InfoShow;
                    break;
                case "Lore":
                    oResult.Show = StaticURLHelper.LoreShow;
                    break;

                default: break;

            }
            return oResult;
        }
    }
}
