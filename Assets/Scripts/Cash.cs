using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioSource audio;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Collected()
    {
      //  audio.PlayOneShot(Coin, 0.7F);
        // do animation, whatever
    }

    void OnTriggerEnter(Collider other)
    {
        //Collectable oc = other.transform.GetComponent<Collectable>();
        //if (oc)
        //{
       //     oc.Collected();
            // do what the player needs to do when they pick something up...
       // }
    }

    }
