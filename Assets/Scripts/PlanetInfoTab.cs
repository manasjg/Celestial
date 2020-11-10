using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfoTab : MonoBehaviour 
{
	public GameObject Line1_PlanetInfo;
	public GameObject Line2_1_Population, Line2_2_Population;
	public GameObject Line3_ResourcesInfo;
	public GameObject PlanetInfoMask, PopulationInfoMask, ResourcesInfoMask;

	void Start ()
	{
		
	}
	

	void Update () 
	{
		
	}
	public void SwitchallMasks()
	{
		PlanetInfoMask.SetActive (false);
		PopulationInfoMask.SetActive (false);
		ResourcesInfoMask.SetActive (false);
	}
	public void PlanetInfo()
	{
		Line1_PlanetInfo.SetActive (true);
		Line2_1_Population.SetActive (false);
		Line2_2_Population.SetActive (false);
		Line3_ResourcesInfo.SetActive (false);
		SwitchallMasks ();
		PlanetInfoMask.SetActive (true);
	}

	public void PopulationInfo()
	{
		Line1_PlanetInfo.SetActive (false);
		Line2_1_Population.SetActive (true);
		Line2_2_Population.SetActive (true);
		Line3_ResourcesInfo.SetActive (false);
		SwitchallMasks ();
		PopulationInfoMask.SetActive (true);
	}

	public void ResourcesInfo()
	{
		Line1_PlanetInfo.SetActive (false);
		Line2_1_Population.SetActive (false);
		Line2_2_Population.SetActive (false);
		Line3_ResourcesInfo.SetActive (true);
		SwitchallMasks ();
		ResourcesInfoMask.SetActive (true);
	}
}
