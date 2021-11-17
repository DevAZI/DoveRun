using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject columnPrefab;
    public int columnPoolSize = 5;       // Obstacles   5俺             
    private float  spawnRate = 30f;           // 3檬付促 积己              

    private GameObject[] columns;
    private int currentColumn = 0;
    private Vector2 objectPoolPosition = new Vector2(-100f, 1.3f);  //固府积己
    private float spawnXPosition = 20f;
    private float timeSinceLastSpawned;
    void Start()
    {
        timeSinceLastSpawned = 0f;
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab,
                                    objectPoolPosition, Quaternion.identity);
        }
        
    }
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
           
            columns[currentColumn].transform.position = new Vector2(spawnXPosition,1.3f);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
