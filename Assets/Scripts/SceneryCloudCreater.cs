using UnityEngine;
using Random = UnityEngine.Random;

/*
 * This script is called upon start and creates clouds
 */
public class SceneryCloudCreater : MonoBehaviour
{
    // Cloud types
    public GameObject[] clouds;
    private int n_clouds = 15; // Number of clouds to spawn

    // Positions
    private float minX = -9f;
    private float maxX = 148f;
    private float minY = 2f;
    private float maxY = 5f;
    
    private void Start()
    {
        CreateClouds(n_clouds);
    }
    
    private void CreateClouds(int n_clouds)
    {
        for (int i = 0; i < n_clouds; i++)
        {
            int cloudType = Random.Range(0, 3);  // Randomize one cloud type
            GameObject newCloud = Instantiate(clouds[cloudType]); // Create cloud
            newCloud.transform.parent = this.transform; // Make it child of the thing this script is attached to
            newCloud.transform.position = RandomizePosition(); // Set new position of the cloud
        }
    }

    private Vector2 RandomizePosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector2(x, y);
    }
}
