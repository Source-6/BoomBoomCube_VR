using Unity.VisualScripting;
using UnityEngine;

public class CubeVelocity : MonoBehaviour
{

    public Vector3 velocity;
    public Transform position;
    public Rigidbody cube;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cube = GetComponent<Rigidbody>();
        cube.linearVelocity = velocity;
        
    }
}
