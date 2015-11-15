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
    public class FoodServer
    {
        public List<Model.FoodShowItem> FoodShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.FoodShowItem> foodShowItemModelList = new List<Model.FoodShowItem>();

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
                foodShowItemModelList.Add(JTokenToModel(item));
            }
            return foodShowItemModelList;
        }
        public Model.FoodShowItem FoodObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private FoodShowItem JTokenToModel(JToken item)
        {
            Model.FoodShowItem oFoodShowItem = new Model.FoodShowItem();
            int count = int.Parse(item["count"].ToString());
            int rcount = int.Parse(item["rcount"].ToString());
            int fcount = int.Parse(item["fcount"].ToString());
            int id = int.Parse(item["id"].ToString());

            string name = item["name"].ToString() ?? "";
            string img = item["img"].ToString() ?? "";
            string food = item["food"].ToString() ?? "";
            string description = item["description"].ToString() ?? "";
            string keywords = item["keywords"].ToString() ?? "";
            string summary = item["summary"].ToString() ?? "";
            string disease = item["disease"].ToString() ?? "";
            string message = string.Empty;
            if (item["message"] != null)
            {
                message = item["message"].ToString() ?? "";
            }

            oFoodShowItem.id = id;
            oFoodShowItem.count = count;
            oFoodShowItem.rcount = rcount;
            oFoodShowItem.fcount = fcount;
            oFoodShowItem.name = name;//名称
            oFoodShowItem.food = food;//食物
            oFoodShowItem.img = ImagesHandler(img)[0] + "_125";//图片, 
            oFoodShowItem.message = message;
            oFoodShowItem.description = description;//描述
            oFoodShowItem.keywords = keywords;//关键字
            oFoodShowItem.summary = summary;//资讯内容
            oFoodShowItem.disease = disease;

            return oFoodShowItem;
        }
        private string[] ImagesHandler(string src)
        {
            string[] temp = src.Split(',');

            if (string.IsNullOrEmpty(src))
            {
                return new string[] { "ms-appx:///Img/default.png" };
            }

            else
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = string.Format("http://tnfs.tngou.net/image{0}", temp[i]);
                }
            }
            return temp;
        }

    }
}
