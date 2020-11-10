using System.Collections;
using UnityEngine;

public class MarsSciFiAnim : MonoBehaviour 
{

    GameObject ScanRing1;
    GameObject ScanRing2;
    void Start () 
	{
        Time.timeScale = 1.0f;
        ScanRing1 = GameObject.Find("ScanRing1");
        ScanRing2 = GameObject.Find("ScanRing2");
        StartCoroutine (Anim ());
	}
	IEnumerator Anim()
	{
		yield return new WaitForSeconds (1.5f);
        ScanRing1.SetActive (true);
        ScanRing2.SetActive (true);
		yield return new WaitForSeconds (5f);
        ScanRing1.SetActive(false);
        ScanRing2.SetActive(false);
        gameObject.transform.GetChild (0).gameObject.SetActive (true);
		gameObject.GetComponent<RotateCoin> ().enabled = false;
        GameObject.Find("Canvas").GetComponent<PlanetInfoTab>().PlanetInfo();
      //  GameObject.Find("Canvas").GetComponent<PlanetInfoTab>().PopulationInfoMask.transform.GetChild(0).gameObject.SetActive(true);
       // GameObject.Find("Canvas").GetComponent<PlanetInfoTab>().ResourcesInfoMask.transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("LoadingImage").gameObject.SetActive(false);
        //		gameObject.transform.parent.GetChild (1).gameObject.GetComponent<Animator>().enabled = false;
        //		gameObject.transform.parent.GetChild (2).gameObject.GetComponent<Animator>().enabled = false;
    }

}
