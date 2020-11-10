using System;
using System.Collections.Generic;

[Serializable]
public struct PopulationInfoData
{
    public float landscapePopulationCapacity;
    public float population;
    public float peoplePerArea;
    public float birthRate;
    public float deathRate;
    public float survivalRate;
    public float generations;
    public float publicHealth;
    public List<string> mainCausesOfDeath;
    public List<string> otherCausesOfDeath;
}
