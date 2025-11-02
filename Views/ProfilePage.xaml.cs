using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJVTD2_MP_2025261.Data;
using RJVTD2_MP_2025261.ViewModels;

namespace RJVTD2_MP_2025261.Views;

public partial class ProfilePage : ContentPage
{
    private ProfilePageViewModel _viewModel;
    public ProfilePage(IStickerDatabase database)
    {
        InitializeComponent();
        BindingContext = _viewModel = new ProfilePageViewModel(database);
    }
}