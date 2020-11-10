using UnityEngine.UI;
using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    [SerializeField]
    GameObject PanelToLoad,MainMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetPanel);
    }

   void SetPanel()
    {
        PanelToLoad.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
}
