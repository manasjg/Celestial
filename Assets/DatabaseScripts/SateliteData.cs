using System;

[Serializable]
public struct SateliteData
{
    public string name;
    public string originPlanet;
    public string destinationPlanet;
    public float travelProgress;
    public float buildTime;
    public float travelSpeed;
    public int cost;
    public int storage;
    public float durability;
    public float shieldDuration;
    public float shieldRegen;
}
