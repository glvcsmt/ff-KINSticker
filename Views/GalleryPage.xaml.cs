using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJVTD2_MP_2025261.Data;
using RJVTD2_MP_2025261.ViewModels;

namespace RJVTD2_MP_2025261.Views;

public partial class GalleryPage : ContentPage
{
    private GalleryPageViewModel viewModel;
    
    public GalleryPage(IStickerDatabase database)
    {
        InitializeComponent();
        BindingContext = viewModel = new GalleryPageViewModel(database);
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.LoadStickers();
    }
}