using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{
	public List<PropRandomizer> TerrainChunks;
	public float CheckerRadius;
	public LayerMask TerrainMask;
	public GameObject CurrentChunk;
	private Vector3 _noTerrainPosition;

	public List<GameObject> SpawnedChunks;
	public float MaxOpDist; // Must be greater than lenght and width of the tilemap
	public float OptimizerCooldownDur;
	private float _opDist;
	private float _optimizerCooldown;
	private PlayerMovement _playerMovement;
	private GameObject _latestChunk;

	private void Start()
	{
		_playerMovement = FindObjectOfType<PlayerMovement>();
	}

	private void Update()
	{
		ChunkCheck();
		ChunkOptimizer();
	}

	private void ChunkCheck()
	{
		if (!CurrentChunk)
		{
			return;
		}

		switch (_playerMovement.MoveDir.x)
		{
			// right
			case > 0 when _playerMovement.MoveDir.y is > -0.5f and < 0.5f:
			{
				if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Right").position, CheckerRadius, TerrainMask))
				{
					_noTerrainPosition = CurrentChunk.transform.Find("Right").position;
					SpawnChunk();
				}

				break;
			}
			// left
			case < 0 when _playerMovement.MoveDir.y is > -0.5f and < 0.5f:
			{
				if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Left").position, CheckerRadius, TerrainMask))
				{
					_noTerrainPosition = CurrentChunk.transform.Find("Left").position;
					SpawnChunk();
				}

				break;
			}
			// up
			case > -0.5f and < 0.5f when _playerMovement.MoveDir.y > 0:
			{
				if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Up").position, CheckerRadius, TerrainMask))
				{
					_noTerrainPosition = CurrentChunk.transform.Find("Up").position;
					SpawnChunk();
				}

				break;
			}
			// down
			case > -0.5f and < 0.5f when _playerMovement.MoveDir.y < 0:
			{
				if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Down").position, CheckerRadius, TerrainMask))
				{
					_noTerrainPosition = CurrentChunk.transform.Find("Down").position;
					SpawnChunk();
				}

				break;
			}
			// right up
			case > 0 when _playerMovement.MoveDir.y > 0:
			{
				if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Right Up").position, CheckerRadius,
					    TerrainMask))
				{
					_noTerrainPosition = CurrentChunk.transform.Find("Right Up").position;
					SpawnChunk();
				}

				break;
			}
			// right down
			case > 0 when _playerMovement.MoveDir.y < 0:
			{
				if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Right Down").position, CheckerRadius,
					    TerrainMask))
				{
					_noTerrainPosition = CurrentChunk.transform.Find("Right Down").position;
					SpawnChunk();
				}

				break;
			}
			// left up
			case < 0 when _playerMovement.MoveDir.y > 0:
			{
				if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Left Up").position, CheckerRadius,
					    TerrainMask))
				{
					_noTerrainPosition = CurrentChunk.transform.Find("Left Up").position;
					SpawnChunk();
				}

				break;
			}
			// left down
			case < 0 when _playerMovement.MoveDir.y < 0:
			{
				if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Left Down").position, CheckerRadius,
					    TerrainMask))
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
		_latestChunk = Instantiate(TerrainChunks[random].gameObject, _noTerrainPosition, Quaternion.identity);
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
			_opDist = Vector3.Distance(_playerMovement.transform.position, chunk.transform.position);
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