using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerMob : MonoBehaviour
{
    public PlayerAttack player;
    public PlayerHealt healt;
    public GameObject Prefab;
    public GameObject topLeft;
    public GameObject topRight;
    public GameObject bottomLeft;
    public GameObject bottomRight;
    public Text text;

    public int maxMobs = 5;
    public float minEnemyDistance = 2f;
    public float noSpawnRadiusX = 5f;
    public float noSpawnRadiusY = 5f;
    public int totalMobDead;

    private int currentMobs = 0;
    private List<GameObject> spawnedMobs = new List<GameObject>();

    void Start()
    {
        SpawnRandomMobs(maxMobs);
    }

    private void Update()
    {
        RemoveMob();
        
        if(spawnedMobs.Count == 0)
        {
            if (maxMobs < 50)
            {
                maxMobs = maxMobs * 2;
                float spawnRate = player.GetSpawnRate();
                spawnRate -= player.GetSpawnRate() / 2;
                player.SetSpawnRate(spawnRate);
                float speed = player.GetSpeed();
                speed = speed * 2;
                player.SetSpeed(speed);
            }
            currentMobs = 0;
            int aux = healt.GetHealt();
            aux += 20;
            healt.SetHealt(aux);
            SpawnRandomMobs(maxMobs);
        }
    }

    void SpawnRandomMobs(int numberOfMobs)
    {
        for (int i = 0; i < numberOfMobs; i++)
        {
            Vector3 spawnPosition = GetValidRandomPosition();
            GameObject newMob = Instantiate(Prefab, spawnPosition, Quaternion.identity);
            spawnedMobs.Add(newMob);
            currentMobs++;
        }
    }

    Vector3 GetValidRandomPosition()
    {
        Vector3 spawnPosition;
        bool validPosition = false;
        int attempts = 0;
        Vector3 playerPosition = transform.position;

        while (!validPosition && attempts < 100)
        {
            spawnPosition = GetRandomPositionWithinMap();

            if (spawnPosition.x > playerPosition.x - noSpawnRadiusX && spawnPosition.x < playerPosition.x + noSpawnRadiusX &&
                spawnPosition.y > playerPosition.y - noSpawnRadiusY && spawnPosition.y < playerPosition.y + noSpawnRadiusY)
            {
                attempts++;
                continue;
            }

            validPosition = true;
            foreach (GameObject mob in spawnedMobs)
            {
                if (Vector3.Distance(spawnPosition, mob.transform.position) < minEnemyDistance)
                {
                    validPosition = false;
                    break;
                }
            }

            attempts++;

            if (validPosition)
            {
                return spawnPosition;
            }
        }

        return GetRandomPositionWithinMap();
    }

    Vector3 GetRandomPositionWithinMap()
    {
        float xMin = Mathf.Min(topLeft.transform.position.x, bottomLeft.transform.position.x);
        float xMax = Mathf.Max(topRight.transform.position.x, bottomRight.transform.position.x);
        float yMin = Mathf.Min(bottomLeft.transform.position.y, bottomRight.transform.position.y);
        float yMax = Mathf.Max(topLeft.transform.position.y, topRight.transform.position.y);

        float randomX = Random.Range(xMin, xMax);
        float randomY = Random.Range(yMin, yMax);

        return new Vector3(randomX, randomY, 0);
    }

    private void RemoveMob()
    {
        for (int i = 0; i < spawnedMobs.Count; i++)
        {
            if (spawnedMobs[i] == null)
            {
                spawnedMobs.RemoveAt(i);
                totalMobDead++;
                text.text = "Inamici morti: " + totalMobDead.ToString();
            }
        }
    }
}
