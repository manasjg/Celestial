using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LogoutUser);
    }

   void LogoutUser()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        SceneManager.LoadScene(0);

    }
}
