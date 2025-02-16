using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmingSystem : MonoBehaviour
{
    public GameObject playerObject;
    public Tilemap farmTilemap;
    public TileBase[] growthStages;// 
    public TileBase groundTile;
    public float growthTime = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 playerPos = playerObject.transform.position;
            Vector3Int tilePos = farmTilemap.WorldToCell(playerPos);
            if (farmTilemap.GetTile(tilePos) != null)
            {
                if (farmTilemap.GetTile(tilePos) == growthStages[growthStages.Length - 1])
                {
                    print("Plant is ready to harvested");
                    farmTilemap.SetTile(tilePos, groundTile);
                }
                else
                {
                    print("E farmTilemap");
                    farmTilemap.SetTile(tilePos, growthStages[0]);
                    StartCoroutine(GrowPlant(tilePos));
                }
            }

        }

    }

    IEnumerator GrowPlant(Vector3Int position)
    {
        for (int stage = 1; stage < growthStages.Length; stage++)
        {
            yield return new WaitForSeconds(growthTime);
            farmTilemap.SetTile(position, growthStages[stage]);
        }
    }
}
