using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AI;

public class AgentStandbyState : AgentState
{
    private PlayerController playerController;
    
    public AgentStandbyState(AgentController controller, Rigidbody rb, NavMeshAgent nm) : base(controller, rb, nm)
    {
        playerController = PlayerController.Instance;
    }

    public override void Update()
    {
        // do nuthin
    }

    public override void UpdateState()
    {
        if (IsPlayerVisible())
        {
            controller.SetState(new AgentShootState(controller, rb, nm));
        }
    }
}
