using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Xml;
using System.Threading;

namespace SilverlightApplication1
{
    public class SlotMachine
    {
        private readonly WebClient _WebClient = new WebClient();
        const string baseword = "abcdefghijklmnopqrstuvwxyz가나다라마바사아자차카타파하1234567890";
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

        List<Image> _DownImgs = new List<Image>();
        public List<Image> GetRandomItemsAsync()
        {
            Random r = new Random();
            _DownImgs.Clear();
            while (true)
            {
                if (_WebClient.IsBusy == false)
                {
                    string a = baseword[r.Next(baseword.Length-1)].ToString();
                    string uri = "http://apis.daum.net/search/image?q=" + a+ "&apikey=61c0e0874ece982f7e0f34bbbe7b042d7db75f4f&result=3&pageno=" + r.Next(500);
                    _WebClient.DownloadStringAsync(new Uri(uri));
                }
                Thread.Sleep(500);
            }

            return _DownImgs;
        }
    }
}
