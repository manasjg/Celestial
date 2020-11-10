using UnityEngine.UI;
using UnityEngine;
using Firebase.Auth;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using Google;
using System.Threading.Tasks;

public class LoginUIFlow : MonoBehaviour
{
    [SerializeField]
    Button registerButton/*,loginButton*/;

    //[SerializeField]
    //TMP_InputField emailField,passField1,passField2;
    FirebaseAuth _auth;
    [SerializeField]
    TextMeshProUGUI errorMsg;


    //[SerializeField]
    //TMP_InputField emailFieldLogin, passField1Login;
    //[SerializeField]
    //TextMeshProUGUI errorMsgLogin;

    Coroutine _registrationCoroutine=null;
    Coroutine _loginCoroutine = null;
    private void Start()
    {
        registerButton.onClick.AddListener(RegisterPlayer);
      //  loginButton.onClick.AddListener(LoginPlayer);
    }
    public void SetupFirebase()
    {
        _auth = FirebaseAuth.DefaultInstance;
        if (_auth.CurrentUser != null)
        {
            registerButton.interactable = false;
           
            SceneManager.LoadScene(1);
        }
    }

    //void LoginPlayer()
    //{
    //    if (emailFieldLogin.text.Length > 0)
    //    {
    //        if (passField1Login.text.Length > 0)
    //        {
    //            Debug.Log("Login Player");
    //            if (_loginCoroutine == null)
    //                _loginCoroutine = StartCoroutine(LoginUser());
    //        }
    //        else
    //        {
    //            errorMsgLogin.text = "Passwords cannot be empty";
    //        }
    //    }
    //    else
    //    {
    //        errorMsgLogin.text = "Email cannot be empty";
    //    }


    //}

    void RegisterPlayer()
    {
        //if (emailField.text.Length > 0)
        //{
        //    if (passField1.text == passField2.text)
        //    {
        //        Debug.Log("Registering Player");
        //        if(_registrationCoroutine==null)
        //        _registrationCoroutine = StartCoroutine(RegisterUser());
        //    }
        //    else
        //    {
        //        errorMsg.text = "Passwords don't match";
        //    }
        //}
        //else
        //{
        //    errorMsg.text = "Email cannot be empty";
        //}

      
        GoogleSignIn.Configuration = new GoogleSignInConfiguration
        {
            RequestIdToken = true,
            // Copy this value from the google-service.json file.
            // oauth_client with type == 3
            WebClientId = "756112456064-7048rmf5n98brrn6r1irbcigkvdd14ia.apps.googleusercontent.com"
        };

        Task<GoogleSignInUser> signIn = GoogleSignIn.DefaultInstance.SignIn();

        TaskCompletionSource<FirebaseUser> signInCompleted = new TaskCompletionSource<FirebaseUser>();
        signIn.ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                signInCompleted.SetCanceled();
            }
            else if (task.IsFaulted)
            {
                signInCompleted.SetException(task.Exception);
            }
            else
            {
                Debug.Log("Registering");
                Firebase.Auth.Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(((Task<GoogleSignInUser>)task).Result.IdToken, null);
                StartCoroutine(RegisterUser(credential));
            }
        });
    }

    private IEnumerator RegisterUser(Firebase.Auth.Credential cred)
    {
      
        var RegisterTask = _auth.SignInWithCredentialAsync(cred);
        registerButton.interactable = false;
        yield return new WaitUntil(()=>RegisterTask.IsCompleted);

        if (RegisterTask.Exception != null)
        {
            Debug.Log("Registration failed with exception : " + RegisterTask.Exception);
            
        }
        else
        {
            SceneManager.LoadScene(1);
            Debug.Log("Registration completed : " + RegisterTask.Exception);
        }
        _registrationCoroutine = null;
        registerButton.interactable = true;
    }

    //private IEnumerator LoginUser(Firebase.Auth.Credential cred)
    //{
    //    var LoginTask = _auth.SignInWithEmailAndPasswordAsync(emailFieldLogin.text, passField1Login.text);
    //    loginButton.interactable = false;
    //    yield return new WaitUntil(() => LoginTask.IsCompleted);

    //    if (LoginTask.Exception != null)
    //    {
    //        Debug.Log("Login failed with exception : " + LoginTask.Exception);

    //    }
    //    else
    //    {
    //        SceneManager.LoadScene(1);
    //        Debug.Log("Login completed : " + LoginTask.Exception);
    //    }
    //    _registrationCoroutine = null;
    //    loginButton.interactable = true;
    //}
}
