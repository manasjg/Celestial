using UnityEngine;

public enum MegaStructureType
{
    AirExtractor,
    BusinessCenter,
    ChemicalStorage,
    CommandCentre,
    Driller,
    EnergyRepository,
    GreenHouse,
    HabitatHouse,
    HydroPowerPlant,
    FoodStorageRepository,
    MedicalHouse,
    NuclearPowerPlant,
    RocketLauncher,
    SolarPanel,
    TechnoLab,
    WindPlant
}



public class SetupMegaStructuresFromFirebase : MonoBehaviour
{
    HexagonGridSetup gridSetup;
    public GameObject[] MegaStructures;

    private void Awake()
    {
        gridSetup = GetComponent<HexagonGridSetup>();
    }
    public void SetupMegaStructures()
    {
        PlayerData pData = PlayerSaveBehavior.Instance.GetPlayerData();
        for (int i = 0; i < pData.planets.Count; i++)
        {
            if (pData.planets[i].planetInfo.planetName == PlayerPrefs.GetString("SelectedPlanetName", "0"))
            {
                int currHexID = -1;
                int hexID = PlayerPrefs.GetInt("SelectedHexagonID", -1);
                for (int j = 0; j < pData.planets[i].planetHexagons.Count; j++)
                {
                    if (pData.planets[i].planetHexagons[j].hexID == hexID)
                    {
                        currHexID = j;
                        break;
                    }
                }
                if (currHexID != -1)
                {
                    for(int k = 0; k < pData.planets[i].planetHexagons[currHexID].megaStructures.Count; k++)
                    {
                        for(int l = 0; l < MegaStructures.Length; l++)
                        {
                            if(MegaStructures[l].name == pData.planets[i].planetHexagons[currHexID].megaStructures[k].name)
                            {
                                GameObject GO = GameObject.Instantiate(MegaStructures[l]);
                                GO.SetActive(true);
                                GO.transform.position = gridSetup.GetPositionByID(pData.planets[i].planetHexagons[currHexID].megaStructures[k].gridHexID);
                                gridSetup.RemoveTile(GO.transform.position);
                            }
                        }
                    }
                }
                break;
            }
        }
    }
   
}
