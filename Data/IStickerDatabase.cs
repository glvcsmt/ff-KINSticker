using RJVTD2_MP_2025261.Models;

namespace RJVTD2_MP_2025261.Data;

public interface IStickerDatabase
{
    Task<List<StickerSpot>> GetStickerSpotsAsync();
    Task<StickerSpot> GetStickerSpotAsync(int id);
    Task CreateStickerSpotAsync(StickerSpot stickerSpot);
    Task UpdateStickerSpotAsync(StickerSpot stickerSpot);
    Task DeleteStickerSpotAsync(StickerSpot stickerSpot);
}