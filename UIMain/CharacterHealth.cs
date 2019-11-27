using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
	public float CurrentHealth { get; set; }
	public float MaxHealth {get; set; }
    
	public Slider healthbar; //or UnityEngine.UI.Slider if namepspace not called
	
    void Start()
    {
		MaxHealth = 20f;
		//Resets health to full on game load
		CurrentHealth = MaxHealth;
		
		healthbar.value = CalculateHealth(); //setting value in code and moving slider to value
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.X))
			DealDamage(6);
        
    }
	
	void DealDamage(float damageValue)
	{
		//deduct the damage dealth from the characters health
		CurrentHealth-=damageValue;
		healthbar.value = CalculateHealth();
		//if the character is out of health, die!
		if (CurrentHealth <= 0)
			Die();
	}
	
	float CalculateHealth()
	{
		return CurrentHealth/MaxHealth;
	}
	
	public void HealDamage(float healValue)
	{
		if(CurrentHealth < MaxHealth)
		{
			CurrentHealth += healValue;
			if(CurrentHealth>MaxHealth)
			{
				CurrentHealth = MaxHealth;
			}
			
			Debug.Log("Healing Item Used");
		}
		else{Debug.Log("Health Full");}
		healthbar.value = CalculateHealth();
	}
	
	void Die()
	{
		CurrentHealth = 0;
		Debug.Log("You are dead.");
		
	}
}
