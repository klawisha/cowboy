using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroid;
    [SerializeField] int gridSpacing = 90;
    [SerializeField] int numOfAsteroidsPerAxis = 10;

    // Start is called before the first frame update
    void Start()
    {
        PlaceAsteroids();
    }

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
        }

    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        Instantiate(asteroid, 
        new Vector3(transform.position.x + x * gridSpacing + AsteroidOffset(),
                    transform.position.y + y * gridSpacing + AsteroidOffset(), 
                    transform.position.z + z * gridSpacing + AsteroidOffset()), 
         Quaternion.identity, transform);
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
