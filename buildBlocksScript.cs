using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildBlocksScript : MonoBehaviour
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
                soundCoolDown = 2.0f;
                Debug.Log("PLAYING BLOCK");
                mateoPlayerScript.Health -= 10;

                //insert script for noise detection and health loss.
            }
    }
    // Update is called once per frame
    void Update()
    {
        if (soundCoolDown > 0.0f)
            soundCoolDown -= Time.deltaTime;
    }
}
