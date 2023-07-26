using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyTasksApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> _items;

    [ObservableProperty]
    string _text;

    [RelayCommand]
    void Add()
    {
        if(string.IsNullOrWhiteSpace(Text))
        {
            return;
        }

        Items.Add(Text);
        // add 
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }
}
