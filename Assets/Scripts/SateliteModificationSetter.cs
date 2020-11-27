using UnityEngine.UI;
using UnityEngine;
using System;

public class SateliteModificationSetter : MonoBehaviour
{
    private Sprite[] planetImages;
    private string[] planetNames;
    public Image sourceBodyImg;
    public Image destinationBodyImg;
    public Text sourceBodyNameText;
    public Text destinationBodyNameText;
    public Text sateliteNameText;
    public Text sateliteDistanceText;
    public Text sateliteTimeText;
    SateliteData sateliteDataValue;

    public void SetModificationPanel(SateliteData sateliteData)
    {
        sateliteDataValue = sateliteData;
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
        sateliteDistanceText.text = "DISTANCE : " + sateliteData.travelProgress.ToString();
        sateliteTimeText.text = "TIME : " + sateliteData.travelSpeed.ToString();
    }
}
