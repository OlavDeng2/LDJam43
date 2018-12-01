using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject laser;
    public int health = 4;

    private GameObject ship = null;
    private float timeToCharge = 5f; //Time in seconds
    private float currentTime = 0f;

    // Use this for initialization
    void Start()
    {
        ship = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        ChargeCannon();
        ShootCannon();
        
        
    }
    
    private void ChargeCannon()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeToCharge)
        {
            print("cannonCharged");
        }
    }

    private void ShootCannon()
    {
        if (Input.GetMouseButtonDown(0) && currentTime > timeToCharge)
        {
            GameObject newLaser = Instantiate(laser, this.gameObject.transform);
            Rigidbody2D laserRB = newLaser.GetComponent<Rigidbody2D>();
            laserRB.velocity = new Vector2(1, 0);
            currentTime = 0f;
        }
    }
}
