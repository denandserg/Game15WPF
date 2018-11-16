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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game15 _game = new Game15();
        public MainWindow()
        {
            InitializeComponent();
            for (int n = 0, i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    int val = _game[i, j];
                    if (val != 0)
                    {
                        Button btn = GameGrid.Children[n++] as Button;
                        if (btn != null)
                        {
                            btn.Content = val;
                            btn.SetValue(Grid.RowProperty, i);
                            btn.SetValue(Grid.ColumnProperty, j);
                        }
                    }


                }
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            //int col=(int)btn.GetValue(Grid.ColumnProperty);
            //int row = (int)btn.GetValue(Grid.RowProperty);

            if (btn != null)
            {
                int val = (int)btn.Content;
                switch (_game.CheckAndGo(val))
                {
                    case MoveButton.ToUp:
                        ButtonToUp(btn);
                        break;
                    case MoveButton.ToDown:
                        ButtonToDown(btn);
                        break;
                    case MoveButton.ToLeft:
                        ButtonToLeft(btn);
                        break;
                    case MoveButton.ToRight:
                        ButtonToRight(btn);
                        break;


                }
            }

        }

        private void ButtonToUp(Button btn)
        {
            int row = (int)btn.GetValue(Grid.RowProperty);
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation();
            thicknessAnimation.From = new Thickness(0, 150, 0, 0);
            thicknessAnimation.To = new Thickness(0, 0, 0, 150);
            thicknessAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            btn.SetValue(Grid.RowSpanProperty, 2);
            btn.SetValue(Grid.RowProperty, row - 1);
            thicknessAnimation.FillBehavior = FillBehavior.Stop;
            thicknessAnimation.Completed += (o, ea) =>
            {
                btn.SetValue(Grid.RowSpanProperty, 1);
            };
            btn.BeginAnimation(MarginProperty, thicknessAnimation);
        }

        private void ButtonToDown(Button btn)
        {
            int row = (int)btn.GetValue(Grid.RowProperty);
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation();
            thicknessAnimation.From = new Thickness(0, 0, 0, 150);
            thicknessAnimation.To = new Thickness(0, 150, 0, 0);
            thicknessAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            btn.SetValue(Grid.RowSpanProperty, 2);
            thicknessAnimation.FillBehavior = FillBehavior.Stop;
            thicknessAnimation.Completed += (o, ea) =>
            {
                btn.SetValue(Grid.RowSpanProperty, 1);
                btn.SetValue(Grid.RowProperty, row + 1);
            };
            btn.BeginAnimation(MarginProperty, thicknessAnimation);
        }

        private void ButtonToLeft(Button btn)
        {
            int col = (int)btn.GetValue(Grid.ColumnProperty);
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation();
            thicknessAnimation.From = new Thickness(150,0,0,0);
            thicknessAnimation.To = new Thickness(0, 0, 150, 0);
            thicknessAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            btn.SetValue(Grid.ColumnSpanProperty, 2);
            btn.SetValue(Grid.ColumnProperty, col - 1);
            thicknessAnimation.FillBehavior = FillBehavior.Stop;
            thicknessAnimation.Completed += (o, ea) =>
            {
                btn.SetValue(Grid.ColumnSpanProperty, 1);

            };
            btn.BeginAnimation(MarginProperty, thicknessAnimation);
        }

        private void ButtonToRight(Button btn)
        {
            int col = (int)btn.GetValue(Grid.ColumnProperty);
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation();
            thicknessAnimation.From = new Thickness(0, 0, 150, 0);
            thicknessAnimation.To = new Thickness(150, 0, 0, 0);
            thicknessAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            btn.SetValue(Grid.ColumnSpanProperty, 2);
            thicknessAnimation.FillBehavior = FillBehavior.Stop;
            thicknessAnimation.Completed += (o, ea) =>
            {
                btn.SetValue(Grid.ColumnSpanProperty, 1);
                btn.SetValue(Grid.ColumnProperty, col + 1);
            };
            btn.BeginAnimation(MarginProperty, thicknessAnimation);
        }
    }
}
