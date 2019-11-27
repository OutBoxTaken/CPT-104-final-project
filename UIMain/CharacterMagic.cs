using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMagic : MonoBehaviour
{
	public float CurrentMagic { get; set; }
	public float MaxMagic {get; set; }
    
	public Slider magicbar; //or UnityEngine.UI.Slider if namepspace not called
	
    void Start()
    {
		MaxMagic = 20f;
		//Resets magic to full on game load
		CurrentMagic = MaxMagic;
		
		magicbar.value = Calculatemagic(); //setting value in code and moving slider to value
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Y))
			UseMagic(6);
        
    }
	
	void UseMagic(float damageValue)
	{
		//deduct the magic used from the characters magic
		CurrentMagic-=damageValue;
		magicbar.value = Calculatemagic();
		//if the character is out of magic, NoMagic!
		if (CurrentMagic <= 0)
			NoMagic();
	}
	
	float Calculatemagic()
	{
		return CurrentMagic/MaxMagic;
	}
	
	void NoMagic()
	{
		CurrentMagic = 0;
		Debug.Log("You are out of magic.");
		
	}
}
