using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRevolver : MonoBehaviour
{

    public float alpha = 0f;
    public float semiMajor;
    public float semiMinor;
    public GameObject sun;
    public bool startRevolving=true;
    public float revSpeed = 5;
    public bool isTidallyLocked = false;
    public float rotateSpeed = 20;
   

    void Update()
    {
        if (startRevolving)
        {
            transform.position = new Vector3(sun.transform.position.x + (semiMajor * Mathf.Sin(Mathf.Deg2Rad * alpha)), 0,
                                         sun.transform.position.z + (semiMinor * Mathf.Cos(Mathf.Deg2Rad * alpha)));
            alpha += revSpeed * Time.deltaTime;//can be used as speed
            if (!isTidallyLocked)
            {
                transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.LookAt(sun.transform.position);
            }
        }
       
    }
}
