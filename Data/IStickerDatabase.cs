using RJVTD2_MP_2025261.Models;

namespace RJVTD2_MP_2025261.Data;

public interface IStickerDatabase
{
    //StickerSpot Table
    Task<List<StickerSpot>> GetStickerSpotsAsync();
    Task<StickerSpot> GetStickerSpotAsync(int id);
    Task CreateStickerSpotAsync(StickerSpot stickerSpot);
    Task UpdateStickerSpotAsync(StickerSpot stickerSpot);
    Task DeleteStickerSpotAsync(StickerSpot stickerSpot);
    
    //Profile Table
    Task<List<Profile>> GetProfilesAsync();
    Task<Profile> GetProfileAsync(int id);
    Task CreateProfileAsync(Profile profile);
    Task UpdateProfileAsync(Profile profile);
    Task DeleteProfileAsync(Profile profile);
}