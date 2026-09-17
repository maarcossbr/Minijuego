using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public GameObject bulletPrefab;
    public GameObject asteroidPrefab;

    public int cantidadBalas = 20;
    public int cantidadAsteroides = 20;

    private Queue<GameObject> balas =
        new Queue<GameObject>();

    private Queue<GameObject> asteroides =
        new Queue<GameObject>();

    void Awake()
    {
        Instance = this;

        // Creamos las balas iniciales
        for (int i = 0; i < cantidadBalas; i++)
        {
            GameObject bala = Instantiate(bulletPrefab);
            bala.SetActive(false);
            balas.Enqueue(bala);
        }

        // Creamos los meteoritos iniciales
        for (int i = 0; i < cantidadAsteroides; i++)
        {
            GameObject meteor = Instantiate(asteroidPrefab);
            meteor.SetActive(false);
            asteroides.Enqueue(meteor);
        }
    }


    public GameObject GetBullet()
    {
        GameObject bala;

        if (balas.Count > 0)
        {
            bala = balas.Dequeue();
        }
        else
        {
            // Si nos quedamos sin balas, creamos otra
            bala = Instantiate(bulletPrefab);
        }

        bala.SetActive(true);

        return bala;
    }

    public void ReturnBullet(GameObject bala)
    {
        bala.SetActive(false);
        balas.Enqueue(bala);
    }


    public GameObject GetAsteroid()
    {
        GameObject meteor;

        if (asteroides.Count > 0)
        {
            meteor = asteroides.Dequeue();
        }
        else
        {
            meteor = Instantiate(asteroidPrefab);
        }

        meteor.SetActive(true);

        return meteor;
    }

    public void ReturnAsteroid(GameObject meteor)
    {
        meteor.SetActive(false);
        asteroides.Enqueue(meteor);
    }
}