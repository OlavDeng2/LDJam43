using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject shipPrefab;
    public GameObject gameOverPanel;


    //Player ship stats
    private GameObject playerShip;
    private ShipController playerController;
    public Transform playerPos;

    //Enemy ship stats
    private GameObject enemyShip;
    private ShipController enemyController;
    public Transform enemyPos;

    

	// Use this for initialization
	void Start () {
        
        gameOverPanel.SetActive(false);
	}


    public void SpawnPlayer()
    {
        playerShip = Instantiate(shipPrefab, playerPos);
        playerController = playerShip.GetComponent<ShipController>();
        playerController.hitChance = 30;
    }

    public void DisablePlayer()
    {
        playerShip.SetActive(false);
    }

    public void EnablePlayer()
    {
        playerShip.SetActive(true);
    }

    public void SpawnEnemy()
    {
        enemyShip = Instantiate(shipPrefab, enemyPos);
        enemyController = enemyShip.GetComponent<ShipController>();
        enemyController.isPlayer = false;
        enemyController.currentHealth = 8;
    }

    public void FindShips()
    {
        playerController.FindOtherShip();
        enemyController.FindOtherShip();

    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void DestroyShipPart(string part)
    {


        Engine[] shipEngines = playerShip.GetComponentsInChildren<Engine>(true);
        ShieldGenerat[] shieldGenerators = playerShip.GetComponentsInChildren<ShieldGenerat>();
        FuelTank[] fuelTanks = playerShip.GetComponentsInChildren<FuelTank>();
        Cannon[] cannons = playerShip.GetComponentsInChildren<Cannon>();
        Wing[] wings = playerShip.GetComponentsInChildren<Wing>();

        if (part == "Engine")
        {
            int randomInt = Random.Range(1, shipEngines.Length);
            Destroy(shipEngines[randomInt - 1].gameObject);

        }

        if (part == "ShieldGenerator")
        {
            int randomInt = Random.Range(1, shieldGenerators.Length);
            Destroy(shieldGenerators[randomInt - 1].gameObject);


        }

        if (part == "FuelTank")
        {
            int randomInt = Random.Range(1, fuelTanks.Length);
            Destroy(fuelTanks[randomInt - 1].gameObject);
        }

        if (part == "Cannon")
        {
            int randomInt = Random.Range(1, cannons.Length);
            Destroy(cannons[randomInt - 1].gameObject);
        }

        if (part == "Wing")
        {
            int randomInt = Random.Range(1, wings.Length);
            Destroy(wings[randomInt - 1].gameObject);
        }
    }
}
