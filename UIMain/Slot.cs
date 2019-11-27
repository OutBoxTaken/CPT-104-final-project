using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	//attached item will be given a value for i, this then allow button component on that item to access the dropItem function for the attached component.
	
	private Inventory inventory;
	public int i;
	
	private void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}
	
	private void Update()
	{
		if (transform.childCount <=0) {
			inventory.isFull[i] = false;
		}
	}
	
    public void DropItem() {
		Debug.Log("1");
	   foreach (Transform child in transform) {
		   Debug.Log("2");
		   child.GetComponent<Spawn>().SpawnDroppedItem();
		   Debug.Log("3");
		   GameObject.Destroy(child.gameObject);
		   
	   }//end foreach
	}//end drop item
}//end class
