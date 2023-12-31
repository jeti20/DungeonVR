using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesKorytarzTrigger : MonoBehaviour
{
    [SerializeField] private Animator animatorSpikesKorytarz;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Brick"))
        {
            animatorSpikesKorytarz.SetBool("TrigerSpikesKorytarz", true);
        }       
    }  
}
