using System;
using UnityEngine.UI;
using UnityEngine;

public class SateliteInfoSetter : MonoBehaviour
{
    private Sprite[] planetImages;
    private string[] planetNames;

    private Image sourceBodyImg;
    private Image destinationBodyImg;
    private Text sourceBodyNameText;
    private Text destinationBodyNameText;
    private Text sateliteNameText;
    SateliteData sateliteDataValue;

    public void SetupInfoButton(SateliteData sateliteData)
    {
        sateliteDataValue = sateliteData;
        GetUIComponents();
        SetUIUsingSateliteData(sateliteData);
    }

    private void SetUIUsingSateliteData(SateliteData sateliteData)
    {
        planetImages = SateliteUIInfoHolder.instance.planetImages;
        planetNames = SateliteUIInfoHolder.instance.planetNames;
        int index = Array.FindIndex(planetNames, name => name.Equals(sateliteData.originPlanet));
        sourceBodyImg.sprite = planetImages[index];
        sourceBodyNameText.text = sateliteData.originPlanet;
        index = Array.FindIndex(planetNames, name => name.Equals(sateliteData.destinationPlanet));
        destinationBodyImg.sprite = planetImages[index];
        destinationBodyNameText.text = sateliteData.destinationPlanet;
        sateliteNameText.text = sateliteData.name;
    }

    private void GetUIComponents()
    {
        sourceBodyImg = transform.GetChild(0).GetComponent<Image>();
        destinationBodyImg = transform.GetChild(1).GetComponent<Image>();
        sourceBodyNameText = sourceBodyImg.transform.GetChild(0).GetComponent<Text>();
        sateliteNameText = transform.GetChild(3).GetComponent<Text>();
        destinationBodyNameText = destinationBodyImg.transform.GetChild(0).GetComponent<Text>();
    }
}
