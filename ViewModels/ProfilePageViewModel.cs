using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RJVTD2_MP_2025261.Data;
using RJVTD2_MP_2025261.Models;

namespace RJVTD2_MP_2025261.ViewModels;

public partial class ProfilePageViewModel : ObservableObject
{
    private IStickerDatabase _stickerDatabase;
    private Profile? _profile;

    [ObservableProperty] private string photoPath;
    [ObservableProperty] private string nickname;

    [ObservableProperty] private bool isReadOnly = true;
    [ObservableProperty] private bool isEnabled = false;

    [ObservableProperty] private string selectedTeam;

    [ObservableProperty] private List<string> teams = new()
    {
        "KINFO",
        "Alkatrész", "Automatika", "Energetika",
        "Fehérvár", "Gépész", "HIPI", "Műszer",
        "Rejtő", "Ybl"
    };

    public ProfilePageViewModel(IStickerDatabase database)
    {
        _stickerDatabase = database;
        _ = LoadProfileAsync();
    }

    [RelayCommand]
    public async Task LoadProfileAsync()
    {
        var profiles = await _stickerDatabase.GetProfilesAsync();
        _profile = profiles.FirstOrDefault();

        if (_profile is not null)
        {
            Nickname = _profile.Nickname;
            SelectedTeam = _profile.Team;

            IsReadOnly = true;
            IsEnabled = false;
        }
        else
        {
            IsReadOnly = false;
            IsEnabled = true;
        }
    }

    [RelayCommand]
    public async Task GoBackAsync()
    {
        await Shell.Current.Navigation.PopModalAsync();
    }

    [RelayCommand]
    public async Task EditProfileAsync()
    {
        IsEnabled = true;
        IsReadOnly = false;
    }

    [RelayCommand]
    public async Task SaveProfile()
    {
        if (string.IsNullOrWhiteSpace(Nickname) || string.IsNullOrWhiteSpace(SelectedTeam))
        {
            await Shell.Current.DisplayAlert("Hiányzó adatok", "Kérlek tölts ki minden mezőt!", "OK");
            return;
        }

        if (_profile is null)
        {
            _profile = new Profile();
            _profile.Nickname = Nickname.Trim();
            _profile.Team = SelectedTeam;

            await _stickerDatabase.CreateProfileAsync(_profile);
        }
        else
        {
            _profile.Nickname = Nickname.Trim();
            _profile.Team = SelectedTeam;

            await _stickerDatabase.UpdateProfileAsync(_profile);
        }

        IsEnabled = false;
        IsReadOnly = true;

        await Shell.Current.DisplayAlert("Siker", "Profil mentve!", "OK");
    }
}