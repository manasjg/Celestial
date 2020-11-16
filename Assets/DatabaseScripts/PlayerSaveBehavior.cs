using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSaveBehavior : MonoBehaviour
{

    [SerializeField]
    private PlayerSaveSystem pSystem;

    private PlayerData pData;

    void Start()
    {
        SetupFirebaseDatabase();
    }

    public void SavePlayerData(PlayerData pData)
    {
        pSystem.SavePlayer(pData);
    }

    void SetupFirebaseDatabase()
    {
        StartCoroutine(LoadPlayerData());

        if (pData.planets == null)
        {
            pData = new PlayerData();
            pData.planets = new List<PlanetData>();
            PlanetData planetData = new PlanetData();
            planetData.planetInfo.planetName = "Earth";
            planetData.planetHexagons = new List<PlanetHexagonData>();
            PlanetHexagonData currPlanetHexagon = new PlanetHexagonData();
            currPlanetHexagon.megaStructures = new List<MegastructureData>();
            MegastructureData megastructure = new MegastructureData();
            currPlanetHexagon.megaStructures.Add(megastructure);
            planetData.planetHexagons.Add(currPlanetHexagon);
            pData.planets.Add(planetData);
            SavePlayerData(pData);
        }
    }
    void LoadPlayerDataCo()
    {
        StartCoroutine(LoadPlayerData());
    }
    public PlayerData GetPlayerData()
    {
        return pData;
    }

    IEnumerator LoadPlayerData()
    {
        var pDataTask = pSystem.LoadPlayer();
        yield return new WaitUntil(() => pDataTask.IsCompleted);
        pData = pDataTask.Result;
    }
}
