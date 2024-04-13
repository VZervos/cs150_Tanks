using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart_collect2 : MonoBehaviour
{
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        this.transform.position = new Vector3((float)-112, 1, (float)-22.5);
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();
        TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
        if (targetHealth != null && targetHealth.getHealth() > 0)
        {
            AudioSource audio;
            audio = GetComponent<AudioSource>();
            audio.Play();
            this.transform.position = new Vector3((float)-112, (float)-100, (float)-22.5);
            targetHealth.Heal(50);
            StartCoroutine(ExecuteAfterTime(15));
        }
    }
}
