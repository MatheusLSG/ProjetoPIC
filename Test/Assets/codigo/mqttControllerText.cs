using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class mqttControllerText : MonoBehaviour
{
    public string nameController = "Controller 1";
    public string tagOfTheMQTTReceiver="";
    public mqttReceiver _eventSender;

  void Start()
  {
      _eventSender=GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<mqttReceiver>();
    _eventSender.OnMessageArrived += OnMessageArrivedHandler;
  }

  private void OnMessageArrivedHandler(string newMsg)
  {
    this.GetComponent<TextMeshPro>().text= (newMsg.Split(';'))[1];
  }
}