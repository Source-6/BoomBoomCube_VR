using System.Runtime.CompilerServices;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Rigidbody cube;


    float timer;
    [SerializeField] float timeTillNextLevel = 30;


    [SerializeField] short startingSpawnTime = 5;
    [SerializeField] private float spawnTime; // Will increase over time
    [SerializeField] float spawnTimeReduction = 0.2f;
    [SerializeField] float repeat;

    [SerializeField] float velocityIncrease = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = startingSpawnTime;
        Invoke("Spawn", spawnTime); 
    }


    // Update is called once per frame
    void Update()
    {
        // Timer that increases velocity & spawntime (?)
        timer += Time.deltaTime;

        if (timer >= timeTillNextLevel)
        {
            timeTillNextLevel += timer; // Will (normally) always be greater than the timer by 30 seconds.
            spawnTime -= spawnTimeReduction; // Spawns cubes more frequently
            velocityIncrease += 0.2f;
        }
    }

    void Spawn()
    {
        // Every time Spawn() is called, it determines the delay for the next call of Spawn()
        float rdn = Random.value;
        repeat = spawnTime + rdn; // Small time variations between cubes spawning 

        Rigidbody cubeClone = Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
        cubeClone.linearVelocity *= velocityIncrease; // Increase cubes starting velocity 

        Invoke("Spawn", repeat); // Calls again the function
    }
    
}
