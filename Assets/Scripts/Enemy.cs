using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public int health = 5;
	public NavMeshAgent navAgent;
	public GameObject target;  
	int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
  		navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");                                                                                                                                             
    }

    // Update is called once per frame
    void Update(){
    	navAgent.destination = target.transform.position;

    }

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.tag == "Player"){
			print("Damaging Player");
			coll.gameObject.GetComponent<Player>().TakeDamage(damage);

		}

	}

	

    // Damages Enemy when hit with projectile
	public void TakeDamage(){
		// If enemy health is any number above 0 we just take away 1 health
		if(health > 0){
			health -= 1;
			print("ENEMY TAKING DAMAGE");
		}

		// If enemy health is 0 or below, we destroy the enemy
		if(health <= 0){
			Destroy(gameObject);
		}

	}




}


