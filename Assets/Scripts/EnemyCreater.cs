using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    public GameObject player;
    public GameObject dragon;
    public GameObject skull;
    public GameObject girlLeft;
    public GameObject girlRight;
    private Vector3 offset = new Vector3(10, 6, 0);
    private List<GameObject> monster = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        monster.Add(dragon);
        monster.Add(skull);
        monster.Add(girlLeft);
        monster.Add(girlRight);
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        int monsterType = Random.Range(1, 5) - 1;
        
	    GameObject newMonster = Instantiate(monster[monsterType]);
        newMonster.transform.position = player.transform.position + offset;
        newMonster.transform.parent = this.transform;
        
        yield return new WaitForSeconds(Random.Range(3, 8));
        StartCoroutine(SpawnMonster());
    }
}
