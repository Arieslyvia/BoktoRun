using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawn : MonoBehaviour
{
    public GameObject[] tilePrefabs; // Assign your tile prefabs in Inspector
    public Transform player;          // Assign your player transform
    public int tilesAhead = 5;        // How many tiles ahead to spawn
    public float tileLength = 10f;    // Length of each tile

    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnZ = 0.0f;      // Z position for next tile
    private int safeZone = 30;         // How far behind to delete tiles

    void Start()
    {
        for (int i = 0; i < tilesAhead; i++)
        {
            if (i < 2)
                SpawnTile(0); // Spawn default tile for start
            else
                SpawnTile(RandomTileIndex());
        }
    }

    void Update()
    {
        if (player.position.z - safeZone > (spawnZ - tilesAhead * tileLength))
        {
            SpawnTile(RandomTileIndex());
            DeleteTile();
        }
    }

    void SpawnTile(int prefabIndex)
    {
        GameObject tile = Instantiate(tilePrefabs[prefabIndex], Vector3.forward * spawnZ, Quaternion.identity);
        activeTiles.Add(tile);
        spawnZ += tileLength;
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    int RandomTileIndex()
    {
        return Random.Range(0, tilePrefabs.Length);
    }
}
