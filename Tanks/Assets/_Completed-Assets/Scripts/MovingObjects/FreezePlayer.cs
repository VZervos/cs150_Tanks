using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FreezePlayer : MonoBehaviour
{

    public AudioSource hit; //audio when the tank stop moving


    void OnTriggerEnter(Collider other) //take the object that has touch the moving object
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2") //if the object is one of the players then make the stop moving
        {
        
            hit.Play();     //play hit audio

            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();    //get component of the player
            TankMovement targetMove = targetRigidbody.GetComponent<TankMovement>(); //get access to the player
            targetMove.Stop();  //stop player moving

        }

    }

}
