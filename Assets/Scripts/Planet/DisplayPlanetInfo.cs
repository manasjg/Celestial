using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlanetInfo : MonoBehaviour 
{
	public MarsData dat;
	public Text PlanetName;
	public Text RotationSpeed,RevolutionSpeed;
	public Text DayNightTemp;
	public Text SurfaceArea;
	public Text Gravity;
	public Text LengthofDay,LengthofYear;
	public Text Habitability,Hostility;
	public Text DistancefromSun;
	public Text AtmosphericComp;
    public Text LandScapePopulation;
    public Text Population;
    public Text PeoplePerArea;
    public Text BirthRate;
    public Text DeathRate;
    public Text SurvivalRate;
    public Text Generations;
    public Text MainCausesOfHealth;
    public Text MarsContributionToEnergy;
    public Text MarsContributionToTechnology;
    public Text EnergyHarnessed;
    public Text NoOfStructures;
    public Text EnergyUtility;
    public Text EnergyStructuresBuilt;
    public Text FoodProducedAndUtility;
    public Text FoodStructuresBuilt;
    public Text ChemicalsExtracted;
    public Text ChemicalStructuresBuilt;
    public Text TotalNoOfUpgrades;
    public Text TotalNoOfResearches;

	void Awake()
	{
		dat = GameObject.Find ("Canvas").GetComponent<MarsData> ();
	}
	void Start () 
	{
		StartCoroutine(PlanetBasicInfo());
	}
	
	IEnumerator PlanetBasicInfo()
	{
		yield return new WaitForSeconds (2);
		PlanetName.text = "Name: Mars";
		RotationSpeed.text = "Rotation Speed: "+dat.rotationspeed.ToString();
		RevolutionSpeed.text = "Revolution Speed: "+dat.revolutionspeed.ToString()+" km/hr";
		DayNightTemp.text = "Day Temp.: " + dat.daytemp.ToString () + "°C"+"   Night Temp.: " + dat.nighttemp.ToString ()+"°C";
		SurfaceArea.text = "Surface Area: "+dat.surfacearea.ToString()+" million sq. km";
		Gravity.text = "Gravity: " + dat.gravity.ToString () + " m/s²";
		LengthofDay.text = "Length of day & night: "+dat.lengthofday.ToString()+" earth days each";
		LengthofYear.text = "Length of year: "+dat.lengthofyear.ToString()+" earth year";
		Habitability.text = "Habitability: " + dat.habitability.ToString () + " %";
		Hostility.text = "Hostility: " + dat.hostility.ToString () + " %";
		DistancefromSun.text = "Distance from sun: " + dat.distancefromsun.ToString () + " million km";
		AtmosphericComp.text = "Atmospheric Composition: " + dat.atmosphericcomposition;
        LandScapePopulation.text = "Landscape population capacity: " + dat.landscapepopulation;
        Population.text = "Population: " + dat.population;
        PeoplePerArea.text = "People Per Area: " + dat.peopleperarea;
        BirthRate.text = "Birth Rate: " + "Low";
        DeathRate.text = "Death Rate: " + "Med";
        SurvivalRate.text = "Survival Rate: " + "Low";
        Generations.text = "Generations: " + dat.generations;
        MainCausesOfHealth.text = "Main causes of death: " + "Weather";
        MarsContributionToEnergy.text = "Contribution to total energy requirement: " + dat.contributionToTotalEnergy;
        MarsContributionToTechnology.text = "Contribution to total technology requirement(&): " + dat.contributionToTotalTechnology;
        EnergyHarnessed.text = "Energy harnessed(%): " + dat.energyHarnessed;
        NoOfStructures.text = "Total no. of Structures: " + dat.noofstructures;
        EnergyUtility.text = "Energy Utility: " + dat.energyutility;
        EnergyStructuresBuilt.text = "Energy Structures Built: " + dat.energystructuresbuilt;
        FoodProducedAndUtility.text = "Food Produced: " + dat.foodproduced + "/t" + "Food Utility: " + dat.foodutilised;
        FoodStructuresBuilt.text = "Food Structures Built: " + dat.foodstructuresbuilt;
        ChemicalsExtracted.text = "Chemicals Extracted: " + dat.chemicalsextracted;
        ChemicalStructuresBuilt.text = "Chemical structures built: " + dat.chemicalstructuresbuilt;
        TotalNoOfUpgrades.text = "Total No. of upgrades: " + dat.totalupgrades;
        TotalNoOfResearches.text = "Total No. of Researches: " + dat.totalresearches; 
    }
	void Update () 
	{
		
	}
}
