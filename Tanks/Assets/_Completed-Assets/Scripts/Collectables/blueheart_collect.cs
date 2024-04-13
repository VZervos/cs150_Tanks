using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueheart_collect : MonoBehaviour
{
    public GameObject tank;
    public TankHealth tankhealth1;
    public TankHealth tankhealth2;

    private bool firstrun; 

    private void Start()
    {
        firstrun = true;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        this.transform.position = new Vector3((float)20, (float)1, (float)30);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            if (firstrun)
            {
                tank = GameObject.FindWithTag("Player1");
                tankhealth1 = tank.GetComponent<TankHealth>();
                tank = GameObject.FindWithTag("Player2");
                tankhealth2 = tank.GetComponent<TankHealth>();
                AudioSource audio;
                audio = GetComponent<AudioSource>();
                firstrun = false;
            }
            this.transform.position = new Vector3((float)20, (float)-100, (float)30);
            //GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().Play();
            float tmp;
            tmp = tankhealth1.getHealth();
            tankhealth1.setHealth(tankhealth2.getHealth());
            tankhealth2.setHealth(tmp);
            StartCoroutine(ExecuteAfterTime(20));
        }
    }
}
