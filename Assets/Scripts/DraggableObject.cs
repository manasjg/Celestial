﻿using System.Collections;
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
                            int hexID = HGSetup.RemoveTile(MegaStructure.transform.position);
                            MegaStructureSetup(GO, hexID);
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
                                int gridHexID = HGSetup.RemoveTile(MegaStructure.transform.position);
                                canBuild = true;
                                MegaStructureSetup(GO, gridHexID);
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

    private void MegaStructureSetup(GameObject megaStructureGO, int gridHexID)
    {
        int hexID = PlayerPrefs.GetInt("SelectedHexagonID", -1);
        megaStructureGO.AddComponent<MegaStructureModel>();
        megaStructureGO.GetComponent<MegaStructureModel>().megaStructureData.gridHexID = gridHexID;
        megaStructureGO.GetComponent<MegaStructureModel>().megaStructureData.name = MegaStructure.name;
        megaStructureGO.AddComponent<MegaStructureController>();
        PlayerData pData = PlayerSaveBehavior.Instance.GetPlayerData();
        AddMegaStructureToPlanetData(pData, hexID,gridHexID);
    }

    private void AddMegaStructureToPlanetData(PlayerData pData, int hexID,int gridHexID)
    {
        for (int i = 0; i < pData.planets.Count; i++)
        {
            if (pData.planets[i].planetInfo.planetName == PlayerPrefs.GetString("SelectedPlanetName", "0"))
            {
                int currHexID = -1;
                for (int j = 0; j < pData.planets[i].planetHexagons.Count; j++)
                {
                    if (pData.planets[i].planetHexagons[j].hexID == hexID)
                    {
                        currHexID = j;
                        break;
                    }
                }
                if (currHexID != -1)
                {
                    if (pData.planets[i].planetHexagons[currHexID].megaStructures[0].gridHexID == -1)
                    {
                        MegastructureData structureDataTemp = pData.planets[i].planetHexagons[currHexID].megaStructures[0];
                        structureDataTemp.gridHexID = gridHexID;
                        structureDataTemp.name = MegaStructure.name;
                        pData.planets[i].planetHexagons[currHexID].megaStructures[0] = structureDataTemp;
                        PlayerData pDataTemp = pData;
                        PlayerSaveBehavior.Instance.SavePlayerData(pDataTemp);
                    }
                    else
                    {
                        MegastructureData structureDataTemp = new MegastructureData();
                        structureDataTemp.gridHexID = gridHexID;
                        structureDataTemp.name = MegaStructure.name;
                        pData.planets[i].planetHexagons[currHexID].megaStructures.Add(structureDataTemp);
                        PlayerData pDataTemp = pData;
                        PlayerSaveBehavior.Instance.SavePlayerData(pDataTemp);
                    }
                }
            }
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MegaStructureDisplay.DisplaySturctureInfo(StructureData);
    }
}
