using UnityEngine;
using System.Collections.Generic;

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



public class MegaStructureManager : MonoBehaviour
{
    HexagonGridSetup gridSetup;
    public GameObject[] MegaStructures;
    public static MegaStructureManager Instance;
    public bool hasCommandCentre = false;

    List<MegaStructureModel> megaStructureModels;

    private void Awake()
    {
        gridSetup = GetComponent<HexagonGridSetup>();
        megaStructureModels = new List<MegaStructureModel>();
        if (Instance == null)
        {
            Instance = this;
        }
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
                    }
                }
                if (currHexID != -1)
                {
                    for (int k = 0; k < pData.planets[i].planetHexagons[currHexID].megaStructures.Count; k++)
                    {
                        for (int l = 0; l < MegaStructures.Length; l++)
                        {
                            if (MegaStructures[l].name == pData.planets[i].planetHexagons[currHexID].megaStructures[k].name)
                            {
                                GameObject GO = GameObject.Instantiate(MegaStructures[l]);
                                GO.SetActive(true);
                                MegastructureData structureData = pData.planets[i].planetHexagons[currHexID].megaStructures[k];
                                GO.transform.position = gridSetup.GetPositionByID(structureData.gridHexID);
                                gridSetup.RemoveTile(GO.transform.position);
                                MegaStructureModel model = GO.AddComponent<MegaStructureModel>();
                                model.megaStructureData.gridHexID = structureData.gridHexID;
                                model.megaStructureData.name = structureData.name;
                                model.megaStructureData.structureType = structureData.structureType;
                                AddStructureToList(model);
                                GO.AddComponent<MegaStructureController>();
                            }
                        }
                    }
                }
                break;
            }
        }
        hasCommandCentre = CheckIfPlanetHasMegaStructure(MegaStructureType.CommandCentre);
    }

    public void AddStructureToList(MegaStructureModel megaStructureModel)
    {
        megaStructureModels.Add(megaStructureModel);
        if (megaStructureModel.megaStructureData.structureType == MegaStructureType.CommandCentre)
        {
            hasCommandCentre = true;
        }
    }

    public bool CheckIfPlanetHasMegaStructure(MegaStructureType structureType)
    {
        PlayerData pData = PlayerSaveBehavior.Instance.GetPlayerData();
        for (int i = 0; i < pData.planets.Count; i++)
        {
            if (pData.planets[i].planetInfo.planetName == PlayerPrefs.GetString("SelectedPlanetName", "0"))
            {
                int hexID = PlayerPrefs.GetInt("SelectedHexagonID", -1);
                for (int j = 0; j < pData.planets[i].planetHexagons.Count; j++)
                {
                    for (int k = 0; k < pData.planets[i].planetHexagons[j].megaStructures.Count; k++)
                    {
                        if (pData.planets[i].planetHexagons[j].megaStructures[k].structureType == structureType)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    public bool CheckIfPlanetHasFollowingMegaStructures(MegaStructureType[] structureTypes) 
    {
        for(int i = 0; i < structureTypes.Length; i++)
        {
            if (!CheckIfPlanetHasMegaStructure(structureTypes[i]))
            {
                return false;
            }
        }
        return true;
    }
}
