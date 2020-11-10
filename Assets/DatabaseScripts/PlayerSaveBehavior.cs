using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class PlayerSaveBehavior : MonoBehaviour
{
    //[SerializeField]
    //TMP_InputField NameText, HealthText;

    [SerializeField]
    Button SavePlayer, LoadPlayer;

    [SerializeField]
    PlayerSaveSystem pSystem;

    PlayerData pData;
    //[SerializeField]
    //TextMeshProUGUI NameTextLoad, HealthTextLoad;
    // Start is called before the first frame update
    void Start()
    {
        SavePlayer.onClick.AddListener(SavePlayerData);
        LoadPlayer.onClick.AddListener(LoadPlayerDataCo);
    }

    public void SavePlayerData()
    {
        StartCoroutine(LoadPlayerData());
        PlayerData pData = new PlayerData();
        if (pData.planets == null)
        {
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
        }
        pSystem.SavePlayer(pData);
    }
    void LoadPlayerDataCo()
    {
        StartCoroutine(LoadPlayerData());
    }
    IEnumerator LoadPlayerData()
    {
        var pDataTask = pSystem.LoadPlayer();
        yield return new WaitUntil(() => pDataTask.IsCompleted);
        var pData = pDataTask.Result;
    }
}
