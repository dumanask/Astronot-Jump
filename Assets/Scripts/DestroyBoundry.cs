using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoundry : MonoBehaviour
{
    [SerializeField]
    private Transform playerDistance;

    public float downBoundry = 20;
    private float distancePlayerToObjects;
    
    void Update()
    {
        // Calculate distance value between character and objects
        distancePlayerToObjects = (playerDistance.transform.position - transform.position).y;

        // Destroy objects if distance value greater than boundry
        if (distancePlayerToObjects >= downBoundry && gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }

}
