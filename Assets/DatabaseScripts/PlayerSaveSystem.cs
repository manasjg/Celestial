using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using System.Threading.Tasks;

public class PlayerSaveSystem : MonoBehaviour
{
    private string playerKey = FirebaseAuth.DefaultInstance.CurrentUser.DisplayName;
    private FirebaseDatabase database;

    private void Start()
    {
        SetupFirebase();
    }

    public void SetupFirebase()
    {
        database = FirebaseDatabase.DefaultInstance;
    }

    public void SavePlayer(PlayerData player)
    {
        //  PlayerPrefs.SetString(player_key, JsonUtility.ToJson(player))
        database.GetReference(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child(playerKey).SetRawJsonValueAsync(JsonUtility.ToJson(player));
    }

    public async Task<PlayerData> LoadPlayer()
    {
        var dataSnapShot = await database.GetReference(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child(playerKey).GetValueAsync();
        if (!dataSnapShot.Exists)
        {
            return new PlayerData();
        }
        return JsonUtility.FromJson<PlayerData>(dataSnapShot.GetRawJsonValue());
        return new PlayerData();
    }

    public async Task<bool> SaveExists()
    {
        var dataSnapShot = await database.GetReference(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child(playerKey).GetValueAsync();
        return dataSnapShot.Exists;
    }

    public void EraseSave()
    {
        database.GetReference(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child(playerKey).RemoveValueAsync();
    }
}
