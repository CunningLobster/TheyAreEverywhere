using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth = 5;

    [Tooltip("Add heath to the max amount, when this object is dies")]
    [SerializeField] int difficultyRamp = 1;

    Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

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
            maxHealth += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
