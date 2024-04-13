using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_collect : MonoBehaviour
{
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        this.transform.position = new Vector3((float)20, 1, (float)10);
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
            this.transform.position = new Vector3((float)20, (float)-100, (float)10);
            targetHealth.TakeDamage(50);
            StartCoroutine(ExecuteAfterTime(10));
        }
    }
}
