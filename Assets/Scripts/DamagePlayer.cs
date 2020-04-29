using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    int damage = 2; 

    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "Player"){
            coll.GetComponent<Player>().TakeDamage(damage);
            print("Damaging Player!");
            Destroy(gameObject);
        }
    }
}
