using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycasting : MonoBehaviour
{

    public float moveSpeed = 20f;

    void Update()
    {
        RaycastHit hit;

        // Créez un rayon depuis la position de l'objet (transform.position) vers la position de la souris à l'écran
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));


        // Utilisez Physics.Raycast pour vérifier si le rayon touche un objet dans une plage de 100 unités
        if (Physics.Raycast(ray, out hit, 100f))
        {
            // Vérifiez si l'objet touché a un composant Collider
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;

                if (Mouse.current.rightButton.wasPressedThisFrame)
                {

                    // Calculez la direction vers la caméra
                    Vector3 directionToCamera = Camera.main.transform.position - hitObject.transform.position;

                    // Normalisez la direction pour obtenir une unité de vecteur
                    directionToCamera.Normalize();

                    // Déplacez l'objet vers la caméra
                    hitObject.transform.Translate(directionToCamera * moveSpeed * Time.deltaTime, Space.World);


                }

                    //Debug.Log("Objet pointé");
                

            }
        }
    }
}

