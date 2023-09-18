using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRoom : MonoBehaviour
{
    public string playerTag = "Player"; // Tag gracza
    public Animator[] animators; // Tablica animacji, do kt�rej chcesz doda� obiekty
    private bool animacjeWlaczane = false;

    public Animator animatorEndedKillPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !animacjeWlaczane)
        {
            // W��cz animacje na wszystkich obiektach
            foreach (var animator in animators)
            {
                animator.enabled = true;
                Debug.Log("W��cz animacje");
            }

            StartCoroutine(WaitForAnimationAndKillPlayer());
            animacjeWlaczane = true; // Zapobieganie wielokrotnemu uruchamianiu

        }
    }

    private IEnumerator WaitForAnimationAndKillPlayer()
    {
        // Poczekaj na zako�czenie animacji przesuwania �ciany.
        yield return new WaitForSeconds(animatorEndedKillPlayer.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // Zabij gracza lub zako�cz gr�.
        Debug.Log("TheEnd");
    }
}
