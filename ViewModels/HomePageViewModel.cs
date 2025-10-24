using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace RJVTD2_MP_2025261.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty]
    string capturedPhotoPath;

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
            }
        }
    }
}