using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
    	// Check if object that we are colliding with has the tag "Enemy"
		if(col.gameObject.tag == "Enemy"){

			// This gets the Enemy script and calls the TakeDamage function. This will
			// Decrease our enemies health by 1 
			col.GetComponent<Enemy>().TakeDamage();
			// We want to destroy the projectile after it collides with our enemy
			Destroy(gameObject);
		}

	}
}
