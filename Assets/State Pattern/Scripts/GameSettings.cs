using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private float droneSpeed_ = 2f;
    public static float DroneSpeed => Instance.droneSpeed_;

    [SerializeField] private float aggroRadius_ = 4f;
    public static float AggroRadius => Instance.aggroRadius_;

    [SerializeField] private float attackRange_ = 3f;
    public static float AttackRange => Instance.attackRange_;

    [SerializeField] private GameObject dronePRojectilePrefab_ = null;
    public static GameObject DroneProjectilePrefab => Instance.dronePRojectilePrefab_;

    public static GameSettings Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
