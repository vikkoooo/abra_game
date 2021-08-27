using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudRandomizer : MonoBehaviour
{
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;

    private List<GameObject> cloudList = new List<GameObject>();
    private int n_clouds = 7;

    private float minX = -8.9f;
    private float maxX = 8.9f;
    private float minY = 2f;
    private float maxY = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        cloudList.Add(cloud1);
        cloudList.Add(cloud2);
        cloudList.Add(cloud3);
        
        CreateClouds(n_clouds);
    }

    private void CreateClouds(int n_clouds)
    {
        for (int i = 0; i < n_clouds; i++)
        {
            int cloudType = Random.Range(1, 3) - 1;
            GameObject newCloud = Instantiate(cloudList[cloudType]);
            newCloud.transform.parent = this.transform;
            
            // Set new position of the cloud
            newCloud.transform.position = RandomizePosition();
        }
    }

    private Vector2 RandomizePosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector2(x, y);
    }
}
