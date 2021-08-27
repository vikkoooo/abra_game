using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMaker : MonoBehaviour
{
    public GameObject ground;
    private int n_right = 3;
    private float startX = -4.54f;
    private float startY = -4.05f;
    private float toMoveX = 4.54f + 4.06f; // 8,6
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        CreateGround(n_right);
    }

    private void CreateGround(int n_right)
    {
        for (int i = 0; i < n_right; i++)
        {
            // Create the object
            GameObject newGround = Instantiate(ground);
            // Move to the new position
            newGround.transform.position = new Vector2(startX + (toMoveX * i), startY);
            // Pack them together when running the game
            newGround.transform.parent = this.transform;
        }
    }
    
    
    
    
}
