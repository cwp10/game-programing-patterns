using UnityEngine;

public class BlasterShotGenericPooled : MonoBehaviour
{
    public float moveSpeed = 30.0f;

    private float _lifeTime = 0;
    private float _maxLifetime = 5f;

    private void OnEnable()
    {
        _lifeTime = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        _lifeTime += Time.deltaTime;

        if (_lifeTime > _maxLifetime)
        {
            ShotPool.Instance.ReturnToPool(this);
        }
    }
}
