using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float minSpawnInterval = 3f;
    private float maxSpawnInterval = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
       // InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
       StartCoroutine(RandomSpawnTime());
    }

    // Spawn random ball at r(andom x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[Random.Range(0,ballPrefabs.Length)], spawnPos, ballPrefabs[Random.Range(0,ballPrefabs.Length)].transform.rotation);
    }

    IEnumerator RandomSpawnTime()
    {
        yield return new WaitForSeconds(startDelay); 
        while (true)
        {
            SpawnRandomBall();
            float randomInterval = Random.Range(minSpawnInterval,maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }

}
