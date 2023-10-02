using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGuard : MonoBehaviour
{
    int HP = 100;
    public Animator animator;
    [SerializeField] AudioSource killMesound;

    private void OnTriggerEnter(Collider other)
    {
        if (HP <= 0)
        {
            RagdollON ragdollComponent = GetComponent<RagdollON>();

            // Je�li komponent istnieje i jest wy��czony, w��cz go
            if (ragdollComponent != null && !ragdollComponent.enabled)
            {
                ragdollComponent.enabled = true;
                Debug.Log("W��czono komponent RagdollON na obiekcie.");
            }
            else
            {
                Debug.Log("Nie mo�na znale�� lub komponent RagdollON jest ju� w��czony.");
            }
        }
        else if (other.CompareTag("Weapon"))
        {
            animator.SetBool("isHited", true);
            killMesound.Play();
        }
    }       
}
