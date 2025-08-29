using System.Runtime.CompilerServices;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public Transform spawnPoint;
    public Rigidbody cube;

    float timer;
    public float timeTillNextLevel = 30;

    public short startingSpawnTime = 5;
    [SerializeField] private float spawnTime; // Will increase over time
    public float spawnTimeReduction = 0.2f;
    public float repeat;

    public Vector3 startingVelocity = Vector3.forward; // Cube is moving forward
    [SerializeField] private Vector3 cubeVelocity; // Will increase over time. (?)

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
            timeTillNextLevel += timer; // Will (normally) always be greater than the timer by 30seconds.
            spawnTime -= spawnTimeReduction; // Spawns cubes more frequently
            cubeVelocity.z *= 1.2f; // Cubes go faster
        }
    }

    void Spawn()
    {
        // Every time Spawn() is called, it determines the delay for the next call of Spawn()
        float rdn = Random.value;
        repeat = spawnTime + rdn; // Small time variations between cubes spawning 

        Rigidbody cubeClone = Instantiate(cube, spawnPoint.position, spawnPoint.rotation);

        Invoke("Spawn", repeat);
    }
    
}
