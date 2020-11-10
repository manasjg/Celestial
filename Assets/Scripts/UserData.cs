using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
    public int usercosmiccash;
    public int userfood;
    public int userchemical;
    public int userenergy;
    public int usertechnology;
    public Text CashText;
    public Text FoodText;
    public Text ChemicalText;
    public Text EnergyText;
    public Text TechText;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("UserData"))
        {
            usercosmiccash = PlayerPrefs.GetInt("UserCosmicCash");
            userfood = PlayerPrefs.GetInt("UserFood");
            userchemical = PlayerPrefs.GetInt("UserChemical");
            userenergy = PlayerPrefs.GetInt("UserEnergy");
            usertechnology = PlayerPrefs.GetInt("UserTechnology");
            CashText.text = usercosmiccash.ToString();
            FoodText.text = userfood.ToString();
            ChemicalText.text = userchemical.ToString();
            EnergyText.text = userenergy.ToString();
            TechText.text = usertechnology.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("UserData", 1);
            usercosmiccash = 50000;
            PlayerPrefs.SetInt("UserCosmicCash", 50000);
            userfood = 50000;
            PlayerPrefs.SetInt("UserFood", 50000);
            userchemical = 50000;
            PlayerPrefs.SetInt("UserChemical", 50000);
            userenergy = 50000;
            PlayerPrefs.SetInt("UserEnergy", 50000);
            usertechnology = 50000;
            PlayerPrefs.SetInt("UserTechnology", 50000);
            CashText.text = usercosmiccash.ToString();
            FoodText.text = userfood.ToString();
            ChemicalText.text = userchemical.ToString();
            EnergyText.text = userenergy.ToString();
            TechText.text = usertechnology.ToString();
        }
    }

}
