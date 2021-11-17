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
    
    void Awake() //����� 
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R)) // gameover�� true��, ���콺�� �������� 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//�ε��, active scene�� �ҷ���
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true; //������ ���ӿ��� �ؽ�Ʈ Ȱ��ȭ
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
