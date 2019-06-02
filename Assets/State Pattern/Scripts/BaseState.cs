using System;
using UnityEngine;

public abstract class BaseState
{
    protected GameObject _gameObject = null;
    protected Transform _transform = null;

    public BaseState(GameObject gameObject)
    {
        this._gameObject = gameObject;
        this._transform = gameObject.transform;
    }

    public abstract Type Tick();
}
