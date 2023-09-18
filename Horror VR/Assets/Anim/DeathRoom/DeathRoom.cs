using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRoom : MonoBehaviour
{
    public string playerTag = "Player"; // Tag gracza
    public Animator[] animators; // Tablica animacji, do której chcesz dodaæ obiekty
    private bool animacjeWlaczane = false;

    public Animator animatorEndedKillPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !animacjeWlaczane)
        {
            // W³¹cz animacje na wszystkich obiektach
            foreach (var animator in animators)
            {
                animator.enabled = true;
                Debug.Log("W³¹cz animacje");
            }

            StartCoroutine(WaitForAnimationAndKillPlayer());
            animacjeWlaczane = true; // Zapobieganie wielokrotnemu uruchamianiu

        }
    }

    private IEnumerator WaitForAnimationAndKillPlayer()
    {
        // Poczekaj na zakoñczenie animacji przesuwania œciany.
        yield return new WaitForSeconds(animatorEndedKillPlayer.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // Zabij gracza lub zakoñcz grê.
        Debug.Log("TheEnd");
    }
}
