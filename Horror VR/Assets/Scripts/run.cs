using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Prêdkoœæ poruszania siê NPC

    private Animator animator;
    private bool isRunning = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartRunning();
    }

    private void Update()
    {
        if (isRunning)
        {
            // Poruszanie NPC do przodu
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartRunning();
        }
    }

    private void StartRunning()
    {
        isRunning = true;
        animator.SetBool("IsRunning", true);
    }
}
