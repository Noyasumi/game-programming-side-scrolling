using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private float spawnRange;
    [SerializeField] private float spawnTime;
    [SerializeField] private int spawnAmount;

    public void Start()
    {
        StartCoroutine(Spawn(spawnAmount));
    }

    private IEnumerator Spawn (int count)
    {
        while (count > 0)
        {
            float spawnX = Random.Range(spawnLocation.position.x - spawnRange, spawnLocation.position.x + spawnRange);
            Vector3 newSpawn = new Vector3(spawnX, spawnLocation.position.y, spawnLocation.position.z);
            Instantiate(enemy, newSpawn, Quaternion.identity);
            count--;
            yield return new WaitForSeconds(spawnTime);
        }
    }

}
