using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.DTO;
using Domain.Models;
using MovieApp.Messaging.Interfaces.Services;
using MovieAppWpf.Interfaces;

namespace MovieAppWpf.ViewModels;

public class MoviesViewModel : ObservableObject
{
    private readonly IMessagePublisher _messagePublisher;
    private readonly INavigationService _navigationService;

    private IEnumerable<MovieDto> _allMovies = ArraySegment<MovieDto>.Empty;
    private string _searchText = string.Empty;
    private List<Category> _selectedCategories;

    public MoviesViewModel(IMessagePublisher messagePublisher, INavigationService navigationService)
    {
        _messagePublisher = messagePublisher;
        _navigationService = navigationService;
        PageLoadedCommand = new AsyncRelayCommand(PageLoaded);
        CategoriesSelectionChangedCommand = new RelayCommand<object>(CategoriesSelectionChanged!);
        ClearFiltersCommand = new RelayCommand(ClearFilters);
    }
    
    public ObservableCollection<MovieControlViewModel> Movies { get; } = new();
    public ObservableCollection<Category> Categories { get; } = new();

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            Filter();
        }
    }

    public ICommand PageLoadedCommand { get; }
    public ICommand CategoriesSelectionChangedCommand { get; }
    public ICommand ClearFiltersCommand { get; }   

    private async Task PageLoaded()
    {
        await LoadMovies();
        SetupCategories();
    }

    private async Task LoadMovies()
    {
        _allMovies = await _messagePublisher.GetAllMoviesAsync();
        DisplayMovies(_allMovies);
    }

    private void SetupCategories()
    {
        Categories.Clear();
        var movies = _allMovies.ToList();
        var availableCategories = movies
            .GroupBy(m => m.Category.Name)
            .Select(g => g.First().Category)
            .ToList();

        availableCategories.ForEach(m => Categories.Add(m));
    }

    private void Filter()
    {
        var moviesToDisplay = _allMovies.ToList();
        if (_selectedCategories.Any())
        {
            moviesToDisplay = moviesToDisplay
                .Where(movie => _selectedCategories.Any(category => category.Id == movie.Category.Id))
                .ToList();
        }

        
        moviesToDisplay = moviesToDisplay.Where(m => m.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
        
        DisplayMovies(moviesToDisplay);
    }

    private void CategoriesSelectionChanged(object selectedCategories)
    {
        if (selectedCategories is not IList items) return;
        _selectedCategories = items.Cast<Category>().ToList();
        Filter();
    }

    private void DisplayMovies(IEnumerable<MovieDto> moviesToDisplay)
    {
        Movies.Clear();
        foreach (var movie in moviesToDisplay)
        {
            Movies.Add(new MovieControlViewModel(movie));
        }
    }

    private void ClearFilters()
    {
        SetupCategories();
        SearchText = string.Empty;
    }
}