using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour {

    public int health = 4;
    private int hitChance;

    private ShipController shipController = null;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        shipController = this.transform.parent.gameObject.GetComponent<ShipController>();
        hitChance = shipController.hitChance;
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (shipController.partBeingAimedAt != this.gameObject)
        {
            //Create logic to set the standard sprite
        }
    }

    private void TakeDamage()
    {
        health--;
        shipController.currentHealth--;
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!shipController.isPlayer)
        {
            shipController.partBeingAimedAt = this.gameObject;

            //Change the colour of the sprite to yellow, in future it will switch sprites
            sprite.color = Color.yellow;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shipController.partBeingAimedAt == this.gameObject)
        {
            //Random Chance that the laser will miss
            int randomInt = Random.Range(1, 100);
            if (randomInt < hitChance)
            {
                print("miss");
                Destroy(collision.gameObject);
                TakeDamage();
            }

        }
    }

    private void OnDestroy()
    {
        shipController.partBeingAimedAt = null;
        shipController.hitChance += 10;
    }
}
