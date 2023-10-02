using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMainMenu : MonoBehaviour
{
    public int damageomout = 50;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<MainMenuGuard>().TakeDamage(20);

        }

    }
}
