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
    public static StructureInfoSetter instance;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        this.gameObject.SetActive(false);
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
    }

    private IEnumerator SetStructureInfoButton()
    {
        yield return new WaitForSeconds(0.2f);
        structureInfoButton.onClick.AddListener(DisableStructureInfo);
    }
}
