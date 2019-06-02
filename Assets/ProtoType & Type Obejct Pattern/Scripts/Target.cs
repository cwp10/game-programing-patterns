using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int currentHealth_ = 100;

    public void TakeDamage(int amount)
    {
        currentHealth_ -= amount;
        Debug.Log("currentHealth " + currentHealth_);
    }

    internal void Freeze(int seconds)
    {
        Debug.Log("Frozen for " + seconds);
    }

    internal void Stun(int seconds)
    {
        Debug.Log("Stunned for " + seconds);
    }
}
