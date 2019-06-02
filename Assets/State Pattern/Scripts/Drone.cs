using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private Team team_;
    [SerializeField] private LayerMask layerMask_;
    [SerializeField] private GameObject laserVisual_;

    public LayerMask LayerMask => layerMask_;
    public Transform Target { get; private set; }
    public Team Team => team_;
    public StateMachine StateMachine => GetComponent<StateMachine>();

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(WanderState), new WanderState(this) },
            { typeof(ChaseState), new ChaseState(this) },
            { typeof(AttackState), new AttackState(this) }
        };

        GetComponent<StateMachine>().SetStates(states);
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public void FireWeapon()
    {
        laserVisual_.transform.position = (Target.position + transform.position) / 2f;

        float distance = Vector3.Distance(Target.position, transform.position);
        laserVisual_.transform.localScale = new Vector3(0.1f, 0.1f, distance);
        laserVisual_.SetActive(true);

        StartCoroutine(TurnOffLaser());
    }

    private IEnumerator TurnOffLaser()
    {
        yield return new WaitForSeconds(0.25f);
        laserVisual_.SetActive(false);

        if (Target != null)
        {
            Destroy(Target.gameObject);
        }
    }
}

public enum Team
{
    Red,
    Blue,
}

public enum DroneState
{
    Wander,
    Chase,
    Attack
}
