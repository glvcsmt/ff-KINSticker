using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RJVTD2_MP_2025261.Views;

namespace RJVTD2_MP_2025261.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty]
    private string capturedPhotoPath;

    [RelayCommand]
    public async Task CapturePhotoAsync()
    {
        if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                PhotoSize = PhotoSize.Medium
            });

            if (photo != null)
            {
                capturedPhotoPath = photo.Path;
                await Shell.Current.Navigation.PushModalAsync(new PhotoPreviewPopup(capturedPhotoPath));
            }
        }
    }
}