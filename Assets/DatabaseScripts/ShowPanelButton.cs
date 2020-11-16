using UnityEngine.UI;
using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panelToLoad,mainMenuPanel;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetPanel);
    }

   void SetPanel()
    {
        panelToLoad.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
}
