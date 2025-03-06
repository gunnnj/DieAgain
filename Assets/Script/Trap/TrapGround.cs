using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGround : MonoBehaviour
{
    private float fallDistance = 8f; 
    [SerializeField] private float speed = 5f; 
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {

        if (transform.position.y > startPosition.y - fallDistance)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            enabled = false; 
        }
    }
    
}
