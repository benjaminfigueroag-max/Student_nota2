using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = MyMoveTowards(position.x, target.position.x, speed * Time.deltaTime);
        transform.position = position;
    }

    float MyMoveTowards(float current, float target, float maxDelta)
    {

        float difference = target - current;


        if (Mathf.Abs(difference) <= maxDelta)
        {
            return target;
        }
        
        return current + Mathf.Sign(difference) * maxDelta;


    }
}
