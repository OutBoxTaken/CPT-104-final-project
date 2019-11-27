using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
	[SerializeField] private GameObject Box;
	[SerializeField] private int timer;
	
	void Start()
    {
        StartCoroutine(HideObject());
    }
	
	IEnumerator HideObject() //allows yield command
	{
		yield return new WaitForSeconds(timer);
		Box.SetActive(false);
	}
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
