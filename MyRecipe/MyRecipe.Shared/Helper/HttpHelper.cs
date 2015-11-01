using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipe.Helper
{

    public class HttpHelper
    {
        public string postString = string.Empty;
        public static string result = string.Empty;

        //接下来创建类FileWatch。然后声明事件，注意事件的类型即为我们之前定义的委托。

        public delegate void FileWatchEventHander(object sender, CompleteEventArgs e);

        public event FileWatchEventHander FileWatchEvent;

        //现在创建方法OnFileChange()，当调用该方法时将触发事件：


        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        public void CreatePostHttpResponse(string url, IDictionary<string, string> parameters)
        {
            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";


            //发送POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                postString = buffer.ToString();
                request.BeginGetRequestStream(new AsyncCallback(RequestReadySocket), request);
            }
        }

        private void RequestReadySocket(IAsyncResult asyncResult)
        {
            WebRequest request = asyncResult.AsyncState as WebRequest;
            Stream requestStream = request.EndGetRequestStream(asyncResult);

            using (StreamWriter writer = new StreamWriter(requestStream))
            {
                writer.Write(postString);
                writer.Flush();
            }

            request.BeginGetResponse(new AsyncCallback(ResponseReadySocket), request);
        }

        private void ResponseReadySocket(IAsyncResult asyncResult)
        {
            try
            {
                WebRequest request = asyncResult.AsyncState as WebRequest;
                WebResponse response = request.EndGetResponse(asyncResult) as HttpWebResponse;
                result = GetResponseString(response);

                CompleteEventArgs args = new CompleteEventArgs(result);
                FileWatchEvent(this, args );

            }
            catch (Exception e)
            {
            }

        }



        /// <summary>
        /// 获取请求的数据
        /// </summary>
        public string GetResponseString(WebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();

            }
        }

    }
    public class CompleteEventArgs:EventArgs
    {
        //需要传递的变量
        private  string _node;
        
        public string Node{
            get { return _node; }
        }
        public CompleteEventArgs(string node)
        {
            this._node= node;
        }
    }
}