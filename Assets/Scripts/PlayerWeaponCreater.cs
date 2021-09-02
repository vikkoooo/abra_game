using UnityEngine;

/*
 * This class spawns randomly a SPELL or sSPELL wand for the player on start
 */

public class PlayerWeaponCreater : MonoBehaviour
{
	// Weapons
	public GameObject[] weapons;
	
	// Weapon offset
	private Vector3 offset = new Vector3(-1.15f, 2f, 0);

	// Because we flip player on start, we need to create the new wand before we start. 
	// Hence Awake()
	void Awake()
	{
		CreateWeapon();
	}

	private void CreateWeapon()
	{
		int weaponType = Random.Range(0, weapons.Length);
		GameObject newWeapon = Instantiate(weapons[weaponType]);
		newWeapon.transform.parent = this.transform;

		// Adjust weapon to follow player with the offset as well
		newWeapon.transform.position = this.transform.position + offset;
	}
}