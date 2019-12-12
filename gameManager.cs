using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
public class gameManager : MonoBehaviour
{
	public float CurrentHealth { get; set; }
	public float MaxHealth {get; set; }
	public Slider healthSlider;
	
	public float CurrentMagic { get; set; }
	public float MaxMagic {get; set; }
	public Slider magicSlider;
	
	public int presentsDel;
	public bool allPresents = false;
	
	public bool hasWon;
	
	public GameObject pCharacter;
	public int cost;
	//Item count management
	private int healthPot;
	private int magicPot;
	private int gravPot;
	private int speedPot;
	
	public GameObject healthColor;
	public GameObject healthGray;
	public GameObject healthNum; 
	
	public GameObject magicColor;
	public GameObject magicGray;
	public GameObject magicNum; 
	
	public GameObject gravColor;
	public GameObject gravGray;
	public GameObject gravNum; 
	
	public GameObject speedColor;
	public GameObject speedGray;
	public GameObject speedNum; 
	
	public GameObject timerTxt;
	
	private int cookieNum;
	public int currentCookie;
	
	public GameObject cookieColor;
	public GameObject cookieDisp; 
	
	//shop variables
	private bool inShop;
	public GameObject shopUI;
	
	//Game Timer management
	public float timeInGame = 0;
	public bool inLevel = true; //make false for build, make true on scene change to house worlds
	
	//coroutine
	[SerializeField] private int potionTime;
	
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 20f;
		MaxMagic =20f;
		//Resets health to full on game load
		CurrentHealth = MaxHealth;
		healthSlider.value = CalculateHealth();
		CurrentMagic = MaxMagic;
		magicSlider.value = calculateMagic();
		hasWon = false;
		inShop = false;
		
