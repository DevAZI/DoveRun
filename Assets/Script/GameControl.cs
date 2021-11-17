using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public Text LifeText;
    private int Life = 0;
    private int score = 0;
    private int maxLife = 10;

    public bool gameOver = false; // game over value false
    
    void Awake() //깨어나면 
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R)) // gameover가 true고, 마우스가 눌려지면 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//로드씬, active scene을 불러옴
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true; //죽으면 게임오버 텍스트 활성화
    }
    public void BirdScored()
    {
        if (gameOver) return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void BirdHealth(int amount)
    {
      
        if (gameOver) return;
        
        Life = Mathf.Clamp(Life + amount, 0, maxLife);
        LifeText.text = "Life: " + Life.ToString();
        
    }

}
