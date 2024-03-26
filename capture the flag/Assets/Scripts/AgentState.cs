using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public abstract class AgentState
{
    protected Rigidbody rb;
    protected AgentController controller;
    protected PlayerController playerController;
    protected NavMeshAgent nm;
    protected Vector3 basePos = new Vector3(2, 1, 0);
    public AgentState(AgentController controller, Rigidbody rb, NavMeshAgent nm)
    {
        this.controller = controller;
        this.rb = rb;
        playerController = PlayerController.Instance;
        this.nm = nm;
    }

    public abstract void Update();
    public abstract void UpdateState();

    protected Vector3 GetDirectionToPlayer()
    {
        Vector3 direction = playerController.transform.position - controller.transform.position;
        return direction.normalized;
    }

    protected bool IsPlayerVisible()
    {
        if (Physics.Raycast(controller.transform.position, GetDirectionToPlayer(), out var hitInfo, 100, controller.TargetMask))
        {
            return hitInfo.collider.CompareTag("Player");
        }

        return false;
    }
}