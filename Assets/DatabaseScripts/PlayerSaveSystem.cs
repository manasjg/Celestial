using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using System.Threading.Tasks;

public class PlayerSaveSystem : MonoBehaviour
{
   
    string player_key= FirebaseAuth.DefaultInstance.CurrentUser.DisplayName;
   
    private FirebaseDatabase _database;
    private void Start()
    {
        SetupFirebase();
    }
    public void SetupFirebase()
    {
        _database = FirebaseDatabase.DefaultInstance;
    }
    public void SavePlayer(PlayerData player)
    {
        //  PlayerPrefs.SetString(player_key, JsonUtility.ToJson(player))
        _database.GetReference(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child(player_key).SetRawJsonValueAsync(JsonUtility.ToJson(player));
    }

    public async Task<PlayerData> LoadPlayer()
    {
        var dataSnapShot = await _database.GetReference(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child(player_key).GetValueAsync();
        if (!dataSnapShot.Exists)
        {
            return new PlayerData();
        }
        return JsonUtility.FromJson<PlayerData>(dataSnapShot.GetRawJsonValue());
        return new PlayerData();
    }

     public async Task<bool> SaveExists()
    {
        var dataSnapShot = await _database.GetReference(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child(player_key).GetValueAsync();
        return dataSnapShot.Exists;
    }

    public void EraseSave()
    {
        _database.GetReference(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child(player_key).RemoveValueAsync();
    }
}
