using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaStructurePanelDisplay : MonoBehaviour
{
    public Text StructureDescription;
    public Text TechnologyRequired;
    public Text EnergyRequired ;
    public Text FoodCost ;
    public Text ChemicalCost ;
    public Text CashCost ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplaySturctureInfo(MegaStructureSciptableObject StructureInfo)
    {
        StructureDescription.text = StructureInfo.Description;
        TechnologyRequired.text = StructureInfo.TechnologyRequired.ToString();
        EnergyRequired.text = StructureInfo.EnergyRequired.ToString();
        FoodCost.text = StructureInfo.FoodCost.ToString();
        ChemicalCost.text = StructureInfo.ChemicalCost.ToString();
        CashCost.text = StructureInfo.CashCost.ToString();
    }
}
