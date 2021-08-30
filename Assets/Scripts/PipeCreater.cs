using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCreater : MonoBehaviour
{
    public GameObject pipe1;
    public GameObject pipe2;

    public List<GameObject> pipes = new List<GameObject>();

    private int n_pipes = 6;
    private float minX = 10f;
    private float maxX = 140f;
    
    void Start()
    {
        pipes.Add(pipe1);
        pipes.Add(pipe2);
        CreatePipes(n_pipes);
    }
    
    private void CreatePipes(int n_pipes)
    {
        for (int i = 0; i < n_pipes; i++)
        {
            int pipeType = Random.Range(1, 3) - 1;
            GameObject newPipe = Instantiate(pipes[pipeType]);
            newPipe.transform.parent = this.transform;
            
            newPipe.transform.position = new Vector2(RandomizeX(), newPipe.transform.position.y);
        }
    }

    private float RandomizeX()
    {
        float x = Random.Range(minX, maxX);

        return x;
    }
}
