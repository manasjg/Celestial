using UnityEngine;
using System.Collections;

public class RotateCoin : MonoBehaviour {

	public float RotateSpeed;
    public bool RotateAroundYAxis = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!RotateAroundYAxis)
        {
            transform.Rotate(RotateSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
        }
	}
	
	
}