using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public enum SateliteType
{
    RemoteSensing,
    Transport,
    Spaceship
}

public class SateliteLaunchInfoSetter : MonoBehaviour
{
    public Button sateliteLaunchInfoButton;
    public Text sateliteNameText;
    public Text descriptionText;
    public Text costText;
    public Text chemicalText;
    public Text buildText;
    public static SateliteLaunchInfoSetter instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        this.gameObject.SetActive(false);
    }

    private void DisableSateliteInfo()
    {
        this.gameObject.SetActive(false);
        sateliteLaunchInfoButton.onClick.RemoveAllListeners();
    }

    public void SetupSateliteInfo(SateliteScriptableObject satelite)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(SetStructureInfoButton());
        sateliteNameText.text = satelite.NameText;
        descriptionText.text = satelite.Description;
        costText.text = "Cost:" + satelite.CashCost.ToString();
        chemicalText.text = "Chemical: " + satelite.ChemicalCost.ToString();
        buildText.text = "Build Time:" + satelite.BuildTime.ToString();
    }
    public void DisablePanel()
    {
        this.gameObject.SetActive(false);
    }
    private IEnumerator SetStructureInfoButton()
    {
        yield return new WaitForSeconds(0.2f);
        //sateliteLaunchInfoButton.onClick.AddListener(DisableStructureInfo);
    }
}
