﻿using System.Windows;
using MovieApp.Messaging;
using MovieApp.Messaging.Services;
using MovieAppWpf.Interfaces;
using MovieAppWpf.Services;

namespace MovieAppWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(INavigationService navigationService)
    {
        InitializeComponent();
        if (navigationService is NavigationService frameNavigationService)
        {
            frameNavigationService.Initialize(MainFrame);
        }
    }
    
    // private void DrawShapesWithSeed(int seed)
    // {
    //     var rand = new Random(seed);
    //     for (int i = 0; i < 5; i++)
    //     {
    //         switch (rand.Next(3))
    //         {
    //             case 0:
    //                 DrawRectangle(rand);
    //                 break;
    //             case 1:
    //                 DrawEllipse(rand);
    //                 break;
    //             case 2:
    //                 DrawLine(rand);
    //                 break;
    //         }
    //     }
    // }
    //
    // private void DrawRectangle(Random rand)
    // {
    //     var rect = new Rectangle
    //     {
    //         Stroke = Brushes.Black,
    //         Fill = new SolidColorBrush(Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256))),
    //         Width = rand.Next(50, 150),
    //         Height = rand.Next(50, 150)
    //     };
    //     Canvas.SetLeft(rect, rand.Next(0, (int)MyCanvas.ActualWidth - (int)rect.Width));
    //     Canvas.SetTop(rect, rand.Next(0, (int)MyCanvas.ActualHeight - (int)rect.Height));
    //     MyCanvas.Children.Add(rect);
    // }
    //
    // private void DrawEllipse(Random rand)
    // {
    //     var ellipse = new Ellipse
    //     {
    //         Stroke = Brushes.Black,
    //         Fill = new SolidColorBrush(Color.FromRgb((byte)rand.Next(256), 
    //             (byte)rand.Next(256), 
    //             (byte)rand.Next(256))),
    //         Width = rand.Next(50, 150),
    //         Height = rand.Next(50, 150)
    //     };
    //     Canvas.SetLeft(ellipse, rand.Next(0, (int)MyCanvas.ActualWidth - (int)ellipse.Width));
    //     Canvas.SetTop(ellipse, rand.Next(0, (int)MyCanvas.ActualHeight - (int)ellipse.Height));
    //     MyCanvas.Children.Add(ellipse);
    // }
    //
    // private void DrawLine(Random rand)
    // {
    //     var line = new Line
    //     {
    //         Stroke = Brushes.Black,
    //         X1 = rand.Next((int)MyCanvas.ActualWidth),
    //         Y1 = rand.Next((int)MyCanvas.ActualHeight),
    //         X2 = rand.Next((int)MyCanvas.ActualWidth),
    //         Y2 = rand.Next((int)MyCanvas.ActualHeight),
    //         StrokeThickness = 2
    //     };
    //     MyCanvas.Children.Add(line);
    // }
}