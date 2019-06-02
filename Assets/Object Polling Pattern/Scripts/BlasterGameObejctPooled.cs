using UnityEngine;

public class BlasterGameObejctPooled : MonoBehaviour
{
    [SerializeField]
    private float refireRate_ = 2f;
    [SerializeField]
    private GameObjectPool gameObjectPool_ = null;

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
        var shot = gameObjectPool_.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
}
