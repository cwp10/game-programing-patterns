using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab_ = null;

    public static GameObjectPool Instance { get; private set; }
    private Queue<GameObject> objects = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public GameObject Get()
    {
        if (objects.Count == 0)
        {
            AddObjects(1);
        }

        return objects.Dequeue();
    }

    private void OnEnable()
    {
        AddObjects(10);
    }

    private void AddObjects(int count)
    {
        var newObject = GameObject.Instantiate(prefab_);
        newObject.SetActive(false);
        objects.Enqueue(newObject);

        newObject.GetComponent<IGameObjectPooled>().Pool = this;
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
}
