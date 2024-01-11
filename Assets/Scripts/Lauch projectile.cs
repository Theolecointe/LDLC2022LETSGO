using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Lauchprojectile : MonoBehaviour
{
   

    [SerializeField] GameObject projectilePrefab;

    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        Debug.Log("started");
    }
    void Update()
    {
        //Effectuer une action lorsque l'utilisateur clique (dans l'Update) :
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(projectilePrefab, Camera.main.transform.position + Camera.main.transform.forward * 2, Camera.main.transform.rotation);
            audioData.Play(0);

            Debug.Log("Pause: " + audioData.time);
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            
        }
    }
   
    }



