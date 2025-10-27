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
    public string photoPath;
    
    [ObservableProperty]
    public string location;
    
    [ObservableProperty]
    public string spotName;
    
    [ObservableProperty]
    public string team;
}