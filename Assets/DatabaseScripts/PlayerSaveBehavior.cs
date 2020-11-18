using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSaveBehavior : MonoBehaviour
{

    [SerializeField]
    private PlayerSaveSystem pSystem;

    private PlayerData pData;

    private static PlayerSaveBehavior instance;
    public static PlayerSaveBehavior Instance { get { return instance; } }

    void Start()
    {
       StartCoroutine( SetupFirebaseDatabase());
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
       
    }

    public void SavePlayerData(PlayerData pDataNew)
    {
        pSystem.SavePlayer(pDataNew);
        pData = pDataNew;
    }

    IEnumerator SetupFirebaseDatabase()
    {
       yield return  StartCoroutine(LoadPlayerData());

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
            megastructure.gridHexID = -1;
            currPlanetHexagon.megaStructures.Add(megastructure);
            currPlanetHexagon.hexID = -1;
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
