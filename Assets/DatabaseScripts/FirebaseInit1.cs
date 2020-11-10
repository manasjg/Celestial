using UnityEngine;
using Firebase;
using Firebase.Extensions;
using UnityEngine.Events;
public class FirebaseInit1 : MonoBehaviour
{
    public UnityEvent OnFirebaseInitialized = new UnityEvent();
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError("Cannot initialize firebase because : " + task.Exception);
                return;
            }
            OnFirebaseInitialized.Invoke();
        });
    }
}
