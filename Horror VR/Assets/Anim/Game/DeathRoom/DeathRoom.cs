using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRoom : MonoBehaviour
{

    private bool isPlayerInTrigger = false;
    private bool isAnimationEnded = false;

    public string playerTag = "Player"; // Tag gracza
    public Animator[] animators; // Tablica animacji, do której chcesz dodaæ obiekty
    private bool animationsEnabled = false;

    public Animator animatorEndedKillPlayer;

    private void Update()
    {
        if (isPlayerInTrigger && isAnimationEnded)
        {
            SceneManager.LoadScene("End");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PlayerWTrigerze");
        if (other.CompareTag("Player") && !animationsEnabled)
        {
            // W³¹cz animacje na wszystkich obiektach
            foreach (var animator in animators)
            {
                animator.enabled = true;
                Debug.Log("W³¹cz animacje");
            }

            StartCoroutine(WaitForAnimationAndKillPlayer());
            animationsEnabled = true; // Zapobieganie wielokrotnemu uruchamianiu
            isPlayerInTrigger = true;
        }
    }

    private IEnumerator WaitForAnimationAndKillPlayer()
    {
        // Poczekaj na zakoñczenie animacji przesuwania œciany.
        yield return new WaitForSeconds(animatorEndedKillPlayer.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        // Zabij gracza lub zakoñcz grê.
        isAnimationEnded = true;
        
        Debug.Log("TheEnd");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            Debug.Log("GraczWyszed³");
        }
    }
}
