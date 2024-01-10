using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Sphere : MonoBehaviour

{
    Rigidbody rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        // Accéder au composant Renderer de l'objet avec lequel la collision se produit
        Renderer collidedObjectRenderer = collision.gameObject.GetComponent<Renderer>();

        if (collidedObjectRenderer != null)
        {
            // Changer la couleur de l'objet
            Color randomColor = Random.ColorHSV();

            // Changer la couleur de l'objet
            collidedObjectRenderer.material.color = randomColor; // Vous pouvez utiliser n'importe quelle couleur que vous souhaitez
        }

    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float speed = 10f;

        Vector3 newPosition = currentPosition + direction * speed * Time.deltaTime;


        rigidbody.MovePosition(newPosition);
    }
}
