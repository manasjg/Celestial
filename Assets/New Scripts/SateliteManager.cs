using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteManager : MonoBehaviour
{
    public GameObject[] SateliteObjects;
    public static SateliteManager Instance;
    SateliteData localSateliteData;
    public GameObject remoteSatelite;
    public GameObject transportSatelite;
    public GameObject spaceShip;
    public GameObject[] planetsForSatelites;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetupSatelites()
    {
        PlayerData pData = PlayerSaveBehavior.Instance.GetPlayerData();
        for(int i = 0; i < pData.satelites.remoteControlSatelites.Count; i++)
        {
            GameObject remoteControlSatelite = GameObject.Instantiate(remoteSatelite);
            for(int j = 0; j < planetsForSatelites.Length; j++)
            {
                GameObject satelitePlanet = planetsForSatelites[j];
                if (satelitePlanet.name == pData.satelites.remoteControlSatelites[i].originPlanet)
                {
                    remoteSatelite.GetComponent<SateliteLaunch>().LaunchPosGO = satelitePlanet.transform.Find("LaunchPos").gameObject;
                }
                if (satelitePlanet.name == pData.satelites.remoteControlSatelites[i].destinationPlanet)
                {
                    remoteSatelite.GetComponent<SateliteLaunch>().LandPosGO = satelitePlanet.transform.Find("LandPos").gameObject;
                }
            }
            
        }
    }
}
