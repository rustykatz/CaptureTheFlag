using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Portal : MonoBehaviour
{
    public string otherPortalTag;
    GameObject otherPortal;
    public Transform exit;

    void Start()
    {

    }

    void Update()
    {

        //transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);

    }
    // Use this for initialization void Start () {
    // Update is called once per frame void Update () {


    void OnCollisionEnter(Collision coll)
    {
        print(coll.gameObject.tag);
        if (coll.gameObject.tag == "Player")
        {
            otherPortal = GameObject.FindGameObjectWithTag(otherPortalTag);
            Debug.Log("collides");
            if (otherPortal != null)
            {
                coll.transform.position = otherPortal.GetComponent<Portal>().exit.position;
              //  coll.transform.rotation = otherPortal.GetComponent<Portal>().exit.rotation;
            }
        }
    }
}
