using System;
using System.Collections.Generic;

[Serializable]
public struct PlanetData 
{
    public PlanetInfoData planetInfo;
    public PopulationInfoData populationInfoData;
    public PlanetResourcesData planetResourcesData;
    public List<PlanetHexagonData> planetHexagons;
}
