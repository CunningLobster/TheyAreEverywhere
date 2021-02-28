using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnDelay = 1f;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        foreach (var item in pool)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                return;
            }
        }
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
