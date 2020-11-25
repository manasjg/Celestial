using System;
using System.Collections.Generic;

[Serializable]
public struct PlayerSatelites
{
    public List<SateliteData> remoteControlSatelites;
    public List<SateliteData> transportSatelites;
    public List<SateliteData> spaceships;
}
