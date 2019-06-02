public class BigSword : Weapon
{
    protected override void DoAttack(Target target)
    {
        target.TakeDamage(10);
    }

    protected override string DamageMessage()
    {
        return "devastate";
    }
}
