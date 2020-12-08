using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
    private int usercosmiccash;
    private int userfood;
    private int userchemical;
    private int userenergy;
    private int usertechnology;
    public Text cashText;
    public Text foodText;
    public Text chemicalText;
    public Text energyText;
    public Text techText;
    public static UserData Instance;
    PlayerData pData;

    void Start()
    {
        pData = PlayerSaveBehavior.Instance.GetPlayerData();
        SetTextFromData();
        Instance = this;
    }

    private void SetTextFromData()
    {
        cashText.text = pData.cash.ToString();
        foodText.text = pData.food.ToString();
        chemicalText.text = pData.chemicals.ToString();
        energyText.text = pData.energy.ToString();
        techText.text = pData.tech.ToString();
        PlayerSaveBehavior.Instance.SavePlayerData(pData);

    }

    public void ReduceUserData(MegaStructureSciptableObject megastructureData)
    {
        pData.cash -= megastructureData.CashCost;
        pData.food -= megastructureData.FoodCost;
        pData.energy -= megastructureData.EnergyRequired;
        pData.chemicals -= megastructureData.ChemicalCost;
        pData.tech -= megastructureData.TechnologyRequired;
        SetTextFromData();
    }

}
