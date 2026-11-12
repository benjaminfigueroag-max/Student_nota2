using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IDamagable
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] List<Color> colors;

    int indexColor = 0;

    public void Damage(int direction)
    {
        if (indexColor >= colors.Count)
        {
            GameEvents.TargetDestroyed(GameItem.Gem);
            Destroy(gameObject);
            return;
        }

        spriteRenderer.color = colors[indexColor];
        indexColor++;
    }
}