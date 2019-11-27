using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useHealth : MonoBehaviour
{
	public GameObject healthBar;
	
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("11");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
		{
			Debug.Log("asd");
			healthBar.GetComponent<CharacterHealth>().HealDamage(6);
		}
		//inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
}
