namespace app_for_fun
{
    using System;
    using System.Windows;
    using UserControl = System.Windows.Controls.UserControl;
    using MessageBox = System.Windows.MessageBox;
    using System.Windows.Threading;
    using System.Windows.Forms;
    /// <summary>
    /// Interaction logic for UIPage.xaml
    /// </summary>
    public partial class UIPage : UserControl
    {
        Timer timer = new Timer();
        private int sec;

        public UIPage()
        {
            InitializeComponent();
            timer.Enabled = false;
        }
        private void shutDownBtn_Click(object sender, RoutedEventArgs e)
        {

            shutDownBtn.IsEnabled = false;
            int seconds = 0;
            bool result = Int32.TryParse(secondText.Text, out seconds);
            if (result != true)
            {
                MessageBox.Show("Seconds must be proper value, between " + 0 + " and " + Int32.MaxValue + "!", "Wrong Value!", MessageBoxButton.OK, MessageBoxImage.Error);

                shutDownBtn.IsEnabled = true;
            }
            else
            {
                sec = seconds;
                if (seconds >= 0 && seconds <= Int32.MaxValue)
                {
                    ShutDownFile.ShutDown(seconds);
                }
                SecondsTimer(seconds);
            }
        }

        private void SecondsTimer(int seconds)
        {

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(sec);
            string answer = string.Format("{0:D2}:{1:D2}:{2:D2}",t.Hours,t.Minutes,t.Seconds);
            timerLbl.Content = answer;
            sec--;
        }

        private void dontShutDownBtn_Click(object sender, RoutedEventArgs e)
        {
            DontShutDownFile.DontShutDown();
            if (timer.Enabled == true)
            {
                timer.Stop();
                timer.Enabled = false;
            }
            shutDownBtn.IsEnabled = true;
        }
    }
}
