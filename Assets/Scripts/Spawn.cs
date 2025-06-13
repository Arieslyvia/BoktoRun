using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObj;
    public float timeOffset = 0.4f;
    public float distanceBtwTiles = 19f;
    public float randomValue = 0.5f;
    private Vector3 previousTilePosition;
    float startTime;
    Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);
   

    private void Start()
    {
        previousTilePosition = referenceObj.transform.position;
        startTime = Time.time;

    }

    private void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
                direction = mainDirection;
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
               
            }
            Vector3 spawnPos = previousTilePosition + distanceBtwTiles * direction;

            startTime = Time.time;
            Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos;
        }
        
    }
}
