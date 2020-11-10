using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRevolver : MonoBehaviour
{

   public float alpha = 0f;
    public float semiMajor;
    public float semiMinor;
    public GameObject Sun;
    public bool startRevolving=true;
    public float revSpeed = 5;
    public bool isTidallyLocked = false;
    public float rotateSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Vector3.Distance(transform.position, Sun.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        if (startRevolving)
        {
            transform.position = new Vector3(Sun.transform.position.x + (semiMajor * Mathf.Sin(Mathf.Deg2Rad * alpha)), 0,
                                         Sun.transform.position.z + (semiMinor * Mathf.Cos(Mathf.Deg2Rad * alpha)));
            alpha += revSpeed * Time.deltaTime;//can be used as speed
            if (!isTidallyLocked)
            {
                transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.LookAt(Sun.transform.position);
            }
        }
       
    }
}
