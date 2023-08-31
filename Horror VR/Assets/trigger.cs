using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public float pushForce = 10f;  // Si≥a wyrzutu
    public GameObject objectToPush; // Obiekt do wyrzucenia

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Sprawdü, czy jest przypisany obiekt do wyrzucenia
            if (objectToPush != null)
            {
                Rigidbody rb = objectToPush.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Oblicz kierunek wyrzutu (do ty≥u) i zastosuj si≥Í
                    Vector3 pushDirection = other.transform.forward;
                    rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
                }
            }
        }
    }
}
