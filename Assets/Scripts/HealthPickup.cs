using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    int value = 2; 

     void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "Player"){
            coll.GetComponent<Player>().AddHealth(value);
            print("Picked up Health!");
            Destroy(gameObject);
        }
    }

}
