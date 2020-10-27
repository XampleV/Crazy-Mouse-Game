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
using System.Windows.Shapes;

namespace Crazy_Mouse_Game
{
    /// <summary>
    /// Interaction logic for ball.xaml
    /// </summary>
    public partial class ball : Window
    {
        public ball()
        {
            InitializeComponent();
        }
        private void BallHit(object sender, RoutedEventArgs e)
        {
            int mode = 5;
            globals.values.userScore++;
            if (globals.values.userScore == mode)
            {
                this.Close();
                globals.values.stop = true;
                globals.values.dt.Stop();
                MessageBox.Show("Congrats you win!", "The End");

                if (globals.values.highestTimer >= globals.values.currentTime == true)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("You're now on top of the leaderboard! What's your name?",
                        "Wow!",
                        "",
                        -1, -1);
                    functions.scores.NewHighScore(input, globals.values.currentTime);

                }
                Environment.Exit(1);


            }


            globals.values.xMouseLocation += 2;
            globals.values.yMouseLocation += 2;

            mainBall.Height -= 10;
            mainBall.Width -= 10;


        }
    }
}
