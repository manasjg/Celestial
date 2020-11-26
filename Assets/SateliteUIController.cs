using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class SateliteUIController : MonoBehaviour
{
    public Button sateliteMenuButton;
    public Button[] sateliteInfoButtons;

    public Button[] closeButtons;

    public GameObject sateliteMenuPanel;
    public GameObject sateliteInfoPanel;

    public RectTransform sateliteInfoListRect;
    public Button sateliteInfoButton;
    List<Button> createdButtons;
    float yListRectPos;

    public Text rcsCounts;
    public Text transportCounts;
    public Text spaceshipCounts;

    void Start()
    {
        createdButtons = new List<Button>();
        yListRectPos = sateliteInfoListRect.anchoredPosition.y;
        for(int i = 0; i < closeButtons.Length; i++)
        {
            closeButtons[i].onClick.AddListener(DisableSatelitePanels);
        }
        for (int i = 0; i < sateliteInfoButtons.Length; i++)
        {
            int index = i;
            sateliteInfoButtons[i].onClick.AddListener(delegate { EnableSateliteInfo(index); });
        }
        sateliteMenuButton.onClick.AddListener(SetSateliteMenuPanel);
    }

    void EnableSateliteInfo(int index)
    {
        DisableAllCreatedSateliteButtons();
        CreateUISatelitePanel();
        CreateButtons(index);
    }

    void DisableAllCreatedSateliteButtons()
    {
        if (createdButtons.Count > 0)
        {
            for (int i = 0; i < createdButtons.Count; i++)
            {
                Destroy(createdButtons[i].gameObject);
            }
        }
        createdButtons.Clear();
    }

    void CreateUISatelitePanel()
    {
        sateliteInfoListRect.anchoredPosition = new Vector2(sateliteInfoListRect.anchoredPosition.x, yListRectPos);
        sateliteInfoPanel.SetActive(true);
        sateliteMenuPanel.SetActive(false);
    }
    
    void CreateButtons(int index)
    {
        PlayerData pData = PlayerSaveBehavior.Instance.GetPlayerData();
        switch (index)
        {
            case 0:
                if (pData.satelites.remoteControlSatelites.Count > 1)
                {
                    for (int i = 1; i < pData.satelites.remoteControlSatelites.Count; i++)
                    {
                        Button createdButton = Instantiate(sateliteInfoButton, sateliteInfoButton.transform.parent);
                        createdButtons.Add(createdButton);
                    }
                }
                break;
            case 1:
                if (pData.satelites.transportSatelites.Count > 1)
                {
                    for (int i = 1; i < pData.satelites.transportSatelites.Count; i++)
                    {
                        Button createdButton = Instantiate(sateliteInfoButton, sateliteInfoButton.transform.parent);
                        createdButtons.Add(createdButton);
                    }
                }
                break;
            case 2:
                if (pData.satelites.spaceships.Count > 1)
                {
                    for (int i = 1; i < pData.satelites.spaceships.Count; i++)
                    {
                        Button createdButton = Instantiate(sateliteInfoButton, sateliteInfoButton.transform.parent);
                        createdButtons.Add(createdButton);
                    }
                }
                break;
        }
    }

    void DisableSatelitePanels()
    {
        sateliteInfoPanel.SetActive(false);
        sateliteMenuPanel.SetActive(false);
        sateliteMenuButton.gameObject.SetActive(true);
    }

    void SetSateliteMenuPanel()
    {
        sateliteMenuPanel.SetActive(true);
        sateliteMenuButton.gameObject.SetActive(false);
        PlayerData pData = PlayerSaveBehavior.Instance.GetPlayerData();
        rcsCounts.text = pData.satelites.remoteControlSatelites.Count.ToString();
        transportCounts.text = pData.satelites.transportSatelites.Count.ToString();
        spaceshipCounts.text = pData.satelites.spaceships.Count.ToString();
    }
}
