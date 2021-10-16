using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //dirt - https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg
        //fl1 - https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5
        //fl2 - https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg
        //fl3 - https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg
        //gras - https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png
        //bug - http://www.origins.org.ua/pictures/butterfly_photo_2.jpg
        private int flowers = 0; //fl1 - 1, fl2 - 2, fl3 - 3
        private int tools = 0; //лейка - 1, серп - 2, сочок - 3
        private int score = 0;
        // 0 - грязь. 1 - трава1. 2 - трава2. 3 - трава3. 4 - цветочек1. 5 - цветочек2. 6 - цветочек3. 7 - зло
        private int[,] garden = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        Random rand = new Random();
        private int Timer5 = 0;
        private int lose = 0;
        public MainWindow()
        {
            InitializeComponent();
            //fl1.Source = new BitmapImage(new Uri("/Resources/dirt.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
            //BitmapImage bit = new BitmapImage(new Uri("/Resources/dirt.jpg", UriKind.Relative));
            //fl1.Source = bit;
            //fl1.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/wpfTry/Resources/grass.jpg"));
            //WORK! fl1.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            //C:\Users\leral\OneDrive\Рабочий стол\VSPBB\wpfTry\wpfTry\Resources\grass.jpg

        }

        private void Again_Click(object sender, RoutedEventArgs e)
        {
            Again();
        }

        private void Again()
        {
            flowers = 0;
            tools = 0;
            score = 0;
            fl1.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            fl2.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            fl3.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            fl4.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            fl5.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            fl6.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            fl7.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            fl8.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            fl9.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            Score.Text = "Счёт: " + score.ToString();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    garden[i, j] = 0;
            Timer5 = 0;
            lose = 0;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Score.Text = "Счёт: " + score.ToString();
            //Flower1. = Properties.Resources.flowers1;

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private async void timerTick(object sender, EventArgs e)
        {
            Timer5++;
            if (Timer5 % 5 == 0)
            {
                Bug();
                Lose();
            }
            if (Timer5 % 1 == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Trace.Write(garden[i, j].ToString(), " ");
                        //Console.Write(garden[i, j].ToString(), " ");
                    }
                    Trace.Write(Environment.NewLine);
                    //Console.WriteLine();
                }
                Trace.Write(Environment.NewLine);
            }
            await Task.Delay(0);
        }

        private void Lose()
        {
            lose = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (garden[i, j] == 7)
                        lose++;
            if (lose == 7)
            {
                MessageBox.Show("Вы проиграли)", "", MessageBoxButton.OK);
                Again();
            }
        }

        private void Flower1_Click(object sender, RoutedEventArgs e)
        {
            flowers = 1;
            tools = 0;
        }

        private void Flower2_Click(object sender, RoutedEventArgs e)
        {
            flowers = 2;
            tools = 0;
        }

        private void Flower3_Click(object sender, RoutedEventArgs e)
        {
            flowers = 3;
            tools = 0;
        }

        private void Tool1_Click(object sender, RoutedEventArgs e)
        {
            tools = 1;
            flowers = 4;
        }

        private void Tool2_Click(object sender, RoutedEventArgs e)
        {
            tools = 2;
            flowers = 4;
        }

        private void Tool3_Click(object sender, RoutedEventArgs e)
        {
            tools = 3;
            flowers = 4;
        }

        private void Bug()
        {
            //garden[rand.Next(0, 3), rand.Next(0, 3)] = 7;
            //
            //fl1.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
            int i = rand.Next(0, 3);
            int j = rand.Next(0, 3);
            if (garden[i, j] != 7)
            {
                garden[i, j] = 7;
                BugShow(i, j);
            }
            else
            {
                Bug();
            }
        }

        private void BugShow(int i, int j)
        {
            if (i == 0)
            {
                if (j == 0)
                {
                    fl1.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
                if (j == 1)
                {
                    fl2.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
                if (j == 2)
                {
                    fl3.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
            }
            if (i == 1)
            {
                if (j == 0)
                {
                    fl4.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
                if (j == 1)
                {
                    fl5.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
                if (j == 2)
                {
                    fl6.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
            }
            if (i == 1)
            {
                if (j == 0)
                {
                    fl7.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
                if (j == 1)
                {
                    fl8.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
                if (j == 2)
                {
                    fl9.Source = BitmapFrame.Create(new Uri(@"http://www.origins.org.ua/pictures/butterfly_photo_2.jpg"));
                }
            }
        }

        private void Pole(int x, int y)
        {
            switch (tools)
            {
                case 0:
                    if (garden[x, y] != 0)
                        MessageBox.Show("Инструмент не выбран", "", MessageBoxButton.OK);
                    break;
                case 1:
                    if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                    {
                        garden[x, y] += 3;
                        score += 50;
                    }
                    break;
                case 2:
                    if (garden[x, y] == 4 || garden[x, y] == 5 || garden[x, y] == 6)
                    {
                        garden[x, y] = 0;
                        score += 70;
                    }
                    break;
                case 3:
                    if (garden[x, y] == 7)
                    {
                        garden[x, y] = 0;
                        score += 100;
                    }
                    break;
                default:
                    MessageBox.Show("ERROR");
                    break;
            }
            switch (flowers)
            {
                case 0:
                    if (garden[x, y] == 0)
                        MessageBox.Show("Семена не выбраны", "", MessageBoxButton.OK);
                    break;
                case 1:
                    if (garden[x, y] == 0)
                        garden[x, y] = 1;
                    score += 10;
                    break;
                case 2:
                    if (garden[x, y] == 0)
                        garden[x, y] = 2;
                    score += 20;
                    break;
                case 3:
                    if (garden[x, y] == 0)
                        garden[x, y] = 3;
                    score += 30;
                    break;
                case 4:
                    break;
                default:
                    MessageBox.Show("ERROR");
                    break;
            }
            Score.Text = "Счёт: " + score.ToString();
        }

        private void Pole1_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            int y = 0;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl1.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl1.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl1.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl1.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl1.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

        private void Pole2_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            int y = 1;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl2.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl2.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl2.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl2.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl2.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

        private void Pole3_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            int y = 2;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl3.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl3.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl3.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl3.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl3.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

        private void Pole4_Click(object sender, RoutedEventArgs e)
        {
            int x = 1;
            int y = 0;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl4.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl4.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl4.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl4.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl4.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

        private void Pole5_Click(object sender, RoutedEventArgs e)
        {
            int x = 1;
            int y = 1;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl5.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl5.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl5.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl5.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl5.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

        private void Pole6_Click(object sender, RoutedEventArgs e)
        {
            int x = 1;
            int y = 2;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl6.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl6.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl6.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl6.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl6.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

        private void Pole7_Click(object sender, RoutedEventArgs e)
        {
            int x = 2;
            int y = 0;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl7.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl7.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl7.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl7.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl7.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

        private void Pole8_Click(object sender, RoutedEventArgs e)
        {
            int x = 2;
            int y = 1;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl8.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl8.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl8.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl8.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl8.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

        private void Pole9_Click(object sender, RoutedEventArgs e)
        {
            int x = 2;
            int y = 2;
            Pole(x, y);
            if (garden[x, y] == 0)
                fl9.Source = BitmapFrame.Create(new Uri(@"https://blog.firsttunnels.co.uk/wp-content/uploads/2018/05/soil.jpg"));
            if (garden[x, y] == 1 || garden[x, y] == 2 || garden[x, y] == 3)
                fl9.Source = BitmapFrame.Create(new Uri(@"https://sbbuildingsupplies.co.uk/wp-content/uploads/2016/09/birkdale-40mm-artifical-grass-1-300x202.png"));
            if (garden[x, y] == 4)
                fl9.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34385/FlowerBeds0012_1_600.jpg?v=5"));
            if (garden[x, y] == 5)
                fl9.Source = BitmapFrame.Create(new Uri(@"https://cdn.pixabay.com/photo/2012/07/09/13/19/blue-pillow-52186_640.jpg"));
            if (garden[x, y] == 6)
                fl9.Source = BitmapFrame.Create(new Uri(@"https://www.textures.com/system/gallery/photos/Nature/Flower%20Beds/34365/FlowerBeds0036_1_350.jpg"));
        }

    }
}
