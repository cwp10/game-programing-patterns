using UnityEngine;

public class BlasterWithGenerics : MonoBehaviour
{
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
        var shot = ShotPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
}
