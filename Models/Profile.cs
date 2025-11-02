using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace RJVTD2_MP_2025261.Models;

public partial class Profile : ObservableObject
{
    [property: AutoIncrement]
    [property: PrimaryKey]
    [ObservableProperty]
    private int id;
    
    [ObservableProperty]
    private string nickname;

    [ObservableProperty] 
    private string team;
}