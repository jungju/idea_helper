using System;
using System.Net;
using System.Collections.Generic;
using System.Xml;
using System.Threading;

namespace SilverlightApplication1
{
    public class SlotMachine
    {
        private readonly WebClient _WebClient = new WebClient();
        const string baseword = "abcdefghijklmnopqrstuvwxyz ";
        public SlotMachine()
        {
            _WebClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(_WebClient_DownloadStringCompleted);
        }

        void _WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            XmlReader xr = XmlReader.Create(e.Result);
            while (xr.Read())
            {
                if (xr.Name == "")
                {
                }
            }
        }

        public string GetRandomString()
        {
            Random r = new Random(DateTime.Now.Millisecond); ;
            string ret = baseword[r.Next(baseword.Length - 1)].ToString();
            ret += baseword[r.Next(baseword.Length - 1)].ToString();

            return ret;
        }

        List<string> _DownImgs = new List<string>();
        public List<string> GetRandomItems()
        {
            Random r = new Random();
            _DownImgs.Clear();
            while (_DownImgs.Count < 4)
            {

                try
                {
                    string a = baseword[r.Next(baseword.Length - 1)].ToString();
                    string uri = "http://apis.daum.net/search/image?q=thing%20" + GetRandomString() + "&apikey=61c0e0874ece982f7e0f34bbbe7b042d7db75f4f&result=2&pageno=" + r.Next(1, 50);
                    string res = _WebClient.DownloadString(uri);

                    XmlDocument xmd = new XmlDocument();
                    xmd.LoadXml(res);
                    XmlNodeList nl = xmd.SelectNodes("//url");
                    if (nl.Count > 0)
                    {
                        //if(nl.Item(0).ChildNodes[0].Value.LastIndexOf(".jpg") > 0)
                        _DownImgs.Add(nl.Item(0).ChildNodes[0].Value);
                    }
                }
                catch
                { }
            
            }

            return _DownImgs;
        }
    }
}
