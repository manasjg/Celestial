using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfoSetter : MonoBehaviour
{

    public List<GameObject> Planets;
    // Start is called before the first frame update
    void Start()
    {
        int SelectedPlanetID = PlayerPrefs.GetInt("SelectedPlanet",0);
        Planets[SelectedPlanetID].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
