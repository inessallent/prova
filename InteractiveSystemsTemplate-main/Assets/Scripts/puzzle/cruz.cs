using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cruz : MonoBehaviour
{
    private bool isAttachedToPlayer = false;
    private Transform originalParent;
    public Transform targetPoint;  // The specific point where the cruz will be placed

    // Start is called before the first frame update
    void Start()
    {
        originalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAttachedToPlayer)
        {
            // Attach cruz to the player
            transform.SetParent(other.transform);
            isAttachedToPlayer = true;
        }
        else if (other.CompareTag("plat") && isAttachedToPlayer)
        {
            // Detach cruz from the player and place it correctly on the platform
            transform.SetParent(originalParent); // Detach from player
            PlaceCruzOnPoint(); // Place the cruz on the specific point
            isAttachedToPlayer = false;
        }
    }

    // Function to place the cruz on the specific point on the platform
    private void PlaceCruzOnPoint()
    {
        if (targetPoint != null)
        {
            transform.position = targetPoint.position;
            transform.rotation = targetPoint.rotation;
        }
    }
}


