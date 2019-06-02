using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public void Attack(Target target)
    {
        DoAttack(target);
        Debug.Log("You " + DamageMessage() + " " + target.name);
    }

    protected abstract void DoAttack(Target target);
    protected virtual string DamageMessage() { return "hit"; }
}
