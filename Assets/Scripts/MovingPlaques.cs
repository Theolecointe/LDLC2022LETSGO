using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlaques : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 startPosition;
    float distance = 2f;
    Vector3 direction = new Vector3(-1f, 0f, 0f);
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {


        if (Vector3.Distance(startPosition, transform.position) >= distance)
        {
            direction = -direction; // Change la direction
            startPosition = transform.position;// Réinitialise la position de départ pour le nouveau mouvement
        }

         Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
         rigidbody.MovePosition(newPosition);


        //rigidbody.MovePosition(newPosition);

    }
}
