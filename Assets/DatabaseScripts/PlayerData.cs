using System;
using System.Collections.Generic;

[Serializable]
public struct PlayerData 
{
    public int cash;
    public int food;
    public int tech;
    public int chemicals;
    public int energy;
    public int evolution;
    public int sateliteBuildNumber;
    public int sateliteBuildTime;
    public List<PlanetData> planets;
    public PlayerSatelites satelites;
}
