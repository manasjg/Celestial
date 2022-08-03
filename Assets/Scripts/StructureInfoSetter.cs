using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class StructureInfoSetter : MonoBehaviour
{
    public Button structureInfoButton;
    public Text megaStructureNameText;
    public Text descriptionText;
    public Text productionText;
    public Text capacityText;
    public string[] structureDesciptions;
    public Button buildButton;
    public GameObject satelitePanel;
    public static StructureInfoSetter instance;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        this.gameObject.SetActive(false);
        buildButton.onClick.AddListener(SetSateliteInfoPanel);
    }

    private void DisableStructureInfo()
    {
        this.gameObject.SetActive(false);
        structureInfoButton.onClick.RemoveAllListeners();
    }

    public void SetupStructureInfo(MegaStructureModel megaStructureModel)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(SetStructureInfoButton());
        megaStructureNameText.text = megaStructureModel.megaStructureData.name;
        descriptionText.text = structureDesciptions[(int)megaStructureModel.megaStructureData.structureType];
        productionText.text = $"Production  : {megaStructureModel.megaStructureData.resourceGeneration} ";
        capacityText.text = $"Capacity  : {megaStructureModel.megaStructureData.capacity} ";
        if(megaStructureModel.megaStructureData.structureType == MegaStructureType.RocketLauncher)
        {
            buildButton.gameObject.SetActive(true);
        }
        else
        {
            buildButton.gameObject.SetActive(false);
        }
    }

    private IEnumerator SetStructureInfoButton()
    {
        yield return new WaitForSeconds(0.2f);
        structureInfoButton.onClick.AddListener(DisableStructureInfo);
    }

    private void SetSateliteInfoPanel()
    {
        satelitePanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
