using RJVTD2_MP_2025261.Models;
using SQLite;

namespace RJVTD2_MP_2025261.Data;

public class SQLiteStickerDatabase : IStickerDatabase
{
    SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create;
    
    string databasePath = Path.Combine(FileSystem.Current.AppDataDirectory, "StickerDatabase.db3");
    
    private SQLiteAsyncConnection database;

    public SQLiteStickerDatabase()
    {
        database = new SQLiteAsyncConnection(databasePath, Flags);
        database.CreateTableAsync<StickerSpot>().Wait();
        database.CreateTableAsync<Profile>().Wait();
    } 
    
    //StickerSpot
    public async Task<List<StickerSpot>> GetStickerSpotsAsync()
    {
        return await database.Table<StickerSpot>().ToListAsync();
    }

    public async Task<StickerSpot> GetStickerSpotAsync(int id)
    {
        return await database.Table<StickerSpot>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateStickerSpotAsync(StickerSpot stickerSpot)
    {
        await database.InsertAsync(stickerSpot);
    }

    public async Task UpdateStickerSpotAsync(StickerSpot stickerSpot)
    {
        await database.UpdateAsync(stickerSpot);
    }

    public async Task DeleteStickerSpotAsync(StickerSpot stickerSpot)
    {
        await database.DeleteAsync(stickerSpot);
    }
    
    //Profile
    public async Task<List<Profile>> GetProfilesAsync()
    {
        return await database.Table<Profile>().ToListAsync(); 
    }

    public async Task<Profile> GetProfileAsync(int id)
    {
        return await database.Table<Profile>().Where(i => i.Id == id).FirstOrDefaultAsync(); 
    }

    public async Task CreateProfileAsync(Profile profile)
    {
        await database.InsertAsync(profile);
    }

    public async Task UpdateProfileAsync(Profile profile)
    {
        await database.UpdateAsync(profile);
    }

    public async Task DeleteProfileAsync(Profile profile)
    {
        await database.DeleteAsync(profile);
    }
}