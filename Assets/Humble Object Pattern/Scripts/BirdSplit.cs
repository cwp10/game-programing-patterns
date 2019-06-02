using UnityEngine;

public class BirdSplit : MonoBehaviour, IBird
{
    private BirdController _birdController = null;
    [SerializeField]
    private int maxHeight_ = 3;
    public float MaxHeight { get { return maxHeight_; } }

    [SerializeField]
    private int minHeight_ = -3;
    public float MinHeight { get { return minHeight_; } }

    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }

    private void Awake()
    {
        _birdController = new BirdController(this);
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        _birdController.Move(vertical);
    }
}