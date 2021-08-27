using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundCreater : MonoBehaviour
{
    public GameObject background;
    private int n_right = 15;
    private int n_down = 9;
    private float startX = -8.26f; // Start position of the object to duplicate and move
    private float startY = 4.371f;
    private float toMoveX = -7.03f + 8.26f; // 1,23
    private float toMoveY = -4.371f + 3.139f; // 1,232


    // Start is called before the first frame update
    void Start()
    {
        CreateBackground(n_right, n_down);
    }
    
    private void CreateBackground(int n_right, int n_down)
    {
        for (int i = 0; i < n_right; i++)
        {
            for (int j = 0; j < n_down; j++)
            {
                // Create the object
                GameObject newBackground = Instantiate(background);
                // Move to the new position
                newBackground.transform.position = new Vector2(startX + (toMoveX * i), startY + (toMoveY) * j);
                // Pack them together when running the game
                newBackground.transform.parent = this.transform;
            }
        }
    }



}
