using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCreater : MonoBehaviour
{
    // Weapons
    // TODO: make array from this instead
    public GameObject SPELL;
    public GameObject sSPELL;
    
    // Creating 
    private List<GameObject> weaponList = new List<GameObject>();
    
	
    // Because we flip player on start, we need to create the new wand before we start. 
    // Hence Awake()
    void Awake()
    {
        weaponList.Add(SPELL);
        weaponList.Add(sSPELL);

        CreateWeapon();
    }

    
    private void CreateWeapon()
    {
            int weaponType = Random.Range(0, 2);
            GameObject newWeapon = Instantiate(weaponList[weaponType]);
            newWeapon.transform.parent = this.transform;
            
            // the weapon spawns according to world positions, according to the prefab positions.
            // need to adjust those and add to the player positions.
            newWeapon.transform.position = new Vector3(-1.15f, 2f, 0) + this.transform.position;
            
            
            // TODO: adjust prefab positions so they spawn good, then use this line instead
            //newWeapon.transform.position += this.transform.position;

    }

}