		healthPot = 0;
		magicPot = 0;
		gravPot = 0;
		speedPot = 0;
		
		
		//public static variable call  --- scriptname.variable = ##;
    }

    // Update is called once per frame
    void Update()
    {
		if (CurrentMagic< MaxMagic)
		{
			CurrentMagic +=Time.deltaTime;
		}
		if (CurrentMagic> MaxMagic)
		{
			CurrentMagic = MaxMagic;
		}
		
		if(hasWon)
		{
			//move to scene
		}
		
		//panel buttons keep out of inLevel and inShop loop to keep them updating correctly
		
		//UI DISPLAYS
		timerTxt.GetComponent<UnityEngine.UI.Text>().text = "Time: " + timeInGame.ToString("F2");
		
		cookieDisp.GetComponent<UnityEngine.UI.Text>().text = currentCookie.ToString();
		
		healthNum.GetComponent<UnityEngine.UI.Text>().text = healthPot.ToString();
		if (healthPot >0)
		{
			healthGray.gameObject.SetActive(false);
			healthColor.gameObject.SetActive(true);
		}
		else
		{
			healthGray.gameObject.SetActive(true);
			healthColor.gameObject.SetActive(false);
		}
		
		magicNum.GetComponent<UnityEngine.UI.Text>().text = magicPot.ToString();
		if (magicPot >0)
		{
			magicGray.gameObject.SetActive(false);
			magicColor.gameObject.SetActive(true);
		}
		else
		{
			magicGray.gameObject.SetActive(true);
			magicColor.gameObject.SetActive(false);
		}
		
		gravNum.GetComponent<UnityEngine.UI.Text>().text = gravPot.ToString();
		if (gravPot >0)
		{
			gravGray.gameObject.SetActive(false);
			gravColor.gameObject.SetActive(true);
		}
		else
		{
			gravGray.gameObject.SetActive(true);
			gravColor.gameObject.SetActive(false);
		}
		
		speedNum.GetComponent<UnityEngine.UI.Text>().text = speedPot.ToString();
		if (speedPot >0)
		{
			speedGray.gameObject.SetActive(false);
			speedColor.gameObject.SetActive(true);
		}
		else
		{
			speedGray.gameObject.SetActive(true);
			speedColor.gameObject.SetActive(false);
		}
		
		//DEBUG Tools
		if (Input.GetKeyDown(KeyCode.X))
		{
			//Damage Player Stats;
			DealDamage(5);
			useMagic(5);
			Debug.Log(CurrentHealth);
			Debug.Log(CurrentMagic);
		}
			
		if (Input.GetKeyDown(KeyCode.Z))
		{
			//Debug.Log(this);
			itemPickUp(1);
			Debug.Log("You now have " + healthPot + " Health potions");
			itemPickUp(2);
			Debug.Log("You now have " + magicPot + " Magic potions");
			itemPickUp(3);
			Debug.Log("You now have " + gravPot + " Gravity potions");
			itemPickUp(4);
			Debug.Log("You now have " + speedPot + " Speed potions");
			itemPickUp(5);
			Debug.Log("You now have " + currentCookie + " cookies");
		}
		
		if (Input.GetKeyDown(KeyCode.B))
		{
			if(inShop == true)
			{
				shopUI.gameObject.SetActive(false);
				inShop =false;
				inLevel = true;
			}
			else
			{
				shopUI.gameObject.SetActive(true);
				inShop = true;
				inLevel = false;
			}
		}
		
		if (inShop == true && inLevel == false)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				Debug.Log("pressed 1");
				purchaseItem(1);
			}
			
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				Debug.Log("pressed 2");
				purchaseItem(2);
			}
			
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				Debug.Log("pressed 3");
				purchaseItem(3);
			}
			
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				Debug.Log("pressed 4");
				purchaseItem(4);
			}
			
		}
		
		if (hasWon == false && inLevel ==true)
		{
			timeInGame +=Time.deltaTime;
			
			if (allPresents == true)
			{
				winner();
			}
			

			
			//Old script for timeInGame timer
			/*if (timeInGame <= 0)
			//{
				//RETURN TO HUB SCENE
				//inLevel = false;
			} */
			
			healthSlider.value = CalculateHealth();
			magicSlider.value = calculateMagic();
			
		
		//GAMEPLAY Tools
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				Debug.Log("pressed 1");
				itemUsed(1);
			}
			
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				Debug.Log("pressed 2");
				itemUsed(2);
			}
			
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				Debug.Log("pressed 3");
				itemUsed(3);
			}
			
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				Debug.Log("pressed 4");
				itemUsed(4);
			}
			
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("Left Clicked");
			}
			
			if (Input.GetMouseButtonDown(1))
			{
				Debug.Log("Right Clicked");
			}
		
		}//end ingame IF loop
    }
	
	public void useMagic(int magicUsed)
	{
		if (CurrentMagic >= magicUsed)
		{
			CurrentMagic -= magicUsed;
		}
		else
		{
				Debug.Log("Not enough magic");
		}
	}
	
	public void DealDamage(int damageDealt)
	{
		CurrentHealth-=damageDealt;
		//if the character is out of health, die!
		if (CurrentHealth <= 0)
			Die();
	}
	
	public void Die()
	{
		CurrentHealth = 0;
		Debug.Log("You are dead.");
		//FIXME SEND TO LOSS SCREEN
		
	}
	
	public float CalculateHealth()
	{
		return CurrentHealth/MaxHealth;
	}
	
	public float calculateMagic()
	{
		return CurrentMagic/MaxMagic;
	}
	
	public void itemUsed(int numPressed)
	{
		switch (numPressed)
		{
			case 1: //health potion
				if (healthPot >0)
				{
					HealDamage(8);
				}
				else
				{Debug.Log("You have no more health potions");}
				break;
			case 2: //magic Potion
				if (magicPot >0)
				{
					healMagic(8); //FIXME WHEN ADDING MAGIC STUFF
				}
				else
				{
					Debug.Log("You have no more magic potions");
					}
				break;
			case 3: //grav Potion
				if (gravPot >0)
				{
					gravPot -= 1;
					StartCoroutine(gravpotionDuration());
					
					
				}
				else
				{
					Debug.Log("You have no more grav potions");
				}
				break;
			case 4: //speed Potion
				if (speedPot >0)
				{
					speedPot -= 1;
					StartCoroutine(speedpotionDuration());
				}
				else
				{Debug.Log("You have no more speed potions");}
				break;
			
			default:
				Debug.Log("You pressed unknown");
				break;

		}
	}//end itemUsed()
	
	public void itemPickUp(int itemNum)
	{
		switch (itemNum)
		{
			case 1: //health potion
			healthPot += 1;
			break;
			
			case 2: //magic potion
			magicPot += 1;
			break;
			
			case 3: //grav potion
			gravPot += 1;
			break;
			
			case 4: //speed potion
			speedPot += 1;
			break;
			
			case 5: //cookieItem
			cookieNum += 11;
			currentCookie += 11;
			break;
			
			case 6: //cookieItem
			cookieNum += 5;
			currentCookie += 5;
			break;
			
			default:
				Debug.Log("You pressed unknown");
				break;
		}//end switch
	}
	
	public void purchaseItem(int itemNum)
	{
		
		
		switch (itemNum)
		{
			case 1: //health potion
				cost = 10;
				if (currentCookie >= cost)
				{
					currentCookie -= cost;
					healthPot +=1;
				}
				//if too expensive, print statement
				else
				{
					Debug.Log("Too expensive, cant afford");
				}
				break;
				
			case 2: //health potion
				cost = 10;
				if (currentCookie >= cost)
				{
					currentCookie -= cost;
					magicPot +=1;
				}
				//if too expensive, print statement
				else
				{
					Debug.Log("Too expensive, cant afford");
				}
				break;
				
				case 3: //health potion
				cost = 30;
				if (currentCookie >= cost)
				{
					currentCookie -= cost;
					gravPot +=1;
				}
				//if too expensive, print statement
				else
				{
					Debug.Log("Too expensive, cant afford");
				}
				break;
				
				case 4: //health potion
				cost = 30;
				if (currentCookie >= cost)
				{
					currentCookie -= cost;
					speedPot +=1;
				}
				//if too expensive, print statement
				else
				{
					Debug.Log("Too expensive, cant afford");
				}
				break;
				
			default:
				Debug.Log("You pressed unknown");
				break;
		}//end switch
				
	}//end purchaseItem()*/
	
	public void HealDamage(float healValue)
	{
		Debug.Log("start HealDamage()");
		if(CurrentHealth < MaxHealth)
		{
			healthPot -= 1;
			CurrentHealth += healValue;
			
			if(CurrentHealth>MaxHealth)
			{
				CurrentHealth = MaxHealth;
			}
			
			Debug.Log("Healing Item Used");
		}
		else{Debug.Log("Health Full");}
		//healthbar.value = CalculateHealth();
		Debug.Log("end HealDamage()");
		
	}
	
	public void healMagic(float healMagic)
	{
		Debug.Log("start HealDamage()");
		if(CurrentMagic < MaxMagic)
		{
			magicPot -= 1;
			CurrentMagic += healMagic;
			
			if(CurrentMagic>MaxMagic)
			{
				CurrentMagic = MaxMagic;
			}
			
			Debug.Log("Magic Item Used");
		}
		else{Debug.Log("Magic Full");}
		Debug.Log("end HealMagic()");
	}
	
	IEnumerator gravpotionDuration()
	{
		pCharacter.GetComponent<FirstPersonController>().m_GravityMultiplier = 1;
		yield return new WaitForSeconds(potionTime);
		pCharacter.GetComponent<FirstPersonController>().m_GravityMultiplier = 2;
	}
	
	IEnumerator speedpotionDuration()
	{
		pCharacter.GetComponent<FirstPersonController>().m_RunSpeed = 15;
		pCharacter.GetComponent<FirstPersonController>().m_WalkSpeed = 10;
		yield return new WaitForSeconds(potionTime);
		pCharacter.GetComponent<FirstPersonController>().m_RunSpeed = 10;
		pCharacter.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
	}
	
	public void exitLevel()
	{
		inLevel = false;
	}
	
	public void runLevel()
	{
		presentsDel = 0;
		allPresents = false;
		inLevel = true;
	}
	
	public void openShop()
	{
		inShop = true;
	}
	
	public void closeShop()
	{
		inShop = false;
	}
	
	public void winner()
	{
		hasWon = true;
	}
	
}//end class
}//end FPS namespace
