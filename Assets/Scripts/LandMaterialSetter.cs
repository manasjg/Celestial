using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMaterialSetter : MonoBehaviour
{

    public Material[] SurfaceMaterials;
  
    // Start is called before the first frame update
    void Start()
    {
        int SelectedPlanetID = PlayerPrefs.GetInt("SelectedPlanet", 0);
        GetComponent<MeshRenderer>().material = SurfaceMaterials[SelectedPlanetID];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
