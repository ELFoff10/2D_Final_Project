using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropRateManager : MonoBehaviour
{
    public bool IsBoss = false;
    
    [Serializable]
    public class Drops
    {
        public string Name;
        public GameObject ItemPrefab;
        public float DropRate;
    }

    public List<Drops> ListDrops;

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            return;
        }

        if (IsBoss)
        {
            GameManager.Instance.CurrentState = GameManager.GameState.GameOver;
            return;
        }
        
        var randomNumber = Random.Range(0f, 100f);
        var possibleDrops = ListDrops.Where(rate => randomNumber <= rate.DropRate).ToList();
        
        if (possibleDrops.Count <= 0) return;
        var drops = possibleDrops[Random.Range(0, possibleDrops.Count)];
        Instantiate(drops.ItemPrefab, transform.position, Quaternion.identity);
    }
}