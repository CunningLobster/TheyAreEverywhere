using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth = 5;

    void OnEnable()
    {
        health = maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        ReduseHealth();
        EnemyDiying();
    }

    void ReduseHealth()
    {
        health -= 1;
    }

    void EnemyDiying()
    {
        if (health < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
