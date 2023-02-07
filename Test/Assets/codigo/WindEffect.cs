using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour
{
    public Vector3 center_point;
    public GameObject windZone;
    public Vector3 direction;
    Quaternion a;
    public int rotacao;

    void Start()
    {
        windZone = GameObject.Find("WindAreaBlock");
    }

    // Update is called once per frame
    void Update()
    {
        direction = windZone.GetComponent<WindArea>().direction; 

        if(direction.x==1)  // Vai para direita
        {
            a = Quaternion.Euler(0,0,0);
        }
        else if(direction.x==-1) // Empurra pra esquerda
        {
            a = Quaternion.Euler(0,180,0);
        }
        else if(direction.z==1) //Empurra pra frente
        {
            a = Quaternion.Euler(0,270,0);
        }
        else    // Empurra pra tras
        {
            a = Quaternion.Euler(0,90,0);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation,a,Time.deltaTime*100);
    }
}
