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

namespace BallSpiel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _animationTimer = new DispatcherTimer();
        private bool gehtNachRechts = true;
        private bool gehtNachUnten = true;

        public MainWindow()
        {
            InitializeComponent();

            _animationTimer.Interval = TimeSpan.FromMilliseconds(5);
            _animationTimer.Tick += PositioniereBall;
        }

        private void PositioniereBall(object sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);
            var y = Canvas.GetTop(Ball);

            if (gehtNachRechts && gehtNachUnten)
            {
                Canvas.SetLeft(Ball, x + 3);
                Canvas.SetTop(Ball, y + 3);
            }
            else if (gehtNachRechts && !gehtNachUnten)
            {
                Canvas.SetLeft(Ball, x + 3);
                Canvas.SetTop(Ball, y - 3);
            }
            else if (!gehtNachRechts && !gehtNachUnten)
            {
                Canvas.SetLeft(Ball, x - 3);
                Canvas.SetTop(Ball, y - 3);
            }
            else if (!gehtNachRechts && gehtNachUnten)
            {
                Canvas.SetLeft(Ball, x - 3);
                Canvas.SetTop(Ball, y + 3);
            }

            if (x >= Spielplatz.ActualWidth - Ball.ActualWidth)
            {
                gehtNachRechts = false;
            }
            else if (y >= Spielplatz.ActualHeight - Ball.ActualHeight)
            {
                gehtNachUnten = false;
            }
            else if (x <= 0)
            {
                gehtNachRechts = true;
            }
            else if (y <= 0)
            {
                gehtNachUnten = true;
            }
            
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_animationTimer.IsEnabled)
            {
                _animationTimer.Stop();
            }
            else
            {
                _animationTimer.Start();
            }
        }
    }
}
