using System;
using UnityEngine;
class DeerRunAwayState : IDeerState
{

	private DeerController deer;
    private GameObject runAwayPoint = null;

	public DeerRunAwayState (DeerController deer)
	{
		this.deer = deer;
        chooseRunAwayPoint();
        deer.NavMeshAgent.SetDestination(runAwayPoint.transform.position);
        deer.NavMeshAgent.speed = deer.RunAwaySpeed;
	}
	

    private void chooseRunAwayPoint()
    {
        float biggestDistance = 0f;
        var reference = runAwayPoint;
        foreach (var rap in deer.RunAwayPoints)
        {
            float dist = Vector3.Distance(deer.transform.position, rap.transform.position);

            if (dist > biggestDistance)
            {
                biggestDistance = dist;
                reference = rap;
            }
        }

        runAwayPoint = reference;
    }



	#region IDeerState implementation
	public void updateState ()
	{
        float dist = Vector3.Distance(deer.transform.position, runAwayPoint.transform.position);
        Debug.Log("DIST" + dist);
        if (dist <= 1.5f)
        {
            toIdleState();
        }
	}
	public void toRunAway ()
	{
		
	}
	public void toIdleState ()
	{
        deer.CurrentState = new DeerIdleState(deer);
	}
	#endregion
}


