using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MegaStructureData", menuName = "ScriptableObjects/MegaStructureScriptableObject", order = 1)]
public class MegaStructureSciptableObject : ScriptableObject
{
    public MegaStructureType StructureType;
    public string Description;
    public int TechnologyRequired=100;
    public int EnergyRequired = 200;
    public int FoodCost = 50;
    public int ChemicalCost = 10;
    public int CashCost =400;
    public float ConstructionSpeed = 0.01f;
    public HexagonGridTileType[] TileTypeRequired;
    public MegaStructureType[] BuildingsRequired;
}
