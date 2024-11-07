using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp7.Models;
using System.Collections.ObjectModel;

namespace MauiApp7.ViewModels;

partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<Note> Notes { get; }

    public MainViewModel()
    {
        Notes = new ObservableCollection<Note>
        {
            new Note { Text = "Buy groceries" },
            new Note { Text = "Complete project report" },
            new Note { Text = "Call the bank" },
        };
    }

    [RelayCommand]
    void Delete(Note note)
    {
        if (Notes.Contains(note))
            Notes.Remove(note);
    }
}
