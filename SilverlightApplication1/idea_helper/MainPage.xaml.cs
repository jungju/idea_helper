using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        List<Image> imgs = new List<Image>();
        SlotMachine _SM = new SlotMachine();
        Image _move1 = new Image();
        Image _move2 = new Image();
        Image _move3 = new Image();
        public MainPage()
        {
            InitializeComponent();
            //wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = TimeSpan.FromSeconds(1);

            _move1.Source = new BitmapImage(new Uri("http://localhost:1384/imgs/ff.jpg"));
            _move2.Source = new BitmapImage(new Uri("http://localhost:1384/imgs/ff.jpg"));
            _move3.Source = new BitmapImage(new Uri("http://localhost:1384/imgs/ff.jpg"));

            imgs.Add(new Image()
            {
                Source = new BitmapImage(new Uri("http://localhost:1384/imgs/a.jpg")),
                Stretch = Stretch.Fill
            });

            imgs.Add(new Image()
            {
                Source = new BitmapImage(new Uri("http://localhost:1384/imgs/b.jpg")),
                Stretch = Stretch.Fill
            });

            imgs.Add(new Image()
            {
                Source = new BitmapImage(new Uri("http://localhost:1384/imgs/c.jpg")),
                Stretch = Stretch.Fill
            });

            imgs.Add(new Image()
            {
                Source = new BitmapImage(new Uri("http://localhost:1384/imgs/d.jpg")),
                Stretch = Stretch.Fill
            });

            imgs.Add(new Image()
            {
                Source = new BitmapImage(new Uri("http://localhost:1384/imgs/e.jpg")),
                Stretch = Stretch.Fill
            });

            imgs.Add(new Image()
            {
                Source = new BitmapImage(new Uri("http://localhost:1384/imgs/f.jpg")),
                Stretch = Stretch.Fill
            });

            imgs.Add(new Image()
            {
                Source = new BitmapImage(new Uri("http://localhost:1384/imgs/cs.jpg")),
                Stretch = Stretch.Fill
            });

            imgs.Add(new Image()
            {
                Source = new BitmapImage(new Uri("http://localhost:1384/imgs/fg.jpg")),
                Stretch = Stretch.Fill
            });
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //char[] dd = { ',' };
            //string[] ss = e.Result.Split(dd);

            //List<Image> magImges = new List<Image>();
            //foreach (string imgUrl in ss)
            //{
            //    if (imgUrl.Trim() != "")
            //    {
            //        Image img = new Image();
            //        img.Source = new BitmapImage(new Uri(imgUrl));
            //        magImges.Add(img);
            //    }
            //}
            //S1.Children.Add(magImges[0]);
            //S2.Children.Add(magImges[1]);
            //S3.Children.Add(magImges[2]);
            
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			btnHL.RepeatBehavior = RepeatBehavior.Forever;
            btnHL.AutoReverse = true;
        	btnHL.Begin();
        }

        WebClient wc = new WebClient();
        DispatcherTimer dt = new DispatcherTimer();
        private void BtnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            S1.Child = _move1;
            S2.Child = _move2;
            S3.Child = _move3;

            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        S1.Child = imgs[r.Next(0, imgs.Count - 1)];
                    }
                    else if (i == 1)
                    {
                        S2.Child = imgs[r.Next(0, imgs.Count - 1)];
                    }
                    else if (i == 2)
                    {
                        S3.Child = imgs[r.Next(0, imgs.Count - 1)];
                    }
                }
            }
            catch
            {
            }
            dt.Stop();
        }
    }
}
