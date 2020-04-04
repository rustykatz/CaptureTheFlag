using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 10;

    float lookHorizontal = 0;
    float lookVertical = 0;

    public GameObject orangePortalPrefab;
    public GameObject bluePortalPrefab;

    public static GameObject orangePortal;
    public static GameObject bluePortal;
    
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Movement();
        Look();
        ShootPortal();
    }

    // Controls player movement using (W,A,S,D) keys 
    void Movement(){
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Controls where the player looks
    void Look(){
        lookHorizontal += Input.GetAxis("Mouse X");
        lookVertical += Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(-lookVertical, lookHorizontal, 0f);

    }
    

    // Allows players to spawn portals using mouse buttons
    void ShootPortal(){

        // Left Mouse button -> Orange Portal
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward; 
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Quaternion rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                if (orangePortal != null)
                {
                    Destroy(orangePortal);
                }

                orangePortal = (GameObject)Instantiate(orangePortalPrefab, hit.point + (Vector3.up * 0.5f), rotation);
            }
        }

        // Right Mouse button -> Blue Portal
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position; 
            ray.direction = Camera.main.transform.forward;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Quaternion rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                if (bluePortal != null)
                {
                    Destroy(bluePortal);
                }
                bluePortal = (GameObject)Instantiate(bluePortalPrefab, hit.point + (Vector3.up * 0.5f), rotation);
            }
        }

    }

}