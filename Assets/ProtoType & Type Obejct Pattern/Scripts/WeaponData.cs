using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    public int Damage = 0;
    public string Message = string.Empty;
    public GameObject Model = null;
    public int StunDuration = 0;
    public int FreezeDuration = 0;
}
