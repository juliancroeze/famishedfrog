using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnScript : MonoBehaviour
{
    public GameObject modelPrefab;
    public GameObject modelPrefabFireFly;
    public GameObject[] spawnPoints;
    public GameObject[] randomSpawnPoints;
    
    private float time = 0.0f;
    public float interpolationPeriod = 5f;
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnFlies();
    }

    void spawnFlies()
    {
        if (spawnPoints.Length > 2)
        {
            RemoveFlies();

            randomSpawnPoints = new GameObject[3];

            for (int i = 0; i < 4; i++)
            {
                GameObject randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                if (IsNotInArray(randomSpawnPoints, randomSpawnPoint))
                {
                    if(i == 0) {
                        spawnFireFly(randomSpawnPoint);
                    }
                    randomSpawnPoints[i] = randomSpawnPoint;
                    Vector3 spawnPosition = randomSpawnPoint.transform.position;
                    Instantiate(modelPrefab, spawnPosition, Quaternion.identity);
                } else {
                    i--;
                }
            }
        }
        else
        {
            Debug.Log("Geen SpawnPoints gevonden!");
        }
    }

    void spawnFireFly(GameObject spawnPoint) {
        Vector3 spawnPosition = spawnPoint.transform.position;
        GameObject fireFly = Instantiate(modelPrefabFireFly, spawnPosition, Quaternion.identity);
        fireFly.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time -= interpolationPeriod;
            spawnFlies();
        }
    }


    void RemoveFlies()
    {
        GameObject[] existingFlies = GameObject.FindGameObjectsWithTag("Fly");
        foreach (GameObject fly in existingFlies)
        {
            Destroy(fly);
        }
    }

    bool IsNotInArray(GameObject[] array, GameObject element)
    {
        return !System.Array.Exists(array, e => e == element);
    }
}