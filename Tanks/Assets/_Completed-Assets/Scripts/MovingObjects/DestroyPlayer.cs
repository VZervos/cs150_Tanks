using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyPlayer : MonoBehaviour
{

    public AudioSource hit; //audio when the tank stop moving


    void OnTriggerEnter(Collider other) //take the object that has touch the moving object
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2") //if the object is one of the players then make the stop moving
        {

            hit.Play();     //play hit audio

            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();    //get component of the player
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>(); //get access to the player
            targetHealth.kill();  //destroy player

        }

    }

}
