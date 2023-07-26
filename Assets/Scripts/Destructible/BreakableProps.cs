using UnityEngine;

public class BreakableProps : MonoBehaviour
{
    public float Health;

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
