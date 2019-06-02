using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private int maxHeight_ = 3;

    [SerializeField]
    private int minHeight_ = -3;

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        Move(vertical);
    }

    private void Move(float vertical)
    {
        transform.position += Vector3.up * vertical;

        if (transform.position.y > maxHeight_)
        {
            transform.position = new Vector3(transform.position.x, maxHeight_, transform.position.z);
        }

        if (transform.position.y < minHeight_)
        {
            transform.position = new Vector3(transform.position.x, minHeight_, transform.position.z);
        }
    }
}
