using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] float knockbackForce;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPhysics player = other.GetComponent<PlayerPhysics>();
        if (player != null)
        {
            Vector2 direction = (transform.position - other.transform.position).normalized;
            player.Hurt(direction * knockbackForce);
        }
    }
}
