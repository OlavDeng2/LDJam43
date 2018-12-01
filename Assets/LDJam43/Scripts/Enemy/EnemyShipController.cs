using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour {

    public GameObject outroPanel;

    public GameObject[] engines;
    public GameObject[] shieldGenerators;
    public GameObject[] fuelTanks;
    public GameObject[] cannons;
    public GameObject[] cockpits;
    public GameObject[] hulls;
    public GameObject[] wings;
    public GameObject laser;

    public int health = 4;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        Destroy(collision.gameObject);

        if (health <= 0)
        {
            outroPanel.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
