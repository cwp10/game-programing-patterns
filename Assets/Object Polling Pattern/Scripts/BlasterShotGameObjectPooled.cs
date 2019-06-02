using UnityEngine;

public class BlasterShotGameObjectPooled : MonoBehaviour, IGameObjectPooled
{
    public float moveSpeed = 30.0f;

    private float _lifeTime = 0;
    private float _maxLifetime = 5f;

    private GameObjectPool pool = null;
    public GameObjectPool Pool
    {
        get { return pool; }
        set
        {
            if (pool == null)
            {
                pool = value;
            }
            else
            {
                throw new System.Exception("Bad pool use, this should olny get set once!");
            }
        }
    }

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
            pool.ReturnToPool(this.gameObject);
        }
    }
}
