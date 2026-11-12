using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] Collider2D enemyCollider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float flashWait;
    [SerializeField] int flashTimes;

    Coroutine flashCoroutine;
    WaitForSeconds flashWaitTimer;
    WaitForSeconds FlashWaitTimer
    {
        get
        {
            if (flashWaitTimer == null)
            {
                flashWaitTimer = new WaitForSeconds(flashWait);
            }

            return flashWaitTimer;
        }
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void Damage(int direction)
    {
        // Si ya estaba parpadeando, detenemos la coroutine anterior para reiniciar el efecto
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        // Es obligatorio usar StartCoroutine para ejecutar un IEnumerator
        flashCoroutine = StartCoroutine(FlashDamage());
    }

    IEnumerator FlashDamage()
    {
        enemyCollider.enabled = false;

        for (int i = 0; i < flashTimes; i++)
        {
            spriteRenderer.color = Color.black;
            yield return FlashWaitTimer;
            spriteRenderer.color = Color.white;
            yield return FlashWaitTimer;
        }

        enemyCollider.enabled = true;
    }
}