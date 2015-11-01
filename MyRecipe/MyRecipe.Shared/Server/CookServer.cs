using MyRecipe.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipe.Server
{
    public class CookServer
    {
        public IList<Model.CookShowItem> CookShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.CookShowItem> cookShowItemModelList = new List<Model.CookShowItem>();

            Dictionary<string, string> result = new Dictionary<string, string>();
            JObject jobject = JObject.Parse(jsonStr);
            if (jobject.Property("total") != null)
            {
                total = int.Parse(jobject["total"].ToString());
            }
            string jsonArrayText1 = jobject["tngou"].ToString();
            JArray ja = (JArray)JsonConvert.DeserializeObject(jsonArrayText1);
            foreach (var item in ja)
            {
                cookShowItemModelList.Add(JTokenToModel(item));
            }
            return cookShowItemModelList;
        }
        public Model.CookShowItem CookObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private CookShowItem JTokenToModel(JToken item)
        {
            Model.CookShowItem oCookShowItem = new Model.CookShowItem();
            int count = int.Parse(item["count"].ToString());
            int rcount = int.Parse(item["rcount"].ToString());
            int fcount = int.Parse(item["fcount"].ToString());
            int id = int.Parse(item["id"].ToString());

            string name = item["name"].ToString() ?? "";
            string img = item["img"].ToString() ?? "";
            string images = item["images"].ToString() ?? "";
            string food = item["food"].ToString() ?? "";
            string description = item["description"].ToString() ?? "";
            string keywords = item["keywords"].ToString() ?? "";
            //string message = item["message"].ToString() ?? "";
            //string disease = item["disease"].ToString() ?? "";

            oCookShowItem.id = id;
            oCookShowItem.count = count;
            oCookShowItem.rcount = rcount;
            oCookShowItem.fcount = fcount;
            oCookShowItem.name = name;//名称
            oCookShowItem.img = img;//图片
            oCookShowItem.food = food;//食物
            oCookShowItem.img = img;//图片, 
            oCookShowItem.images = images;//图片, 
            oCookShowItem.description = description;//描述
            oCookShowItem.keywords = keywords;//关键字
            //oCookShowItem.message = message;//资讯内容

            return oCookShowItem;
        }

    }
}
