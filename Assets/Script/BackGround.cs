using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
    {
    
    // Start is called before the first frame update
    public float speed;
    float viewHeight;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;
    // Update is called once per frame
    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 nextPos = Vector2.zero;
        }
        else { 
        Vector2 curPos = transform.position;
        Vector2 nextPos = Vector2.left * speed * Time.deltaTime;
        transform.position = curPos + nextPos;
        if (sprites[endIndex].position.x < viewHeight * (-2))
        {
            Vector2 backSpritePos = sprites[startIndex].localPosition;
            Vector2 frontSpritePos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + (Vector2.right * 20);

            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = (startIndexSave - 1 == -1) ? sprites.Length - 1 : startIndexSave - 1;

        }
    }
    }
}
