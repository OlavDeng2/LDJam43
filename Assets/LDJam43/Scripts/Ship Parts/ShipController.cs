using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

    public int maxHealth = 20;
    public int currentHealth = 20;
    public int hitChance = 70;

    public bool isPlayer;
    public GameObject outroPanel;
    public GameManager gameManager;

    public GameObject shipUI;
    public Slider shipHealthSlider;

    private GameObject[] ships;
    public GameObject otherShip;
    public ShipController otherShipController;
    public GameObject partBeingAimedAt;
    public GameObject partAimingAt;


    public GameObject[] partsThatCanBeAimedAt;

    public MapPoint mapPoint;

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
        mapPoint = FindObjectOfType<MapPoint>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if (!isPlayer)
        {
            if (!partAimingAt)
            {
                //Do some AI stuff to determine where to shoot
                int randomInt = Random.Range(1, partsThatCanBeAimedAt.Length) - 1;
                partAimingAt = otherShipController.partsThatCanBeAimedAt[randomInt];
                otherShipController.partBeingAimedAt = partAimingAt;
            }
            shipUI.SetActive(false);

        }

        else if (isPlayer)
        {
            partAimingAt = otherShipController.partBeingAimedAt;
            UpdateShipHealthSlider();
        }
    }


    //Important to note that there can only be one other ship in the scene(for now at least)
    public void FindOtherShip()
    {
        ships = GameObject.FindGameObjectsWithTag("Ship");

        foreach (GameObject ship in ships)
        {
            if (ship != this.gameObject)
            {
                otherShip = ship;
                otherShipController = otherShip.GetComponent<ShipController>();
            }
        }
    }

    private void OnDestroy()
    {
        if(!isPlayer)
        {
            mapPoint.OpenPanel(mapPoint.outroPanel);
            gameManager.DisablePlayer();
        }

        if (isPlayer)
        {
            gameManager.GameOver();
            print("player ship destroyed");
        }
        
    }

    private void UpdateShipHealthSlider()
    {
        shipHealthSlider.maxValue = maxHealth;
        shipHealthSlider.value = currentHealth;
    }
}
