using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace TestTask
{
    public class TranslateAPI
    {
        private const string key = "trnsl.1.1.20180820T201359Z.206166e00728c4ef.a8714d01ec570dd4d870cd24910324416cd70eaa";
        public string Translate(string source,string lang)
        {

            if (source.Length > 0)
            {
                WebRequest request = WebRequest.Create("https://translate.yandex.net/api/v1.5/tr.json/translate?"
                    + "key=" + key
                    + "&text=" + source
                    + "&lang=" + lang);
                WebResponse response = request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string feedback;
                    if ((feedback = sr.ReadLine()) != null)
                    {
                        TranslateItem item = JsonConvert.DeserializeObject<TranslateItem>(feedback);
                        string result = "";
                        foreach(string line in item.text)
                        {
                            result += line;
                        }
                        return result;
                    }
                }
                return source;
            }
            return "";
        }
        private class TranslateItem
        {
            public string code { get; set; }
            public string lang { get; set; }
            public string[] text { get; set; }
        }
    }
}
