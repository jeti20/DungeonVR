using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGuard : MonoBehaviour
{
    int HP = 100;
    public Animator animator;
    [SerializeField] AudioSource audioKill;
    [SerializeField] AudioSource audioHit;

    bool isKilled = false;


    public void TakeDamage(int damageAmout)
    {
        HP -= damageAmout;
        audioHit.Play();
        if (HP <= 0)
        {
            RagdollON ragdollComponent = GetComponent<RagdollON>();

            // Je�li komponent istnieje i jest wy��czony, w��cz go
            if (ragdollComponent != null && !ragdollComponent.enabled)
            {
                ragdollComponent.enabled = true;
                Debug.Log("W��czono komponent RagdollON na obiekcie.");
                StartCoroutine(LoadSceneDelay());
            }
            else
            {
                Debug.Log("Nie mo�na znale�� lub komponent RagdollON jest ju� w��czony.");
            }
        }
        else
        {
            if (isKilled == false)
            {
                audioKill.Play();
                isKilled = true;
            }
            animator.SetBool("isHited", true);
            animator.SetTrigger("damage");
        }
    }

    IEnumerator LoadSceneDelay() 
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Game");
    }
}
