using System.Collections;
using UnityEngine;

/*
 * Script is used to create enemies on regular basis timeframe
 * They spawn close to the player at all times
 */
public class EnemyCreater : MonoBehaviour
{
	public GameObject[] enemies;

	// Spawn method is offset from the player
	public GameObject player;
	private Vector3 offset = new Vector3(10, 6, 0);

	private void Start()
	{
		StartCoroutine(SpawnMonster()); // Start coroutine
	}

	private IEnumerator SpawnMonster()
	{
		int monsterType = Random.Range(0, enemies.Length);

		GameObject newMonster = Instantiate(enemies[monsterType]);
		newMonster.transform.position = player.transform.position + offset;
		newMonster.transform.parent = this.transform;

		yield return new WaitForSeconds(Random.Range(3, 8));
		StartCoroutine(SpawnMonster());
	}
}