using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsData : MonoBehaviour 
{
    public static string PlanetName = "Mars";
    public float rotationspeed;
    public float revolutionspeed;
    public float daytemp;
    public float nighttemp;
    public float surfacearea;
    public float gravity;
    public float lengthofday;
    public float lengthofyear;
    public int habitability;
    public int hostility;
	public float distancefromsun;
    public string atmosphericcomposition;
    public int landscapepopulation;
    public int population;
    public int peopleperarea;
    public int birthrate;
    public int deathrate;
    public int survivalrate;
    public int generations;
    public string maincauseofhealth;
    public int contributionToTotalEnergy;
    public int contributionToTotalTechnology;
    public int energyHarnessed;
    public int noofstructures;
    public int energyutility;
    public int energystructuresbuilt;
    public int foodproduced;
    public int foodutilised;
    public int foodstructuresbuilt;
    public int chemicalsextracted;
    public int chemicalstructuresbuilt;
    public int corrosionlevels;
    public int totalupgrades;
    public int totalresearches;



    void Start () 
	{
		if (PlayerPrefs.HasKey ("MarsData")) 
		{
            rotationspeed = 1.039f;
			revolutionspeed = 86871f;
            daytemp = 20;
            nighttemp = -73;
            surfacearea = 144.8f;
            gravity = 3.711f;
            lengthofday = 1.040f;
            lengthofyear = 1.88f;
			distancefromsun = 227.9f;
            habitability = PlayerPrefs.GetInt("MarsHabitability");
            hostility = PlayerPrefs.GetInt("MarsHostility");
            atmosphericcomposition = "Carbon dioxide, Nitrogen, Argon, Oxygen, Carbon monoxide, Minor amounts of: water, nitrogen oxide, neon, hydrogen-deuterium-oxygen, krypton and xenon .";
            landscapepopulation = 500;
            population = PlayerPrefs.GetInt("MarsPopulation");
            peopleperarea = PlayerPrefs.GetInt("MarsPeoplePerArea");
            birthrate = PlayerPrefs.GetInt("MarsBirthrate");
            deathrate = PlayerPrefs.GetInt("MarsDeathrate");
            survivalrate = PlayerPrefs.GetInt("MarsSurvivalrate");
            generations = PlayerPrefs.GetInt("MarsGenerations");
            maincauseofhealth = "weather";
            contributionToTotalEnergy = PlayerPrefs.GetInt("MarsContributionToEnergy");
            contributionToTotalTechnology = PlayerPrefs.GetInt("MarsContributionToTechnology");
            energyHarnessed = PlayerPrefs.GetInt("MarsEnergyHarnessed");
            noofstructures = PlayerPrefs.GetInt("MarsNoOfStructures");
            energyutility = PlayerPrefs.GetInt("MarsEnergyUtilised");
            energystructuresbuilt = PlayerPrefs.GetInt("MarsEnergyStructuresBuilt");
            foodproduced = PlayerPrefs.GetInt("MarsFoodProduced");
            foodutilised = PlayerPrefs.GetInt("MarsFoodUtilised");
            foodstructuresbuilt = PlayerPrefs.GetInt("MarsFoodStructuresBuilt");
            chemicalsextracted = PlayerPrefs.GetInt("MarsChemicalsExtracted");
            chemicalstructuresbuilt = PlayerPrefs.GetInt("MarsChemicalStructuresBuilt");
            corrosionlevels = PlayerPrefs.GetInt("MarsCorrosionLevels");
            totalupgrades = PlayerPrefs.GetInt("MarsTotalUpgrades");
            totalresearches = PlayerPrefs.GetInt("MarsTotalResearches");
        } 
		else 
		{
            PlayerPrefs.SetInt("MarsData", 1);
            PlayerPrefs.SetInt("MarsCash", 0);
            PlayerPrefs.SetInt("MarsFood", 0);
            PlayerPrefs.SetInt("MarsChemical", 0);
            PlayerPrefs.SetInt("MarsTechnology", 0);
            PlayerPrefs.SetInt("MarsEnergy", 0);

            rotationspeed = 1.039f;
			revolutionspeed = 86871f;
            daytemp = 20;
            nighttemp = -73;
            surfacearea = 144.8f;
            gravity = 3.711f;
            lengthofday = 1.040f;
            lengthofyear = 1.88f;
            habitability = 28;
			distancefromsun = 227.9f;
            PlayerPrefs.SetInt("MarsHabitability", habitability);
            hostility = 72;
            PlayerPrefs.SetInt("MarsHostility", hostility);
            atmosphericcomposition = "Carbon dioxide, Nitrogen, Argon, Oxygen, Carbon monoxide, Minor amounts of: water, nitrogen oxide, neon, hydrogen-deuterium-oxygen, krypton and xenon";
            landscapepopulation = 500;
            population = 0;
            PlayerPrefs.SetInt("MarsPopulation", population);
            peopleperarea = 0;
            PlayerPrefs.SetInt("MarsPeoplePerArea", peopleperarea);
            birthrate = 0;
            PlayerPrefs.SetInt("MarsBirthrate", birthrate);
            deathrate = 0;
            PlayerPrefs.SetInt("MarsDeathrate", deathrate);
            survivalrate = 0; // low,med,high
            PlayerPrefs.SetInt("MarsSurvivalrate", survivalrate);
            generations = 1;
            PlayerPrefs.SetInt("MarsGenerations", generations);
            maincauseofhealth = "weather";
            contributionToTotalEnergy = 0;
            PlayerPrefs.SetInt("MarsContributionToEnergy", contributionToTotalEnergy);
            contributionToTotalTechnology = 0;
            PlayerPrefs.SetInt("MarsContributionToTechnology", contributionToTotalEnergy);
            energyHarnessed = 0;
            PlayerPrefs.SetInt("MarsEnergyHarnessed", energyHarnessed);
            noofstructures = 0;
            PlayerPrefs.SetInt("MarsNoOfStructures", noofstructures);
            energyutility = 0;
            PlayerPrefs.SetInt("MarsEnergyUtilised", energyutility);
            energystructuresbuilt = 0;
            PlayerPrefs.SetInt("MarsEnergyStructuresBuilt", energystructuresbuilt);
            foodproduced = 0;
            PlayerPrefs.SetInt("MarsFoodProduced", foodproduced);
            foodutilised = 0;
            PlayerPrefs.SetInt("MarsFoodUtilised", foodutilised);
            foodstructuresbuilt = 0;
            PlayerPrefs.SetInt("MarsFoodStructuresBuilt", foodstructuresbuilt);
            chemicalsextracted = 0;
            PlayerPrefs.SetInt("MarsChemicalsExtracted", chemicalsextracted);
            chemicalstructuresbuilt = 0;
            PlayerPrefs.SetInt("MarsChemicalStructuresBuilt", chemicalstructuresbuilt);
            corrosionlevels = 0;
            PlayerPrefs.SetInt("MarsCorrosionLevels", corrosionlevels);
            totalupgrades = 0;
            PlayerPrefs.SetInt("MarsTotalUpgrades", totalupgrades);
            totalresearches = 0;
            PlayerPrefs.SetInt("MarsTotalResearches", totalresearches);

        }
	}
}
