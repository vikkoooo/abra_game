using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private float speed = 5f;
    private float minX = -11f;
    private float maxX = 150f;
    private float y;

    void Start()
    {
        y = this.transform.position.y;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        if (this.transform.position.x < minX)
        {
            this.transform.position = new Vector2(maxX, y);
        }
            
    }
}
