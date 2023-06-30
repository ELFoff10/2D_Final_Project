using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ChunkTrigger : MonoBehaviour
{
    
    public GameObject _targetMap;
    private MapController _mapController;

    private void Start()
    {
        _mapController = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _mapController.CurrentChunk = _targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_mapController.CurrentChunk == _targetMap)
            {
                _mapController.CurrentChunk = null;
            }
        }
    }
}
