using UnityEngine.UI;
using UnityEngine;

public class SateliteUIController : MonoBehaviour
{
    public Button SateliteMenuButton;
    public Button[] SateliteInfoButtons;

    public Button[] CloseButtons;

    public GameObject SateliteMenuPanel;
    public GameObject SateliteInfoPanel;

    public RectTransform SateliteInfoListRect;
    float yListRectPos;
    void Start()
    {
        yListRectPos = SateliteInfoListRect.anchoredPosition.y;
        for(int i = 0; i < CloseButtons.Length; i++)
        {
            CloseButtons[i].onClick.AddListener(DisableSatelitePanels);
        }
        for (int i = 0; i < SateliteInfoButtons.Length; i++)
        {
            SateliteInfoButtons[i].onClick.AddListener(delegate { EnableSateliteInfo(i); });
        }
        SateliteMenuButton.onClick.AddListener(SetSateliteMenuPanel);
    }

    void EnableSateliteInfo(int index)
    {
        SateliteInfoListRect.anchoredPosition = new Vector2(SateliteInfoListRect.anchoredPosition.x, yListRectPos);
        SateliteInfoPanel.SetActive(true);
        SateliteMenuPanel.SetActive(false);
    }

    void DisableSatelitePanels()
    {
        SateliteInfoPanel.SetActive(false);
        SateliteMenuPanel.SetActive(false);
        SateliteMenuButton.gameObject.SetActive(true);
    }

    void SetSateliteMenuPanel()
    {
        SateliteMenuPanel.SetActive(true);
        SateliteMenuButton.gameObject.SetActive(false);
    }
}
