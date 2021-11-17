using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColumn : MonoBehaviour
{
    public GameObject columnPrefab;
    public int columnPoolSize = 5;       // Obstacles   5개             
    public float spawnRate = 3f;           // 3초마다 생성              
    public float columnMin = -2f;         // 생성위치: pos y -2~2 랜덤              
    public float columnMax = 2f;
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
        timeSinceLastSpawned += Time.deltaTime;
        if (GameControl.instance.gameOver == false &&
        timeSinceLastSpawned >= spawnRate)
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
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Bird controller = other.GetComponent<Bird>();
    //    if (other.tag.Equals("Bird"))
    //    {
    //        controller.ChangeHealth(-1);
    //        GameControl.instance.BirdHealth(-1);

    //    }

    //}

}
