using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfoDisplayManager : MonoBehaviour
{
    public Text playerInfoText;
    public float infoCoolDown;
    public static PlayerInfoDisplayManager instance;

    private void Start()
    {
        instance = this;
    }

    public void ShowPlayerMessage(string message)
    {
        StartCoroutine(DisplayPlayerMessage(message));
    }

    IEnumerator DisplayPlayerMessage(string message)
    {
        playerInfoText.gameObject.SetActive(true);
        playerInfoText.text = message;
        yield return new WaitForSeconds(infoCoolDown);
        playerInfoText.text = "";
        playerInfoText.gameObject.SetActive(false);
    }
    
}
