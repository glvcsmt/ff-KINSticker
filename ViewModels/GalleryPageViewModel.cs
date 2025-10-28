using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RJVTD2_MP_2025261.Data;
using RJVTD2_MP_2025261.Models;

namespace RJVTD2_MP_2025261.ViewModels;

public partial class GalleryPageViewModel : ObservableObject
{
    private IStickerDatabase _stickerDatabase;

    [ObservableProperty]
    private ObservableCollection<StickerSpot> stickers = new();
    
    public GalleryPageViewModel(IStickerDatabase stickerDatabase)
    {
        _stickerDatabase = stickerDatabase;
    }

    [RelayCommand]
    public async Task LoadStickers()
    {
        var items = await _stickerDatabase.GetStickerSpotsAsync();
        Stickers.Clear();
        foreach (var sticker in items)
        {
            Stickers.Add(sticker);
        }
    }
    
    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.Navigation.PopModalAsync();
    }
}