using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWall : MonoBehaviour
{
    public ParticleSystem p;
    public int damage = -1;
    void OnTriggerEnter2D(Collider2D other)
    {
        Bird controller = other.GetComponent<Bird>();
        if (other.tag.Equals("Bird"))
        {
            controller.ChangeHealth(damage);
            GameControl.instance.BirdHealth(damage);
            p.Play();
        }

    }
  
}
