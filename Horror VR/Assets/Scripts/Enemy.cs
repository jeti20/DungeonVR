using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;

    public void TakeDamage(int damageAmout)
    {
        HP -= damageAmout;
        if (HP <= 0)
        {
            RagdollON ragdollComponent = GetComponent<RagdollON>();

            // Jeœli komponent istnieje i jest wy³¹czony, w³¹cz go
            if (ragdollComponent != null && !ragdollComponent.enabled)
            {
                ragdollComponent.enabled = true;
                Debug.Log("W³¹czono komponent RagdollON na obiekcie.");
            }
            else
            {
                Debug.Log("Nie mo¿na znaleŸæ lub komponent RagdollON jest ju¿ w³¹czony.");
            }
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
