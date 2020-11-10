using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public MegaStructureSciptableObject StructureData;
    public ScrollRect SRect;
    bool _isScrolling = false;
    public RectTransform MegaStructureRect;
    public GameObject MegaStructure;
    public GameObject HexagonTile;
    public MegaStructurePanelDisplay MegaStructureDisplay;
    HexagonGridSetup HGSetup;
    private void Start()
    {
        HGSetup = HexagonTile.GetComponent<HexagonGridSetup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (SRect != null && eventData.delta.normalized.y < 0.5f)
        {
            _isScrolling = true;
            SRect.SendMessage("OnBeginDrag", eventData);
            return;
        }
        else
        {
            _isScrolling = false;
            HexagonTile.SetActive(true);
        }

        // MegaStructure = Instantiate(MegaStructurePrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        //draggable.itemDragged = MegaStructure;
        //draggable.itemDragged = gameObject;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //  MegaStructure.transform.position = eventData.position;
        if (!_isScrolling)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit");
                // Transform objectHit = hit.transform;
                if (hit.transform.tag == "Land")
                {
                    MegaStructureRect.anchoredPosition = new Vector2(MegaStructureRect.anchoredPosition.x, 25);
                    MegaStructure.SetActive(true);
                    Vector3 Pos = hit.point;
                    MegaStructure.transform.position = new Vector3(hit.point.x, MegaStructure.transform.position.y, hit.point.z);
                    MegaStructure.transform.position = HGSetup.HighlightGridTile(MegaStructure.transform.position);
                    if (StructureData.TileTypeRequired.Length == 1)
                    {
                        HGSetup.CanBuildOverThisTile(StructureData.TileTypeRequired[0]);
                    }
                    else
                    {
                        for (int i = 0; i < StructureData.TileTypeRequired.Length; i++)
                        {
                            if (HGSetup.CanBuildOverThisTile(StructureData.TileTypeRequired[i]))
                            {
                                break;
                            }
                        }
                    }
                }
                // Do something with the object that was hit by the raycast.
            }
        }
        else
        {
            SRect.SendMessage("OnDrag", eventData);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isScrolling)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // Transform objectHit = hit.transform;
                if (hit.transform.tag == "Land")
                {
                    MegaStructureRect.anchoredPosition = new Vector2(MegaStructureRect.anchoredPosition.x, 300);

                    GameObject GO = GameObject.Instantiate(MegaStructure);
                    GO.transform.position = MegaStructure.transform.position;

                    MegaStructure.SetActive(false);

                    HexagonTile.SetActive(false);
                    if (StructureData.TileTypeRequired.Length == 1)
                    {
                        if (HGSetup.CanBuildOverThisTile(StructureData.TileTypeRequired[0]))
                        {
                            HGSetup.RemoveTile(MegaStructure.transform.position);
                        }
                        else
                        {
                            HGSetup.ResetTiles();
                            Destroy(GO);
                        }
                    }
                    else
                    {
                        bool canBuild = false;
                        for (int i = 0; i < StructureData.TileTypeRequired.Length; i++)
                        {
                            if (HGSetup.CanBuildOverThisTile(StructureData.TileTypeRequired[i]))
                            {
                                HGSetup.RemoveTile(MegaStructure.transform.position);
                                canBuild = true;
                            }
                        }
                        if (!canBuild)
                        {
                            HGSetup.ResetTiles();
                            Destroy(GO);
                        }
                    }

                }
                // Do something with the object that was hit by the raycast.
            }
        }
        else
        {
            SRect.SendMessage("OnEndDrag", eventData);
        }
        _isScrolling = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MegaStructureDisplay.DisplaySturctureInfo(StructureData);
    }
}
