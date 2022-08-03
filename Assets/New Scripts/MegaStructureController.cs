using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class MegaStructureController : MonoBehaviour
{
    private MegaStructureModel megaStructureModel;
    private MeshRenderer[] structurMeshRenderers;
    Color currColor;

    private void Start()
    {
        megaStructureModel = GetComponent<MegaStructureModel>();
        structurMeshRenderers = GetComponentsInChildren<MeshRenderer>();
        currColor = new Color(1, 1, 1, 0.1f);
        foreach (MeshRenderer structureMeshRenderer in structurMeshRenderers)
        {
            structureMeshRenderer.material.color = currColor;
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            StructureInfoSetter.instance.SetupStructureInfo(megaStructureModel);
        }
    }

    private void Update()
    {
        if (megaStructureModel.megaStructureData.constructionSpeed != 0)
        {
            foreach (MeshRenderer structureMeshRenderer in structurMeshRenderers)
            {
                if (currColor.a < 1)
                {
                    currColor.a += megaStructureModel.megaStructureData.constructionSpeed * Time.deltaTime;
                    structureMeshRenderer.material.SetColor("_Color", currColor);
                }
            }
        }
    }
}
