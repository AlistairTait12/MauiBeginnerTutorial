using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyTasksApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity _connectivity;

    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        _connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> _items;

    [ObservableProperty]
    string _text;

    [RelayCommand]
    async Task Add()
    {
        if(string.IsNullOrWhiteSpace(Text))
        {
            return;
        }

        if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Oh noo!", "No Internets", "Thanks");
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

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}
