using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RJVTD2_MP_2025261.Models;

namespace RJVTD2_MP_2025261.ViewModels;

public partial class PhotoPreviewPopupViewModel : ObservableObject
{
    [ObservableProperty]
    private string capturedPhotoPath;
    
    [ObservableProperty]
    private string selectedTeam;
    
    [ObservableProperty]
    List<string> teams = new List<string>()
    {
        "KINFO",
        "Alkatrész", "Automatika", "Energetika",
        "Fehérvár", "Gépész", "HIPI", "Műszer",
        "Rejtő", "Ybl"
    };

    public PhotoPreviewPopupViewModel(string capturedPhotoPath)
    {
        CapturedPhotoPath = capturedPhotoPath;
    }

    [RelayCommand]
    public async Task SavePhoto(string name)
    {
        StickerSpot newSticker = new StickerSpot();
        newSticker.PhotoPath = capturedPhotoPath;
        newSticker.SpotName = name;
        newSticker.Team = selectedTeam;
        
        await Shell.Current.Navigation.PopModalAsync();
    }
}