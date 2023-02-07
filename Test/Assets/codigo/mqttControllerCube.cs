using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class mqttControllerCube : MonoBehaviour
{
  private BOLA sc;
  private GameObject bola;
  public Quaternion target;
  float gy_x=0, gy_y=0, gy_z=0;
  Quaternion gy;
  int contador = -1; 
  bool trava = false;
  float[] vetorX = new float[100];
  float[] vetorY = new float[100];
  float[] vetorZ = new float[100];

  
  float smooth = 1f;
  public string nameController = "Controller 1";
  public string tagOfTheMQTTReceiver="";
  public mqttReceiver _eventSender;

  void Start()
  {
    bola = GameObject.Find("Sphere");
    sc = bola.GetComponent<BOLA>();
      _eventSender=GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<mqttReceiver>();
    _eventSender.OnMessageArrived += OnMessageArrivedHandler;
  
    gy = transform.rotation;
  }

  private void OnMessageArrivedHandler(string newMsg)
  {
    //Debug.Log("Event Fired. The message, from Object " +nameController+" is = " + newMsg);

    float x,y,z;

    var tudo = newMsg.Split(';');
    var aclr = tudo[0].Split(',');
    var gyro = tudo[1].Split(',');

    
    if(float.TryParse(gyro[0], out x) && float.TryParse(gyro[1], out y) && float.TryParse(gyro[2], out z)){
      

      Debug.Log($"{x},{y},{z}");

      if(sc.timer >= 3){
        gy *= Quaternion.AngleAxis(x/1.5f, Vector3.right);
        gy *= Quaternion.AngleAxis(z/1.85f, Vector3.up);
        gy *= Quaternion.AngleAxis(y/1.75f, Vector3.forward);
      }
    }

  }

  public GameObject targetR;
  private void Update() {
    
      if(sc.timer >= 3){
        if (Input.GetKeyDown("a")){
          gy *= Quaternion.AngleAxis(45, Vector3.right);
        }
      }
    // Dampen towards the target rotation
    transform.rotation = Quaternion.Slerp(transform.rotation, gy,  Time.deltaTime * smooth);
 
    //restart cube
    if (sc.respawn == false && sc.timer < 3)
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        gy = Quaternion.Euler(0,0,0);
    }

    if (Input.GetKeyDown("c"))
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        gy = Quaternion.Euler(0,0,0);
    }
  }
}

        