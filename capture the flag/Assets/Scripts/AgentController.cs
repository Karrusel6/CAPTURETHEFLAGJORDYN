using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private AgentState state;
    
    [SerializeField] private Gun gun;
    [SerializeField] private LayerMask targetMask;
    public LayerMask TargetMask => targetMask;
    private void Start()
    {
        state = new AgentStandbyState(this, GetComponent<Rigidbody>(), GetComponent<NavMeshAgent>() );
    }

    private void FixedUpdate()
    {
        state.Update();
        state.UpdateState();
    }

    public void SetState(AgentState state)
    {
        this.state = state;
    }
    
    public void Shoot()
    {
        Vector3 dir = (PlayerController.Instance.transform.position - gun.transform.position).normalized;
        gun.Shoot(gun.transform.position, dir);
    }
}
