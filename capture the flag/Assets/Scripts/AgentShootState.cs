using UnityEngine;
using UnityEngine.AI;

class AgentShootState : AgentState
{
    private float fireRate = 0.1f;
    private int numBullets = 6;
    private float fireCountdown = 0;
    
    public AgentShootState(AgentController controller, Rigidbody rb, NavMeshAgent nm) : base(controller, rb, nm)
    {
        fireCountdown = fireRate;
    }

    public override void Update()
    {
        if (numBullets == 0) return;

        if (fireCountdown <= 0)
        {
            controller.Shoot();
            fireCountdown = fireRate;
            numBullets--;
        }

        nm.SetDestination(playerController.transform.position);
        
        fireCountdown -= Time.deltaTime;
    }

    public override void UpdateState()
    {
        if (!IsPlayerVisible())
        {
            controller.SetState(new AgentStandbyState(controller, rb, nm));
        }
        if (numBullets <= 0)
        {
            controller.SetState(new AgentReloadState(controller, rb, nm));
        }
    }
}
