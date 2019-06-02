using UnityEngine;

public class FirstSword : MonoBehaviour
{
    public int damage = 1;
    public void Attack(Target target)
    {
        target.TakeDamage(damage);
        Debug.Log("You slice " + target.name);
    }
}