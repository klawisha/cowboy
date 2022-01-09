using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroid;
    [SerializeField] int gridSpacing = 90;
    [SerializeField] int numOfAsteroidsPerAxis = 10;

    [SerializeField]GameObject pickupPref;

   public List<Asteroid> asteroids = new List<Asteroid>();


    void OnEnable()
    {
        EventManager.onStartGame += PlaceAsteroids;
        EventManager.onPlayerDeath += DestroyAsteroids;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= PlaceAsteroids;
        EventManager.onPlayerDeath -= DestroyAsteroids;
    }

   // void Start()
    //{
     //   PlaceAsteroids();
    //}

    void PlaceAsteroids()
    {
        for(int i = 0; i < numOfAsteroidsPerAxis; i++)
        {
            for(int j = 0; j < numOfAsteroidsPerAxis; j++)
            {
                for(int v = 0; v < numOfAsteroidsPerAxis; v++)
                {
                    InstantiateAsteroid(i, j, v);
                }
            }
        PlacePickUps();
        }

    }

    void PlacePickUps()
    {
        int rnd = Random.Range(0, asteroids.Count);


        Instantiate(pickupPref,asteroids[rnd].transform.position, Quaternion.identity);
        Destroy(asteroids[rnd].gameObject);
        asteroids.RemoveAt(rnd);
    }


    void InstantiateAsteroid(int x, int y, int z)
    {
        Asteroid ast = Instantiate(asteroid,
        new Vector3(transform.position.x + x * gridSpacing + AsteroidOffset(),
                    transform.position.y + y * gridSpacing + AsteroidOffset(),
                    transform.position.z + z * gridSpacing + AsteroidOffset()),
         Quaternion.identity, transform) as Asteroid;
        asteroids.Add(ast);
    }

    void DestroyAsteroids()
    {
      // foreach(Asteroid a in asteroids)
       //    a.SelfDestruct();

        asteroids.Clear();
    }


    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing/2f, gridSpacing/2f);
    }


    // Update is called once per frame
    void Update()
    {
    }
}
