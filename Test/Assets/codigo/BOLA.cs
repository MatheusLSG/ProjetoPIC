using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOLA : MonoBehaviour
{
    private GameObject cubo;
    public bool inWindZone = false;
    public GameObject windZone;

    // Start is called before the first frame update
    void Start()
    {
        cubo = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(inWindZone)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strenght);    
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            windZone = coll.gameObject;
            inWindZone = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            inWindZone = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log($"{contact.otherCollider.name}");
            if(contact.otherCollider.name == "Plane"){
                transform.position = new Vector3(0,20,0);
                transform.rotation = Quaternion.Euler(0,0,0);
                GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
            }


        }
        /*
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(explosionPrefab, position, rotation);
        
        transform.position(0,20,0);
        */
    }
}
