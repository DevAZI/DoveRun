using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colum : MonoBehaviour
{
    public GameObject columnPrefab;
    public int columnPoolSize = 5;       // Obstacles   5개             
  private float columnMin = -4.4f;         // 생성위치: pos y -2~2 랜덤              
    private float columnMax = -1.5f;
    private GameObject[] columns;
    private int currentColumn = 0;
    private Vector2 objectPoolPosition = new Vector2(-15f, 0f);  //미리생성
    private float spawnXPosition = 12f;
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
        int randtime = (int)Random.Range(8, 10);
        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned >= randtime)
        {
            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position =
            new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
