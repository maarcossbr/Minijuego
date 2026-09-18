using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float maxLifeTime = 4f;

    public float xLimit = 10f;
    public float yLimit = 7f;

    public float minTam = 0.5f;
    public float maxTam = 1.3f;

    public float velocidadMeteor = 4f;

    private float spawnNext = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            SpawnAsteroid();


        }


    }

    void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPosition = Vector3.zero;

        // 0 arriba
        // 1 abajo
        // 2 izquierda
        // 3 derecha
        switch (side)
        {
            case 0:
                {
                    float rand = Random.Range(-xLimit, xLimit);
                    spawnPosition = new Vector2(rand, 8f);
                    break;
                }
            case 1:
                {
                    float rand = Random.Range(-xLimit, xLimit);
                    spawnPosition = new Vector2(rand, -8f);
                    break;
                }
            case 2:
                {
                    float rand = Random.Range(-yLimit, yLimit);
                    spawnPosition = new Vector2(-11f, rand);
                    break;
                }
            case 3:
                {
                    float rand = Random.Range(-yLimit, yLimit);
                    spawnPosition = new Vector2(11f, rand);
                    break;
                }

        }
        GameObject meteor = PoolManager.Instance.GetAsteroid();

        Asteroid asteroid = meteor.GetComponent<Asteroid>();
        asteroid.esFragmento = false;

        meteor.transform.position = spawnPosition;
        meteor.transform.rotation = Quaternion.identity;

        float tamRandom = Random.Range(minTam, maxTam);
        meteor.transform.localScale = asteroidPrefab.transform.localScale * tamRandom;

        Vector3 target = new Vector3(0f, 0f, 0f);

        Vector3 direction = (target - meteor.transform.position).normalized;

        Rigidbody rb = meteor.GetComponent<Rigidbody>();

        rb.mass = tamRandom * 2f;
        rb.linearVelocity = direction * velocidadMeteor;
    }
}