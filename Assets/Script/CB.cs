using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CB : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-2f, 0);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            rb2d.velocity = new Vector2(-2f, 0);
        }

    }
}
