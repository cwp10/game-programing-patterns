using UnityEngine;

public class WeaponTester : MonoBehaviour
{
    [SerializeField]
    private WeaponV2 currentWeapon_ = null;

    [SerializeField]
    private Target target_ = null;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            currentWeapon_.Attack(target_);
        }
    }
}
