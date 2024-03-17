using System.Windows;
using MovieAppWpf.Interfaces;
using MovieAppWpf.Services;

namespace MovieAppWpf;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(INavigationService navigationService)
    {
        InitializeComponent();
        if (navigationService is NavigationService frameNavigationService) frameNavigationService.Initialize(MainFrame);
    }
}