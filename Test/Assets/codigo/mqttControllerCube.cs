using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class mqttControllerCube : MonoBehaviour
{
  public Quaternion target;
  float gy_x=0, gy_y=0, gy_z=0;
  Quaternion gy;
  int contador = -1; 
  bool trava = true;
  float[] vetorX = new float[100];
  float[] vetorY = new float[100];
  float[] vetorZ = new float[100];

  float m_x1, m_y1, m_z1, m_x2, m_y2, m_z2; 

  
  float smooth = 1f;
  public string nameController = "Controller 1";
  public string tagOfTheMQTTReceiver="";
  public mqttReceiver _eventSender;

  void Start()
  {
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

      gy *= Quaternion.AngleAxis(x/1.5f, Vector3.right);
      gy *= Quaternion.AngleAxis(z/1.85f, Vector3.up);
      gy *= Quaternion.AngleAxis(y/1.75f, Vector3.forward);
      
    }

  }

  public GameObject targetR;
  private void Update() {
    
    //Debug.Log($"{target.x},{target.y},{target.z}");
    // Dampen towards the target rotation
    transform.rotation = Quaternion.Slerp(transform.rotation, gy,  Time.deltaTime * smooth);
    
    if (Input.GetKeyDown(KeyCode.D))
    {
      //transform.RotateAround(targetR.transform.position, transform.right, 10 * Time.deltaTime);
      gy *= Quaternion.AngleAxis(45, Vector3.right);
    }
    if (Input.GetKeyDown(KeyCode.W))
    {
      //transform.RotateAround(targetR.transform.position, transform.up, 10 * Time.deltaTime);
      gy *= Quaternion.AngleAxis(45, Vector3.up);
    }
    if (Input.GetKeyDown(KeyCode.S))
    {
      //transform.RotateAround(targetR.transform.position, transform.forward, 10 * Time.deltaTime);
      gy *= Quaternion.AngleAxis(45, Vector3.forward);
    }
    

    //restart cube
    if (Input.GetKeyDown(KeyCode.C))
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        gy = Quaternion.Euler(0,0,0);
    }
  }
}

        