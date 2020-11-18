using UnityEngine;
using System.Collections.Generic;

public class PlanetHexagonClick : MonoBehaviour
{
    GameObject FadePanel;
    public int hexID;
    // Start is called before the first frame update
    private void Start()
    {
        FadePanel = GameObject.Find("FadePanel");
    }

    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("SelectedHexagonID", hexID);
        PlayerData pData =  PlayerSaveBehavior.Instance.GetPlayerData();
        SaveHexagonData(pData);
        FadePanel.GetComponent<PanelFadeScript>().SetFade();
    }

    private void SaveHexagonData(PlayerData pData)
    {
        for (int i = 0; i < pData.planets.Count; i++)
        {
            if (pData.planets[i].planetInfo.planetName == PlayerPrefs.GetString("SelectedPlanetName", "0"))
            {
                bool foundHex = false;
                for (int j = 0; j < pData.planets[i].planetHexagons.Count; j++)
                {
                    if (pData.planets[i].planetHexagons[j].hexID == hexID)
                    {
                        foundHex = true;
                        break;
                    }
                }
                if (!foundHex)
                {
                    if (pData.planets[i].planetHexagons[0].hexID == -1)
                    {
                        PlanetHexagonData hexDataTemp = pData.planets[i].planetHexagons[0];
                        hexDataTemp.hexID = hexID;
                        PlayerData pDataTemp = pData;
                        pDataTemp.planets[i].planetHexagons[0] = hexDataTemp;
                        PlayerSaveBehavior.Instance.SavePlayerData(pDataTemp);
                    }
                    else
                    {
                        PlanetHexagonData hexDataTemp = new PlanetHexagonData();
                        hexDataTemp.hexID = hexID;
                        hexDataTemp.megaStructures = new List<MegastructureData>();
                        MegastructureData megastructure = new MegastructureData();
                        megastructure.gridHexID = -1;
                        hexDataTemp.megaStructures.Add(megastructure);
                        PlayerData pDataTemp = pData;
                        pDataTemp.planets[i].planetHexagons.Add(hexDataTemp);
                        PlayerSaveBehavior.Instance.SavePlayerData(pDataTemp);
                    }
                }
            }
        }
    }
}
