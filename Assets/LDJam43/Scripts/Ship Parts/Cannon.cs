using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour {

    public GameObject laser;
    public int laserSpeed = 10;

    public int health = 4;

    private AudioSource soundEffect;

    public Slider chargeIndicator;

    private GameObject partAimingAt = null;

    private float timeToCharge = 5f; //Time in seconds
    private float currentTime = 0f;


    private ShipController shipController = null;

    // Use this for initialization
    void Start()
    {
        shipController = this.transform.parent.gameObject.GetComponent<ShipController>();
        soundEffect = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        ChargeCannon();
        GetTarget();
        ShootCannon();
        SetChargeIndicator();
    }
    
    //Function that increases the time
    private void ChargeCannon()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeToCharge)
        {
            currentTime = timeToCharge;
        }
    }

    private void ShootCannon()
    {
        //if you press mousebutton and the current timer is larger than the time to charge, you can shoot
        if (currentTime >= timeToCharge && partAimingAt)
        {
            GameObject newLaser = Instantiate(laser, this.gameObject.transform);
            Rigidbody2D laserRB = newLaser.GetComponent<Rigidbody2D>();
            Vector2 direction = partAimingAt.transform.position - this.transform.position;
            direction.Normalize();
            laserRB.velocity = direction * laserSpeed;
            soundEffect.PlayOneShot(soundEffect.clip);
            currentTime = 0f;
        }
    }

    private void GetTarget()
    {
        partAimingAt = shipController.partAimingAt;
    }

    private void OnEnable()
    {
        currentTime = 0f;

    }

    private void SetChargeIndicator()
    {
        chargeIndicator.value = currentTime / timeToCharge;
    }

    
}
