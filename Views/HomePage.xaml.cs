using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJVTD2_MP_2025261.ViewModels;

namespace RJVTD2_MP_2025261.Views;

public partial class HomePage : ContentPage
{
    private HomePageViewModel _viewModel;
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}