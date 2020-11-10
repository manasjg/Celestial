using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshCamFaceScript : MonoBehaviour
{
    GameObject[] TextMeshes;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshes = GameObject.FindGameObjectsWithTag("PlanetText");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        for (int i = 0; i < TextMeshes.Length; i++)
        {
            TextMeshes[i].transform.rotation = Camera.main.transform.rotation;
        }
    }
}
