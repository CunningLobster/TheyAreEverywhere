using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] Transform target;

    void Update()
    {
        FindClosestObject();
        AimWeapon();
    }

    void FindClosestObject()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float distanceToTarget = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToTarget < maxDistance)
            {
                closestTarget = enemy.transform;
                distanceToTarget = maxDistance;
            }
        }

        target = closestTarget;
    }
    void AimWeapon()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if (distanceToTarget < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emission = projectileParticles.emission;
        emission.enabled = isActive;
    }


}
