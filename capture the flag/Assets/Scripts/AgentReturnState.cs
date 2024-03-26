using UnityEngine;
using UnityEngine.AI;

public class AgentReturnState : AgentState
{
    public AgentReturnState(AgentController controller, Rigidbody rb, NavMeshAgent nm) : base(controller, rb, nm)
    {
        nm.SetDestination(basePos);
    }

    public override void Update()
    {
        
    }

    public override void UpdateState()
    {
        if (IsPlayerVisible())
        {
            controller.SetState(new AgentShootState(controller, rb, nm));
        }
    }
}

