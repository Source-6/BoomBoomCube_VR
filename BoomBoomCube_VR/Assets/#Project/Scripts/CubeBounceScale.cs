using UnityEngine;

public class CubeBounceScale : MonoBehaviour
{

    public Transform from;
    public Transform to;
    public Transform temp;
    public float speedBounce = 0.5f;
    public float timeCount = 0.0f;


    // Update is called once per frame
    void Update()
    {
        Bounce();
    }

    void Bounce()
    {
        transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount * speedBounce);
        timeCount = timeCount + Time.deltaTime;

        if (timeCount * speedBounce > 1)
        {
            timeCount = 0;
            temp = from;
            from = to;
            to = temp;
        }

    }


}
