using UnityEngine;

public class CubeDestructor : MonoBehaviour
{
    [SerializeField] Collider handsCollider;
    [SerializeField] Collider invisibleWallCollider;

    [SerializeField] AudioSource crushingCubesAudio;
    [SerializeField] AudioSource missedCubeAudio;


    void OnTriggerEnter(Collider other)
    {
        if (other == handsCollider)
        {
            crushingCubesAudio.Play();
            // Controller vibration
            // Call object "anim" (method) that reduces its size
            Destroy(gameObject, 1);
        }

        if (other == invisibleWallCollider)
        {
            missedCubeAudio.Play();
            Destroy(gameObject);
        }
    }
}
