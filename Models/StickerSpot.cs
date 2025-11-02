using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace RJVTD2_MP_2025261.Models;

public partial class StickerSpot : ObservableObject
{
    [property: AutoIncrement] 
    [property: PrimaryKey]
    [ObservableProperty]
    private int id;
    
    [ObservableProperty]
    private DateTime date;
    
    [ObservableProperty]
    private string photoPath;
    
    [ObservableProperty]
    private string location;
    
    [ObservableProperty]
    private string spotName;
    
    [ObservableProperty]
    private string team;
    
    [ObservableProperty]
    private double latitude;
    
    [ObservableProperty]
    private double longitude;
}