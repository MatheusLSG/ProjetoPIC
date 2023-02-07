using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOLA : MonoBehaviour
{
    Renderer rend;
    //Rigidbody tb;
    public float timer = 0;
    public bool respawn = false;
    private GameObject cubo;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //rb = GetComponent<Rigidbody>();
        rend.enabled = true;
        cubo = GameObject.Find("Cube");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<3){
            transform.position = new Vector3(0,20,0);
            transform.rotation = Quaternion.Euler(0,0,0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            timer+= Time.deltaTime;
        }

        if(respawn)
        {
            if(Input.GetKeyDown("return")){
                timer = 0;
                rend.enabled = true;
                respawn = false;
                transform.position = new Vector3(0,20,0);
                transform.rotation = Quaternion.Euler(0,0,0);
                GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log($"{contact.otherCollider.name}");
            if(contact.otherCollider.name == "Plane"){
               respawn = true;
               rend.enabled = false;
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
