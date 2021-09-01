using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OLDPlayerHealthManaPower : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;
	public int maxMana = 10;
	public int currentMana = 0;
    public Slider healthSlider;
    public Slider manaSlider;
    public GameObject leverage;
    public GameObject MIM;
   
    
    // Start is called before the first frame update
    void Start()
    {
	    // Set max hp as start
	    currentHealth = maxHealth;
	    healthSlider.maxValue = currentHealth;
	    healthSlider.value = currentHealth;
	    
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Q))
	    {
		    SummonMIM(currentMana);
	    }

    }

    public void TakeDamage(int damage)
    {
	    currentHealth -= damage;
	    healthSlider.value = currentHealth;
    }
    
    public void IncreaseHP(int hp)
    {
	    if (currentHealth < maxHealth)
	    {
		    currentHealth += hp;
		    healthSlider.value = currentHealth;
	    }
    }
    
    public void IncreaseMana(int mana)
    {
	    if (currentMana < maxMana)
	    {
		    currentMana += mana;
		    manaSlider.value = currentMana;
		    leverage.GetComponent<Text>().text = currentMana.ToString() + "x";
	    }
    }
    
    private void OnTriggerEnter2D(Collider2D collison)
    {
	    if (collison.CompareTag("Enemy"))
	    {
		    TakeDamage(10);
	    }
    }

    private void SummonMIM(int leverageToUse)
    {
	    int baseMIM = 4;
	    currentMana = 0;
	    manaSlider.value = currentMana;
	    leverage.GetComponent<Text>().text = currentMana.ToString() + "x";

	    for (int i = 0; i < leverageToUse * baseMIM; i++)
	    {
		    GameObject newMIM = Instantiate(MIM);
		    newMIM.transform.position =
			    this.transform.position + new Vector3(Random.Range(-5, 5), Random.Range(2, 8), 0);
		    
	    }
	    
    }
  
    
    
}
