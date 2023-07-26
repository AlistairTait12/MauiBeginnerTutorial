using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyTasksApp.ViewModel;

[QueryProperty("Text", "Text")]
public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    string _text;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
