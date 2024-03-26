using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentSearchState : AgentState
{
    private float timer;
    public AgentSearchState(AgentController controller, Rigidbody rb, NavMeshAgent nm) : base(controller, rb, nm)
    {
    }

    public override void Update()
    {
        
    }

    public override void UpdateState()
    {
        timer += Time.deltaTime;
        if (IsPlayerVisible())
        {
            controller.SetState(new AgentShootState(controller, rb, nm));
        }
        else if (timer >= 5)
        {
            controller.SetState(new AgentReturnState(controller, rb, nm));
        }
    }
}
