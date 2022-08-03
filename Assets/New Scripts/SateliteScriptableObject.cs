using UnityEngine;

[CreateAssetMenu(fileName = "SateliteData", menuName = "ScriptableObjects/SateliteScriptableObject", order = 1)]
public class SateliteScriptableObject : ScriptableObject
{
    public SateliteType SateliteType;
    public string NameText;
    public string Description;
    public int ChemicalCost = 10;
    public int CashCost = 400;
    public int BuildTime = 10;
}
