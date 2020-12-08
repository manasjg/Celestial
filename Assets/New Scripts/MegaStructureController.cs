using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class MegaStructureController : MonoBehaviour
{
    private MegaStructureModel megaStructureModel;
   
    private void Start()
    {
        megaStructureModel = GetComponent<MegaStructureModel>();
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            StructureInfoSetter.instance.SetupStructureInfo(megaStructureModel);
        }
    }
}
