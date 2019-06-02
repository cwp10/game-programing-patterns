using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab_ = null;

    public static GenericObjectPool<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    public T Get()
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
        newObject.gameObject.SetActive(false);
        objects.Enqueue(newObject);
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
}
