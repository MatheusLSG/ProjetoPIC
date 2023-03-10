using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    private int choice;
    public float strenght;
    public Vector3 direction;
    public float passed_time;
    private BOLA sc;
    private GameObject bola;

    void Start()
    {
        bola = GameObject.Find("Sphere");
        sc = bola.GetComponent<BOLA>();
        strenght = 1;
        direction = new Vector3(1,0,0);
        passed_time = 0;
    }

    void Update()
    {
        if(sc.ImInGame == false)
        {
            strenght = 1;
            direction = new Vector3(1,0,0);
            passed_time = 0;
        }
        else
        {        
            passed_time+=Time.deltaTime;

            if(passed_time>=15)
            {
                strenght++;
                choice = Random.Range(1,5);
                if(choice==1)
                {
                    direction= new Vector3(1,0,0);
                }
                else if(choice==2)
                {
                    direction = new Vector3(-1,0,0);
                }
                else if(choice==3)
                { 
                    direction = new Vector3(0,0,1);
                }
                else
                {
                    direction = new Vector3(0,0,-1);
                }
                passed_time = 0;
            }
        }
    }
}
