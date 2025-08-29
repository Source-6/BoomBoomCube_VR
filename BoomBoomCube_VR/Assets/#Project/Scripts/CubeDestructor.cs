using UnityEngine;

public class CubeDestructor : MonoBehaviour
{
    [SerializeField] Collider leftHandCollider;
    [SerializeField] Collider rightHandCollider;
    [SerializeField] Collider invisibleWallCollider;

    [SerializeField] AudioSource crushingCubesAudio;
    [SerializeField] AudioSource missedCubeAudio;


    void OnTriggerEnter(Collider other)
    {
        if (other == leftHandCollider || other == rightHandCollider)
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
