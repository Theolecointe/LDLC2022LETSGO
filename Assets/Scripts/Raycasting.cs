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

        // Cr�ez un rayon depuis la position de l'objet (transform.position) vers la position de la souris � l'�cran
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));


        // Utilisez Physics.Raycast pour v�rifier si le rayon touche un objet dans une plage de 100 unit�s
        if (Physics.Raycast(ray, out hit, 100f))
        {
            // V�rifiez si l'objet touch� a un composant Collider
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;

                if (Mouse.current.rightButton.wasPressedThisFrame)
                {

                    // Calculez la direction vers la cam�ra
                    Vector3 directionToCamera = Camera.main.transform.position - hitObject.transform.position;

                    // Normalisez la direction pour obtenir une unit� de vecteur
                    directionToCamera.Normalize();

                    // D�placez l'objet vers la cam�ra
                    hitObject.transform.Translate(directionToCamera * moveSpeed * Time.deltaTime, Space.World);


                }

                    //Debug.Log("Objet point�");
                

            }
        }
    }
}

