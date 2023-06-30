using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> propSpawnPoints;
    [SerializeField] private List<GameObject> propPrefabs;

    private void Start()
    {
        SpawnProps();
    }

    private void SpawnProps()
    {
        foreach (var propSpawnPoint in propSpawnPoints)
        {
            var random = Random.Range(0, propPrefabs.Count);
            var prop = Instantiate(propPrefabs[random], propSpawnPoint.transform.position, quaternion.identity);
            prop.transform.parent = propSpawnPoint.transform;
        }
    }
}
