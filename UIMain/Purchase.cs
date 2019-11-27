using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
	
	//public GameObject item; might be obsolete with itemButton gameObject
	public int cookieCost;
	public GameObject itemButton;
	private Inventory inventory;
	
    // Start is called before the first frame update
    void Start()
    {
		//set inventory var to player inventory
        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void buyItem()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		Debug.Log("1123123");
		for	(int i = 0; i < inventory.slots.Length; i++)
			{
				Debug.Log("2");
				if (inventory.isFull[i] == false) {
					//item can be added to inventory !
					Debug.Log("3");
					inventory.isFull[i] = true;
					Debug.Log("4");
					Instantiate(itemButton, inventory.slots[i].transform, false);
					Debug.Log("5");
					//Destroy(gameObject);
					break;
				}
				else{Debug.Log("No space for item");}
			}
		
		
	}
}

