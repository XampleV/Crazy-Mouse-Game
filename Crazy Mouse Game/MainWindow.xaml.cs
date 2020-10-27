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
using System.Threading;
using System.Windows.Threading;
namespace Crazy_Mouse_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int increment = 0;
        
        public MainWindow()
        {
            functions.scores.MainStart();
            
            InitializeComponent();
            bestPlayer.Text = globals.values.highestScoreUsername;
            highestScore.Text = Convert.ToString(globals.values.highestTimer);

            
        }
        private void Window_Loaded()
        {
            DispatcherTimer dt = new DispatcherTimer();
            globals.values.dt = dt;
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
            
        }
      
        private void dtTicker (object sender, EventArgs e)
        {
            increment++;
            globals.values.currentTime = increment;
            timerBox.Text = increment.ToString();
            
        }
        private void UpdateUserScores()
        {
            while (true)
            {
                // I don't understand why I need a dispatcher to change label.
                Thread.Sleep(10);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    userScoreLabel.Text = globals.values.userScore.ToString();

                }));
            }
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {
            startButtonD.Visibility = Visibility.Hidden;
            Thread.Sleep(1000);
            Window_Loaded();
            Thread updateScore = new Thread(new ThreadStart(UpdateUserScores));
            updateScore.Start();
            ball ball = new ball();
            ball.Show();
            functions.crazy_mouse_f.CrazyMouse.CrazyFunctionCall();
        }

    }
}
