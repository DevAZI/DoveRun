using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
  
    int count = 0;
    float timeSinceLastSpawned = 0;
    int spawnRate = 3;
    
    // Start is called before the first frame update
  
    void OnTriggerStay2D(Collider2D other)
    {
      
        Bird controller = other.GetComponent<Bird>();
        if (controller != null)
        {
            count = count + 1;
            if (count == 300)
            {
                if (controller.health < controller.maxHealth)
                {
                    GameControl.instance.BirdHealth(2);
                    controller.ChangeHealth(2);
                    gameObject.SetActive(false);
                }
            }
        }
    }
       
    }





