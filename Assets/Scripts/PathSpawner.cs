/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PathSpawner : MonoBehaviour
{
   [SerializeField] private List <GameObject>paths = new List<GameObject>();
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private Movement player;

    private int nextIndex;
    private GameObject runningPath;
    private int currentIndex;
    

    private void Start()
    {
        //paths[1].transform.position = spawnPoint.transform.position;
    }

    private void Update()
    {
        if (runningPath == player.currentPath)
        {
            return;
        }
        PathChanger();
    }

    public void PathChanger()
    {
        do
        {
            nextIndex = Random.Range(0, paths.Count);

        } while (nextIndex == currentIndex);
        
        currentIndex = nextIndex;
        Debug.Log(nextIndex);
        paths[nextIndex].transform.position = spawnPoint.transform.position;

        runningPath = player.currentPath;
        spawnPoint = paths[nextIndex].transform.GetChild(1).gameObject;

    }
}
*/