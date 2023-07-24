using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _propSpawnPoints;
    [SerializeField] private List<GameObject> _propPrefabs;

    private void Start()
    {
        SpawnProps();
    }

    private void SpawnProps()
    {
        foreach (var propSpawnPoint in _propSpawnPoints)
        {
            var random = Random.Range(0, _propPrefabs.Count);
            var prop = Instantiate(_propPrefabs[random], propSpawnPoint.transform.position, quaternion.identity);
            prop.transform.parent = propSpawnPoint.transform;
        }
    }
}
