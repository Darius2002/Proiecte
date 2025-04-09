using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Prefab;
    public Camera mainCamera;
    private float spawnDistance = 1f;
    private float speed = 10f;
    private float spawnRate = 0.5f;  
    private bool isSpawning = false;  
    private Coroutine spawnCoroutine;  

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isSpawning)
        {
            isSpawning = true;  
            spawnCoroutine = StartCoroutine(SpawnCirclesContinuously());
        }

        if (Input.GetMouseButtonUp(0) && isSpawning)
        {
            isSpawning = false; 
            StopCoroutine(spawnCoroutine);  
        }
    }

    private IEnumerator SpawnCirclesContinuously()
    {
        while (isSpawning)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (mousePosition - transform.position).normalized;

            Vector3 spawnPosition = (Vector2)transform.position + direction * spawnDistance;

            GameObject newCircle = Instantiate(Prefab, spawnPosition, Quaternion.identity);

            StartCoroutine(MoveCircle(newCircle, direction));

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private IEnumerator MoveCircle(GameObject circle, Vector2 direction)
    {
        while (circle != null)
        {
            float step = speed * Time.deltaTime;  
            circle.transform.position = (Vector2)circle.transform.position + direction * step;

            yield return null;
        }
    }

    public void SetSpeed(float nr)
    {
        speed = nr;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpawnRate(float nr)
    {
        spawnRate = nr;
    }

    public float GetSpawnRate()
    {
        return spawnRate;
    }

}
