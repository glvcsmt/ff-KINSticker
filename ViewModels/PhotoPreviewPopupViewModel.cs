using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RJVTD2_MP_2025261.Data;
using RJVTD2_MP_2025261.Models;

namespace RJVTD2_MP_2025261.ViewModels;

public partial class PhotoPreviewPopupViewModel : ObservableObject
{
    private IStickerDatabase _stickerDatabase;
    
    [ObservableProperty]
    private string capturedPhotoPath;
    
    [ObservableProperty]
    private string selectedTeam;

    [ObservableProperty] 
    private string spotName;
    
    [ObservableProperty]
    private List<string> teams = new()
    {
        "KINFO",
        "Alkatrész", "Automatika", "Energetika",
        "Fehérvár", "Gépész", "HIPI", "Műszer",
        "Rejtő", "Ybl"
    };

    public PhotoPreviewPopupViewModel(string capturedPhotoPath, IStickerDatabase database)
    {
        CapturedPhotoPath = capturedPhotoPath;
        _stickerDatabase = database;
    }

    [RelayCommand]
    public async Task SavePhoto(string name)
    {
        StickerSpot newSticker = new StickerSpot();
        newSticker.PhotoPath = capturedPhotoPath;
        newSticker.SpotName = SpotName;
        newSticker.Team = selectedTeam;
        newSticker.Date = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
        
        _stickerDatabase.CreateStickerSpotAsync(newSticker);
        
        await Shell.Current.Navigation.PopModalAsync();
    }
}