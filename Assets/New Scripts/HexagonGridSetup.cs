﻿using System.Collections.Generic;
using UnityEngine;

public class HexagonGridSetup : MonoBehaviour
{
    List<GameObject> HexagonTiles = new List<GameObject>();
    int index = -1;
    public Material[] TileMaterials;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject GO in GameObject.FindGameObjectsWithTag("HexagonTile"))
        {
            HexagonTiles.Add(GO);
            GO.SetActive(false);
        }

    }



    public Vector3 HighlightGridTile(Vector3 pos)
    {
        float Dist = 2000;
        index = -1;
        int HighlightedTileInd = -1;
        Vector3 FinalTilePos = Vector3.zero;
        for (int i = 0; i < HexagonTiles.Count; i++)
        {

            Vector3 TilePos = HexagonTiles[i].transform.position;
            float TileDist = Vector3.Distance(pos, TilePos);
            if (TileDist < Dist)
            {
                Dist = TileDist;
                HighlightedTileInd = HexagonTiles[i].GetComponent<HexagonGridTile>().TileID;
                index = i;
                FinalTilePos = TilePos;
            }
        }
        transform.position = FinalTilePos;

        int HighLightedTileUp = HighlightedTileInd - 11;
        int HighLightedTileDown = HighlightedTileInd + 11;
        int HighLightedTileLeft1 = HighlightedTileInd - 6;
        int HighLightedTileLeft2 = HighlightedTileInd + 5;
        int HighLightedTileRight1 = HighlightedTileInd - 5;
        int HighLightedTileRight2 = HighlightedTileInd + 6;

        for (int i = 0; i < HexagonTiles.Count; i++)
        {

            if (((HexagonTiles[i].GetComponent<HexagonGridTile>().TileID == HighLightedTileUp)
                || (HexagonTiles[i].GetComponent<HexagonGridTile>().TileID == HighLightedTileDown)
                || (HexagonTiles[i].GetComponent<HexagonGridTile>().TileID == HighLightedTileLeft1)
                || (HexagonTiles[i].GetComponent<HexagonGridTile>().TileID == HighLightedTileLeft2)
                || (HexagonTiles[i].GetComponent<HexagonGridTile>().TileID == HighLightedTileRight1)
                || (HexagonTiles[i].GetComponent<HexagonGridTile>().TileID == HighLightedTileRight2))
                && (Mathf.Abs(HexagonTiles[i].transform.position.x - transform.position.x) < 0.2f))
            {
                HexagonTiles[i].SetActive(true);
            }
            else
            {
                HexagonTiles[i].SetActive(false);
            }
        }

        return FinalTilePos;
    }

    public void RemoveTile(Vector3 Tile)
    {
        ResetTiles();
        for (int i = 0; i < HexagonTiles.Count; i++)
        {
            if (HexagonTiles[i].transform.position == Tile)
            {
                HexagonTiles.RemoveAt(i);
                break;
            }
        }
    }

    public void ResetTiles()
    {
        for (int i = 0; i < HexagonTiles.Count; i++)

        {
            HexagonTiles[i].SetActive(false);
        }

    }

    public bool CanBuildOverThisTile(HexagonGridTileType HType)
    {
        if (HexagonTiles[index].GetComponent<HexagonGridTile>().TileType == HType)
        {
            GetComponent<Renderer>().material = TileMaterials[(int)HType];
            return true;
        }
        else
        {
            GetComponent<Renderer>().material = TileMaterials[4];
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}