namespace MovieAppWpf.Services;

public static class ViewLocator
{
    public static Type GetViewTypeForViewModel(Type viewModelType)
    {
        var viewTypeName = viewModelType.FullName.Replace("Model", "");
        var viewType = Type.GetType(viewTypeName);
        return viewType;
    }
}