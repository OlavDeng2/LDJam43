using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject laser;
    public int laserSpeed = 10;

    public int health = 4;


    private GameObject partAimingAt = null;

    private float timeToCharge = 5f; //Time in seconds
    private float currentTime = 0f;


    private ShipController shipController = null;

    // Use this for initialization
    void Start()
    {
        shipController = this.transform.parent.gameObject.GetComponent<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {

        ChargeCannon();
        GetTarget();
        ShootCannon();
    }
    
    //Function that increases the time
    private void ChargeCannon()
    {
        currentTime += Time.deltaTime;
    }

    private void ShootCannon()
    {
        //if you press mousebutton and the current timer is larger than the time to charge, you can shoot
        if (currentTime > timeToCharge && partAimingAt)
        {
            GameObject newLaser = Instantiate(laser, this.gameObject.transform);
            Rigidbody2D laserRB = newLaser.GetComponent<Rigidbody2D>();
            Vector2 direction = partAimingAt.transform.position - this.transform.position;
            direction.Normalize();
            laserRB.velocity = direction * laserSpeed;
            currentTime = 0f;
        }
    }

    private void GetTarget()
    {
        partAimingAt = shipController.partAimingAt;
    }
}
