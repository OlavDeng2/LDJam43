using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public int maxHealth = 20;
    public int currentHealth = 20;
    public int hitChance = 70;

    public bool isPlayer;
    public GameObject outroPanel;

    private GameObject[] ships;
    public GameObject otherShip;
    public ShipController otherShipController;
    public GameObject partBeingAimedAt;
    public GameObject partAimingAt;


    public GameObject[] partsThatCanBeAimedAt;


    public GameObject[] engines;
    public GameObject[] shieldGenerators;
    public GameObject[] fuelTanks;
    public GameObject[] cannons;
    public GameObject[] cockpits;
    public GameObject[] hulls;
    public GameObject[] wings;

    private void Awake()
    {
        FindOtherShip();
       
    }

    private void Update()
    { 

        if(!isPlayer)
        {
            if(!partAimingAt)
            {
                //Do some AI stuff to determine where to shoot
                int randomInt = Random.Range(1, partsThatCanBeAimedAt.Length) - 1;
                partAimingAt = otherShipController.partsThatCanBeAimedAt[randomInt];
                otherShipController.partBeingAimedAt = partAimingAt;
            }
            
        }

        else if (isPlayer)
        {
            partAimingAt = otherShipController.partBeingAimedAt;
        }
    }


    //Important to note that there can only be one other ship in the scene(for now at least)
    private void FindOtherShip()
    {
        ships = GameObject.FindGameObjectsWithTag("Ship");   

        foreach(GameObject ship in ships)
        {
            if (ship != this.gameObject)
            {
                otherShip = ship;
                otherShipController = otherShip.GetComponent<ShipController>();
            }
        }
    }
}
