using UnityEngine;
using UnityEngine.UI;

public class PlanetScrollListToggle : MonoBehaviour
{
    [SerializeField]
    private Button planetScrollListToggleButton,closeButton;

    [SerializeField]
    private GameObject planetScrollList;
    bool listFlag = true;
  
    private void Start()
    {
        planetScrollListToggleButton.onClick.AddListener(SetListToggle);
        closeButton.onClick.AddListener(CloseScrollList);
    }

    void CloseScrollList()
    {
        planetScrollList.SetActive(false);
        listFlag = true;
    }
    private void SetListToggle()
    {
        planetScrollList.SetActive(listFlag);
        listFlag = !listFlag;
    }
}
