using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public AudioClip audioClip;
    private float SliderValue;

    public GameObject explosionParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            print("hit");
            print(transform.position);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            //DO explosion
            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }
            
            Destroy(gameObject);
            
            //Update UI
            ScoreManager.instance.AddPoint();
            
        }
    }
}
