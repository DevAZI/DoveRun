using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCB : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-4f, 0);
    }

    
}
