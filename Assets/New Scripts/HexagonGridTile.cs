using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HexagonGridTileType
{
    Land,
    Water,
    Mountain,
    Ice
    
}

public class HexagonGridTile : MonoBehaviour
{
    public int TileID;
    public HexagonGridTileType TileType;
    public Material[] TileMaterials;
   

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = TileMaterials[(int)TileType];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
