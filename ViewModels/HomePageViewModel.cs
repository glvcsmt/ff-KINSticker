using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RJVTD2_MP_2025261.Views;

namespace RJVTD2_MP_2025261.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private string capturedPhotoPath;

    [RelayCommand]
    public async Task CapturePhotoAsync()
    {
        try
        {
            await CrossMedia.Current.Initialize();

            var cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
            if (cameraStatus != PermissionStatus.Granted) return;

            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = false,
                PhotoSize = PhotoSize.Medium
            });

            if (photo != null)
            {
                capturedPhotoPath = photo.Path;
                await Shell.Current.Navigation.PushModalAsync(new PhotoPreviewPopup(capturedPhotoPath));
            }
        }
        catch (Exception ex)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Application.Current?.MainPage?.DisplayAlert("Hiba", ex.Message, "OK");
            });
        }
    }
}