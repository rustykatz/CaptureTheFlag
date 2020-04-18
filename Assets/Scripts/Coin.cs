using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int value = 1;
    
    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "Player"){
            coll.GetComponent<Player>().AddCoin(value);
            print("Picked up coin!");
            Destroy(gameObject);

        }
    }

}
