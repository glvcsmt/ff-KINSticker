using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJVTD2_MP_2025261.Data;
using RJVTD2_MP_2025261.ViewModels;

namespace RJVTD2_MP_2025261.Views;

public partial class PhotoPreviewPopup : ContentPage
{
    PhotoPreviewPopupViewModel viewModel;
    public PhotoPreviewPopup(string capturedPhotoPath, IStickerDatabase database)
    {
        InitializeComponent();
        BindingContext = viewModel = new PhotoPreviewPopupViewModel(capturedPhotoPath, database);
    }
}