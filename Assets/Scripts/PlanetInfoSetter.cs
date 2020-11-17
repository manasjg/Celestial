using System.Collections.Generic;
using UnityEngine;

public class PlanetInfoSetter : MonoBehaviour
{

    public List<GameObject> Planets;
    void Start()
    {
        int SelectedPlanetID = PlayerPrefs.GetInt("SelectedPlanet", 0);
        Planets[SelectedPlanetID].SetActive(true);
        PlayerPrefs.SetString("SelectedPlanetName", Planets[SelectedPlanetID].name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
