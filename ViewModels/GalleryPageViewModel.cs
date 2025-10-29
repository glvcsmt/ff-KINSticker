using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RJVTD2_MP_2025261.Data;
using RJVTD2_MP_2025261.Models;

namespace RJVTD2_MP_2025261.ViewModels;

public partial class GalleryPageViewModel : ObservableObject
{
    private IStickerDatabase _stickerDatabase;
    
    [ObservableProperty]
    private string selectedTeam;
    
    [ObservableProperty]
    private List<string> teams = new()
    {
        "Mindent mutat",
        "KINFO",
        "Alkatrész", "Automatika", "Energetika",
        "Fehérvár", "Gépész", "HIPI", "Műszer",
        "Rejtő", "Ybl"
    };

    [ObservableProperty]
    private ObservableCollection<StickerSpot> stickers = new();
    
    [ObservableProperty]
    private ObservableCollection<StickerSpot> filteredStickers = new();
    
    public GalleryPageViewModel(IStickerDatabase stickerDatabase)
    {
        _stickerDatabase = stickerDatabase;
    }

    [RelayCommand]
    public async Task LoadStickersAsync()
    {
        var items = await _stickerDatabase.GetStickerSpotsAsync();
        Stickers.Clear();
        foreach (var sticker in items)
        {
            Stickers.Add(sticker);
            FilteredStickers.Add(sticker);
        }
    }

    [RelayCommand]
    public async Task FilterTeamAsync()
    {
        FilteredStickers.Clear();
        if (SelectedTeam == "Mindent mutat")
        {
            FilteredStickers = Stickers;
        }
        else
        {
            foreach (StickerSpot sticker in Stickers)
            {
                if (SelectedTeam == sticker.Team)
                {
                    FilteredStickers.Add(sticker);
                }
            }   
        }
    }

    partial void OnSelectedTeamChanged(string value)
    {
        if (FilterTeamCommand.CanExecute(null))
        {
            _ = FilterTeamCommand.ExecuteAsync(null);
        }
    }
    
    [RelayCommand]
    public async Task GoBackAsync()
    {
        await Shell.Current.Navigation.PopModalAsync();
    }
    
}