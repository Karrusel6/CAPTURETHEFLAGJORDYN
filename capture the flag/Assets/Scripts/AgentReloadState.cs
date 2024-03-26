using UnityEngine;
using UnityEngine.AI;

public class AgentReloadState : AgentState
{
    private float reloadTime = 2f;
    private float timer = 0;
    
    public AgentReloadState(AgentController controller, Rigidbody rb, NavMeshAgent nm) : base(controller, rb, nm)
    {
    }

    public override void Update()
    {
        timer += Time.deltaTime;
    }

    public override void UpdateState()
    {
        if (!IsPlayerVisible())
        {
            controller.SetState(new AgentStandbyState(controller, rb, nm));
        }
        else if (timer > reloadTime)
        {
            controller.SetState(new AgentShootState(controller, rb, nm));
        }
    }
}
