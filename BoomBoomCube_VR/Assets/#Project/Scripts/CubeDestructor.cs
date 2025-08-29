using UnityEngine;

public class CubeDestructor : MonoBehaviour
{
    public AudioSource crushingCubesAudio;
    public AudioSource missedCubeAudio;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hands")
        {
            crushingCubesAudio.Play();
            // Controller vibration
            // Call object "anim" (method) that reduces its size
            Destroy(gameObject, 1);
        }

        if (other.gameObject.tag == "DestroyZone")
        {
            missedCubeAudio.Play();
            Destroy(gameObject);
        }
    }
}
