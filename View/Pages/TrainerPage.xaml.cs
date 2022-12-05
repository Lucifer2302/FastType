using FastType_Koshevoi_Chernenkov.AppData;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace FastType_Koshevoi_Chernenkov.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для TrainerPage.xaml
    /// </summary>
    public partial class TrainerPage : Page
    {
        int temp = 0;
        DispatcherTimer timer = null;
        public TrainerPage()
        {
            InitializeComponent();

            //Фокус
            InputLineTb.Focus();

            //Таймер
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;              
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            temp++;
        }

        private void InputLineTb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            foreach (StackPanel sp in GridKeyboard.Children)
            {
                foreach (Button btn in sp.Children)
                {
                    if (btn.Name == e.Key.ToString())
                    {
                        btn.BorderThickness = new Thickness(5);
                    }
                    else
                    {

                    }
                }
            }

            //реализовать запрет на ввод стрелок
            if (e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right)
            {
                e.Handled = true;
            }

            //Движение каретки вперед на 1 символ при нажатии на пробел
            if (e.Key == Key.Space)
            {
                ++InputLineTb.CaretIndex;
            }
        }

        private void InputLineTb_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            foreach (StackPanel sp in GridKeyboard.Children)
            {
                foreach (Button btn in sp.Children)
                {
                    if (btn.Name == e.Key.ToString())
                    {
                        btn.BorderThickness = new Thickness(0);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void InputLineTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            try
            {
                //сравнение ввводимого текста
                if (e.Text == InputLineTb.Text.Substring(InputLineTb.CaretIndex, 1))
                {
                    timer.Start();
                    FakeInputLineTb.Text = InputLineTb.Text.Substring(0, ++InputLineTb.CaretIndex);
                }
            }
            catch
            {
                timer.Stop();
                NavigationService.Navigate(new TrainerResultPage(TypeQuality.CalculateSpeed(InputLineTb, temp)));
            }
            




        }
    }
}
