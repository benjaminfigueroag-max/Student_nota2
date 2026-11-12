using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] float knockbackForce = 8f;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPhysics player = other.GetComponent<PlayerPhysics>();
        if (player != null)
        {
            float pushDirectionX = other.transform.position.x - transform.position.x;

            if (Mathf.Approximately(pushDirectionX, 0f))
            {
                pushDirectionX = -player.Direction;
            }
            else
            {
                pushDirectionX = Mathf.Sign(pushDirectionX);
            }

            player.Hurt(new Vector2(pushDirectionX * knockbackForce, 0f));
        }
    }
}
