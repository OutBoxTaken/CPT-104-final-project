using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
public class magicDestroy : MonoBehaviour
{
	
	public GameObject gameMan;
	public bool didenter= false;
	
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (didenter && Input.GetMouseButtonDown(0))
		{
			if(gameMan.GetComponent<gameManager>().CurrentMagic >= 8)
			{
				gameMan.GetComponent<gameManager>().useMagic(8);
				gameObject.SetActive(false);
			}
		}
		
    }
	
	public void OnTriggerEnter(Collider Col)
	{
		if (Col.CompareTag("Player"))
		{
			didenter = true;
			Debug.Log("collision");
			
		}
	}
	
}
}