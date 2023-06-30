using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    
    public List<GameObject> TerrainChunks;
    public GameObject Player;
    public float CheckerRadius;
    public LayerMask TerrainMask;
    public GameObject CurrentChunk;
    private Vector3 _noTerrainPosition;

    public List<GameObject> SpawnedChunks;
    private GameObject _latestChunk;
    public float MaxOpDist; // Must be greater than lenght and width of the tilemap
    private float _opDist;
    private float _optimizerCooldown;
    public float OptimizerCooldownDur;
    
    private void Update()
    {
        ChunkCheker();
        ChunkOptimizer();
    }

    private void ChunkCheker()
    {
        if (!CurrentChunk)
        {
            return;
        }
        
        switch (_playerMovement.moveDir.x)
        {
            // right
            case > 0 when _playerMovement.moveDir.y == 0:
            {
                if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Right").position, CheckerRadius, TerrainMask))
                {
                    _noTerrainPosition = CurrentChunk.transform.Find("Right").position;
                    SpawnChunk();
                }

                break;
            }
            // left
            case < 0 when _playerMovement.moveDir.y == 0:
            {
                if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Left").position, CheckerRadius, TerrainMask))
                {
                    _noTerrainPosition = CurrentChunk.transform.Find("Left").position;
                    SpawnChunk();
                }

                break;
            }
            // up
            case 0 when _playerMovement.moveDir.y > 0:
            {
                if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Up").position, CheckerRadius, TerrainMask))
                {
                    _noTerrainPosition = CurrentChunk.transform.Find("Up").position;
                    SpawnChunk();
                }

                break;
            }
            // down
            case 0 when _playerMovement.moveDir.y < 0:
            {
                if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Down").position, CheckerRadius, TerrainMask))
                {
                    _noTerrainPosition = CurrentChunk.transform.Find("Down").position;
                    SpawnChunk();
                }

                break;
            }
            // right up
            case > 0 when _playerMovement.moveDir.y > 0:
            {
                if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Right Up").position, CheckerRadius, TerrainMask))
                {
                    _noTerrainPosition = CurrentChunk.transform.Find("Right Up").position;
                    SpawnChunk();
                }

                break;
            }
            // right down
            case > 0 when _playerMovement.moveDir.y < 0:
            {
                if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Right Down").position, CheckerRadius, TerrainMask))
                {
                    _noTerrainPosition = CurrentChunk.transform.Find("Right Down").position;
                    SpawnChunk();
                }

                break;
            }
            // left up
            case < 0 when _playerMovement.moveDir.y > 0:
            {
                if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Left Up").position, CheckerRadius, TerrainMask))
                {
                    _noTerrainPosition = CurrentChunk.transform.Find("Left Up").position;
                    SpawnChunk();
                }

                break;
            }
            // left down
            case < 0 when _playerMovement.moveDir.y < 0:
            {
                if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Left Down").position, CheckerRadius, TerrainMask))
                {
                    _noTerrainPosition = CurrentChunk.transform.Find("Left Down").position;
                    SpawnChunk();
                }

                break;
            }
        }
    }

    private void SpawnChunk()
    {
        var random = Random.Range(0, TerrainChunks.Count);
        _latestChunk = Instantiate(TerrainChunks[random], _noTerrainPosition, Quaternion.identity);
        SpawnedChunks.Add(_latestChunk);
    }

    private void ChunkOptimizer()
    {
        _optimizerCooldown -= Time.deltaTime;

        if (_optimizerCooldown <= 0f)
        {
            _optimizerCooldown = OptimizerCooldownDur;
        }
        else
        {
            return;
        }

        foreach (var chunk in SpawnedChunks)
        {
            _opDist = Vector3.Distance(Player.transform.position, chunk.transform.position);

            if (_opDist > MaxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
