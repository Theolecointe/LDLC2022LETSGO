using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaquePression : MonoBehaviour
{
    [SerializeField] int nombreRandom;
    [SerializeField] private GameObject door;
  
    
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Il y a eu collision !!!");
    }

    private void Update()
    {
    }

    void OnTriggerStay(Collider collider)
    {
        door.SetActive(false);
    }
    
    
    void OnTriggerExit(Collider collider)
    {
        door.SetActive(true);
    }
}
