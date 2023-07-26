using UnityEngine;

public class Pickup : MonoBehaviour, ICollectible
{
	protected bool HasBeenCollected = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}

	public virtual void Collect()
	{
		HasBeenCollected = true;
	}
}