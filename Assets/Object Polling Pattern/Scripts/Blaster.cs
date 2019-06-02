using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField]
    private BlasterShotNoPool blasterShotPrefab_ = null;

    [SerializeField]
    private float refireRate_ = 2f;

    private float _fireTimer = 0;

    private void Update()
    {
        _fireTimer += Time.deltaTime;

        if (_fireTimer >= refireRate_)
        {
            _fireTimer = 0;
            Fire();
        }
    }

    private void Fire()
    {
        var shot = Instantiate(blasterShotPrefab_, transform.position, transform.rotation);
    }
}
