using TMPro;
using UnityEngine;

public class FirebaseLoadTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       PlayerData pData = PlayerSaveBehavior.Instance.GetPlayerData();
        if (pData.planets == null)
        {
            GetComponent<TextMeshProUGUI>().text = "Not Loaded";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = pData.planets[0].planetInfo.planetName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
