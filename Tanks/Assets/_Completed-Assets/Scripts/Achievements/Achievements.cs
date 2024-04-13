using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{

    //first plaayer achievements
    private bool fastwin1 = false;
    private bool fulllife1 = false;
    private bool shots1 = false;
    private bool avoid1 = false;

    //second player achievements
    private bool fastwin2 = false;
    private bool fulllife2 = false;
    private bool shots2 = false;
    private bool avoid2 = false;

    GameManager manager;
    TankHealth health1;
    TankHealth health2;
    TankShooting shooting1;
    TankShooting shooting2;

    private int next_round = 2;            //counter for rounds
    private float timer = 0;               //counter for time


    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (manager.round() != next_round) return;

        Fast();
        Health();
        Shooting();
        Avoid();


        timer = 0;   //reset timer
        next_round++;

        //if (manager.game_finished()) print();

    }

    private void Health()
    {
        
        health1 = GameObject.FindWithTag("Player1").GetComponent<TankHealth>();
        health2 = GameObject.FindWithTag("Player2").GetComponent<TankHealth>();
        
        int i = manager.round_winner();

        if ((health1.takeHealth() == 100) && (i == 1) && (!health1.life()) && (!fulllife1))
        {
            fulllife1 = true;
            Debug.Log("Player 1 unlock: win a round with full life");
        }
        else if ((health2.takeHealth() == 100) && (i == 2) && (!health2.life()) && (!fulllife2)) 
        {
            fulllife2 = true;
            Debug.Log("Player 2 unlock: win a round with full life");
        }
        health1.set();
        health2.set();

    }

    private void Shooting()
    {
        shooting1 = GameObject.FindWithTag("Player1").GetComponent<TankShooting>();
        shooting2 = GameObject.FindWithTag("Player2").GetComponent<TankShooting>();

        if ((shooting1.shots() > 30) && (!shots1))
        {
            shots1 = true;
            Debug.Log("Player 1 unlock: make up of 30 shots");
        }
        if ((shooting2.shots() > 30) && (!shots2)) {
            shots2 = true;
            Debug.Log("Player 2 unlock: make up of 30 shots");
        }

        shooting1.set();
        shooting2.set();

    }

    private void Fast()
    {
        int i = manager.round_winner();

        if ((i == 1) && (timer <= 60) && (!fastwin1))
        {
            fastwin1 = true;
            Debug.Log("Player 1 unlock: win the round in 1 minute");
        }
        else if ((i == 2) && (timer <= 60) && (!fastwin2))
        {
            fastwin2 = true;
            Debug.Log("Player 2 unlock: win the round in 1 minute");
        }

    }

    private void Avoid()
    {
        health1 = GameObject.FindWithTag("Player1").GetComponent<TankHealth>();
        health2 = GameObject.FindWithTag("Player2").GetComponent<TankHealth>();

        if ((!health1.train()) && (!avoid1))
        {
            avoid1 = true;
            Debug.Log("Player 1 unlock: avoid the train");
        }
        else if ((!health2.train()) && (!avoid2))
        {
            avoid2 = true;
            Debug.Log("Player 2 unlock: avoid the train");
        }

        health1.set2();
        health2.set2();
    }

    public void print()
    {
        if (fulllife1) Debug.Log("Player 1 win a round with full life");
        if (fulllife2) Debug.Log("Player 2 win a round with full life");
        if (shots1) Debug.Log("Player 1 make up of 30 shots");
        if (shots2) Debug.Log("Player 2 make up of 30 shots");
        if (fastwin1) Debug.Log("Player 1 win the round in 1 minute");
        if (fastwin2) Debug.Log("Player 2 win the round in 1 minute");
        if (avoid1) Debug.Log("Player 1 avoid the train");
        if (avoid2) Debug.Log("Player 2 avoid the train");
    }

}
