using UnityEngine;

/*
 * This script is attached to scenery, pipes and spawns pipes we need to jump over. 
 */
public class SceneryPipeCreater : MonoBehaviour
{
	// Array of different pipe models
	public GameObject[] pipes;
	private int n_pipes = 6; // How many pipes to spawn

	// Between what X coordinates
	private float minX = 10f;
	private float maxX = 140f;

	private void Start()
	{
		CreatePipes(n_pipes);
	}

	private void CreatePipes(int n_pipes)
	{
		for (int i = 0; i < n_pipes; i++)
		{
			int pipeType = Random.Range(0, pipes.Length);
			GameObject newPipe = Instantiate(pipes[pipeType]);
			newPipe.transform.parent = this.transform;

			// Set new pipe coordinate. Keeps the y coordinate from the prefab.
			newPipe.transform.position = new Vector2(RandomizeX(), newPipe.transform.position.y);
		}
	}

	private float RandomizeX()
	{
		float x = Random.Range(minX, maxX);

		return x;
	}
}