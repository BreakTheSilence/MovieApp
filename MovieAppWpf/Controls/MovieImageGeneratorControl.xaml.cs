using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MovieAppWpf.Controls;

public partial class MovieImageGeneratorControl : UserControl
{
    public MovieImageGeneratorControl()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty SeedProperty = DependencyProperty.Register(
        nameof(Seed), typeof(int), typeof(MovieImageGeneratorControl), new PropertyMetadata(default(int), OnSeedPropertyChanged));

    private static void OnSeedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (MovieImageGeneratorControl)d;
        var seed = (int)e.NewValue;
        control.DrawShapesWithSeed(seed);
    }

    public int Seed
    {
        get => (int)GetValue(SeedProperty);
        set => SetValue(SeedProperty, value);
    }

    private void DrawShapesWithSeed(int seed)
    {
        var rand = new Random(seed);
        for (int i = 0; i < 5; i++)
        {
            switch (rand.Next(3))
            {
                case 0:
                    DrawRectangle(rand);
                    break;
                case 1:
                    DrawEllipse(rand);
                    break;
                case 2:
                    DrawLine(rand);
                    break;
            }
        }
    }

    private void DrawRectangle(Random rand)
    {
        var rect = new Rectangle
        {
            Stroke = Brushes.Black,
            Fill = new SolidColorBrush(Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256))),
            Width = rand.Next(50, 150),
            Height = rand.Next(50, 150)
        };
        Canvas.SetLeft(rect, rand.Next(0, (int)MovieCanvas.ActualWidth - (int)rect.Width));
        Canvas.SetTop(rect, rand.Next(0, (int)MovieCanvas.ActualHeight - (int)rect.Height));
        MovieCanvas.Children.Add(rect);
    }

    private void DrawEllipse(Random rand)
    {
        var ellipse = new Ellipse
        {
            Stroke = Brushes.Black,
            Fill = new SolidColorBrush(Color.FromRgb((byte)rand.Next(256),
                (byte)rand.Next(256),
                (byte)rand.Next(256))),
            Width = rand.Next(50, 150),
            Height = rand.Next(50, 150)
        };
        Canvas.SetLeft(ellipse, rand.Next(0, (int)MovieCanvas.ActualWidth - (int)ellipse.Width));
        Canvas.SetTop(ellipse, rand.Next(0, (int)MovieCanvas.ActualHeight - (int)ellipse.Height));
        MovieCanvas.Children.Add(ellipse);
    }

    private void DrawLine(Random rand)
    {
        var line = new Line
        {
            Stroke = Brushes.Black,
            X1 = rand.Next((int)MovieCanvas.ActualWidth),
            Y1 = rand.Next((int)MovieCanvas.ActualHeight),
            X2 = rand.Next((int)MovieCanvas.ActualWidth),
            Y2 = rand.Next((int)MovieCanvas.ActualHeight),
            StrokeThickness = 2
        };
        MovieCanvas.Children.Add(line);
    }
}