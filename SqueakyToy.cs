using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueakyToy : MonoBehaviour
{
    public AudioSource audioClip;
    public float soundCoolDown;
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        soundCoolDown = 0.0f;
        audioClip = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("Player"))
            
            if (soundCoolDown <= 0.0f)
            {
                audioClip.Play();
                child.GetComponent<ObjPatrol>().goToSound(this.transform.position);
                soundCoolDown = 1.0f;
                Debug.Log("PLAYING SOUNDS");
                
            }
    }
    // Update is called once per frame
    void Update()
    {
        if (soundCoolDown > 0.0f)
            soundCoolDown -= Time.deltaTime;
    }
}