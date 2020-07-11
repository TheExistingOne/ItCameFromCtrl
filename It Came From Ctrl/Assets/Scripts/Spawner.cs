using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int[] spawncountByWave;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenSpawns;

    private int _wave = 0;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 && _wave < spawncountByWave.Length - 1)
        {
            StartCoroutine(SpawnWave());
            _wave++;
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < spawncountByWave[_wave]; i++)
        {
            Instantiate(enemyPrefab);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        yield return null;
    }
}
