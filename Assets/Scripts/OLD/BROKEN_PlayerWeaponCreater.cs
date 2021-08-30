using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BROKEN_PlayerWeaponCreater : MonoBehaviour
{
    // Weapons
    public GameObject SPELL;
    public GameObject sSPELL;
    
    // Creating 
    private List<GameObject> weaponList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        weaponList.Add(SPELL);
        weaponList.Add(sSPELL);

        CreateWeapon();
    }

    
    private void CreateWeapon()
    {
            int weaponType = Random.Range(1, 3) - 1;
            GameObject newWeapon = Instantiate(weaponList[weaponType], this.transform, true);
            //newWeapon.transform.position = new Vector2(0, 0);

    }

}
