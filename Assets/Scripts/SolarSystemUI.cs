using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarSystemUI : MonoBehaviour
{
    public GameObject ButtonInfoPanel;
    public Text ButtonInfoText;
    public Image ButtonInfoImage;
    public Sprite ChemicalImage, FoodImage, EnergyImage, CosmicCashImage, TechnologyImage;
    public GameObject CloseButton;

	void Start ()
    {
		
	}

    public void ChemicalInfo()
    {
        ButtonInfoImage.sprite = ChemicalImage;
        ButtonInfoText.text = "Chemicals \n" + "used in construction and megasite";
        ButtonInfoPanel.SetActive(true);
        CloseButton.SetActive(true);
    }

    public void FoodInfo()
    {
        ButtonInfoImage.sprite = FoodImage;
        ButtonInfoText.text = "Food \n" + "used in construction and megasite";
        ButtonInfoPanel.SetActive(true);
        CloseButton.SetActive(true);
    }

    public void CosmicCashInfo()
    {
        ButtonInfoImage.sprite = CosmicCashImage;
        ButtonInfoText.text = "Cosmic Cash \n" + "used in construction and megasite";
        ButtonInfoPanel.SetActive(true);
        CloseButton.SetActive(true);
    }

    public void TechnologyInfo()
    {
        ButtonInfoImage.sprite = TechnologyImage;
        ButtonInfoText.text = "Technology \n" + "used in construction and megasite";
        ButtonInfoPanel.SetActive(true);
        CloseButton.SetActive(true);
    }

    public void EnergyInfo()
    {
        ButtonInfoImage.sprite = EnergyImage;
        ButtonInfoText.text = "Energy \n" + "used in construction and megasite";
        ButtonInfoPanel.SetActive(true);
        CloseButton.SetActive(true);
    }

    public void CloseInfoPanel()
    {
        ButtonInfoPanel.SetActive(false);
        CloseButton.SetActive(false);
    }

}
