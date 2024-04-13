using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatcodes : MonoBehaviour
{
    public TankHealth tankhealth;
    public TankMovement tankmovement;
    public TankShooting tankshooting;
    public GameObject tank;

    private string[] doubledmg;
    private int dbldmg_counter;
    private bool dbldmg1_activated;
    private bool dbldmg2_activated;

    private string[] godmode;
    private int godmd_counter;
    private bool godmd1_activated;
    private bool godmd2_activated;

    private string[] immobilize;
    private int immblz_counter;
    private bool immblz1_activated;
    private bool immblz2_activated;

    private string[] pacificate;
    private int pcfct_counter;
    private bool pcfct1_activated;
    private bool pcfct2_activated;

    private string[] superspeed;
    private int sprspd_counter;
    private bool sprspd1_activated;
    private bool sprspd2_activated;

    void Start()
    {

        doubledmg = new string[] { "d", "b", "l", "d", "m", "g" };
        dbldmg_counter = 0;
        dbldmg1_activated = false;
        dbldmg2_activated = false;

        godmode = new string[] { "g", "o", "d", "m", "d" };
        godmd_counter = 0;
        godmd1_activated = false;
        godmd2_activated = false;

        immobilize = new string[] { "i", "m", "m", "b", "l", "z" };
        immblz_counter = 0;
        immblz1_activated = false;
        immblz2_activated = false;

        pacificate = new string[] { "p", "c", "f", "c", "t" };
        pcfct_counter = 0;
        pcfct1_activated = false;
        pcfct2_activated = false;

        superspeed = new string[] { "s", "p", "r", "s", "p", "d" };
        sprspd_counter = 0;
        sprspd1_activated = false;
        sprspd2_activated = false;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {

            // DOUBLE DAMAGE
            if (dbldmg_counter != doubledmg.Length && Input.GetKeyDown(doubledmg[dbldmg_counter])
                && godmd_counter == 0 && immblz_counter == 0 && pcfct_counter == 0 && sprspd_counter == 0)
            {
                dbldmg_counter++;
            }
            else if (dbldmg_counter == doubledmg.Length
                && godmd_counter == 0 && immblz_counter == 0 && pcfct_counter == 0 && sprspd_counter == 0)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && !dbldmg1_activated)
                {
                    dbldmg1_activated = true;
                    Debug.Log("<color=red>Double damage activated for player 1!");
                    tank = GameObject.FindWithTag("Player2");
                    tankhealth = tank.GetComponent<TankHealth>();
                    tankhealth.double_damage = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && !dbldmg2_activated)
                {
                    dbldmg2_activated = true;
                    Debug.Log("<color=red>Double damage activated for player 2!");
                    tank = GameObject.FindWithTag("Player1");
                    tankhealth = tank.GetComponent<TankHealth>();
                    tankhealth.double_damage = true;

                }
                dbldmg_counter = 0;
            }
            else
            {
                dbldmg_counter = 0;
            }



            // GOD MODE
            if (godmd_counter != godmode.Length && Input.GetKeyDown(godmode[godmd_counter])
                && dbldmg_counter == 0 && immblz_counter == 0 && pcfct_counter == 0 && sprspd_counter == 0)
            {
                godmd_counter++;
            }
            else if (godmd_counter == godmode.Length
                && dbldmg_counter == 0 && immblz_counter == 0 && pcfct_counter == 0 && sprspd_counter == 0)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && !godmd1_activated)
                {
                    godmd1_activated = true;
                    Debug.Log("<color=red>God mode activated for player 1!");
                    tank = GameObject.FindWithTag("Player1");
                    tankhealth = tank.GetComponent<TankHealth>();
                    tankhealth.invincibility = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && !godmd2_activated)
                {
                    godmd2_activated = true;
                    Debug.Log("<color=red>God mode activated for player 2!");
                    tank = GameObject.FindWithTag("Player2");
                    tankhealth = tank.GetComponent<TankHealth>();
                    tankhealth.invincibility = true;

                }
                godmd_counter = 0;
            }
            else
            {
                godmd_counter = 0;
            }



            // IMMOBILIZE
            if (immblz_counter != immobilize.Length && Input.GetKeyDown(immobilize[immblz_counter])
                && dbldmg_counter == 0 && godmd_counter == 0 && pcfct_counter == 0 && sprspd_counter == 0)
            {
                immblz_counter++;
            }
            else if (immblz_counter == immobilize.Length
                && dbldmg_counter == 0 && godmd_counter == 0 && pcfct_counter == 0 && sprspd_counter == 0)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && !immblz1_activated)
                {
                    immblz1_activated = true;
                    Debug.Log("<color=red>Immobilization activated for player 1!");
                    tank = GameObject.FindWithTag("Player2");
                    tankmovement = tank.GetComponent<TankMovement>();
                    tankmovement.immobilized = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && !immblz2_activated)
                {
                    immblz2_activated = true;
                    Debug.Log("<color=red>Immobilization activated for player 2!");
                    tank = GameObject.FindWithTag("Player1");
                    tankmovement = tank.GetComponent<TankMovement>();
                    tankmovement.immobilized = true;

                }
                immblz_counter = 0;
            }
            else
            {
                immblz_counter = 0;
            }



            // PACIFICATE
            if (pcfct_counter != pacificate.Length && Input.GetKeyDown(pacificate[pcfct_counter])
                && dbldmg_counter == 0 && godmd_counter == 0 && immblz_counter == 0 && sprspd_counter == 0)
            {
                pcfct_counter++;
            }
            else if (pcfct_counter == pacificate.Length
                && dbldmg_counter == 0 && godmd_counter == 0 && immblz_counter == 0 && sprspd_counter == 0)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && !pcfct1_activated)
                {
                    pcfct1_activated = true;
                    Debug.Log("<color=red>Pacification activated for player 1!");
                    tank = GameObject.FindWithTag("Player2");
                    tankshooting = tank.GetComponent<TankShooting>();
                    tankshooting.pacificated = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && !pcfct2_activated)
                {
                    pcfct2_activated = true;
                    Debug.Log("<color=red>Pacification activated for player 2!");
                    tank = GameObject.FindWithTag("Player1");
                    tankshooting = tank.GetComponent<TankShooting>();
                    tankshooting.pacificated = true;

                }
                pcfct_counter = 0;
            }
            else
            {
                pcfct_counter = 0;
            }



            // SUPER SPEED
            if (sprspd_counter != superspeed.Length && Input.GetKeyDown(superspeed[sprspd_counter])
                && dbldmg_counter == 0 && godmd_counter == 0 && immblz_counter == 0 && pcfct_counter == 0)
            {
                sprspd_counter++;
            }
            else if (sprspd_counter == superspeed.Length
                && dbldmg_counter == 0 && godmd_counter == 0 && immblz_counter == 0 && pcfct_counter == 0)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && !sprspd1_activated)
                {
                    sprspd1_activated = true;
                    Debug.Log("<color=red>Super Speed activated for player 1!");
                    tank = GameObject.FindWithTag("Player1");
                    tankmovement = tank.GetComponent<TankMovement>();
                    tankmovement.doublespeed = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && !sprspd2_activated)
                {
                    sprspd2_activated = true;
                    Debug.Log("<color=red>Super Speed activated for player 2!");
                    tank = GameObject.FindWithTag("Player2");
                    tankmovement = tank.GetComponent<TankMovement>();
                    tankmovement.doublespeed = true;

                }
                sprspd_counter = 0;
            }
            else
            {
                sprspd_counter = 0;
            }
        }
    }
}
