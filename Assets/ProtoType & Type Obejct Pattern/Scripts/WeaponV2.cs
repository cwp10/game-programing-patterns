using UnityEngine;

public class WeaponV2 : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData_ = null;

    [SerializeField]
    private Transform weaponModelTranformParent_ = null;

    private GameObject _model = null;

    private void OnEnable()
    {
        if (_model != null)
        {
            Destroy(_model);
        }

        if (weaponData_.Model != null)
        {
            _model = Instantiate(weaponData_.Model);
            _model.transform.SetParent(weaponModelTranformParent_, false);
        }
    }

    public void Attack(Target target)
    {
        if (weaponData_.Damage > 0)
        {
            target.TakeDamage(weaponData_.Damage);
        }

        if (weaponData_.StunDuration > 0)
        {
            target.Stun(weaponData_.StunDuration);
        }

        if (weaponData_.FreezeDuration > 0)
        {
            target.Freeze(weaponData_.FreezeDuration);
        }
    }
}
