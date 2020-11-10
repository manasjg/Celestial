using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBeltRotator : MonoBehaviour
{
    public float rotateSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, rotateSpeed * Time.deltaTime);
    }
}
