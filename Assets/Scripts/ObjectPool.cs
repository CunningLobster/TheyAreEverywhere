using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0f, 50f)]int poolSize = 5;
    [SerializeField] [Range(.1f, 30f)] float spawnDelay = 1f;

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
            pool[i].name = pool[i].name + i.ToString();
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
