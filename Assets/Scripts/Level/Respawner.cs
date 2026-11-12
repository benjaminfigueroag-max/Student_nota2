using System.Collections;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] Gem gemPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float respawnDelay;

    WaitForSeconds respawnWait;
    
    void Awake()
    {
        
        respawnWait = new WaitForSeconds(respawnDelay);
    }

    void OnEnable()
    {
       
        GameEvents.OnTargetDestroyed += HandleTargetDestroyed;
    }

    void OnDisable()
    {
       
        GameEvents.OnTargetDestroyed -= HandleTargetDestroyed;
    }

    void HandleTargetDestroyed(GameItem item)
    {
       
        if (item == GameItem.Gem)
        {
            StartCoroutine(RespawnGemRoutine());
        }
    }

    IEnumerator RespawnGemRoutine()
    {
      
        yield return respawnWait;

      
        Instantiate(gemPrefab, spawnPoint.position, Quaternion.identity);
    }
}