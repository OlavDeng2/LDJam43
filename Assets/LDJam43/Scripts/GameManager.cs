using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject shipPrefab;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
        enemyController.currentHealth = 4;
    }

    public void FindShips()
    {
        playerController.FindOtherShip();
        enemyController.FindOtherShip();
    }
}
