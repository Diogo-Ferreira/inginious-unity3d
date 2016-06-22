using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters.ThirdPerson;
public class DeerIdleState : IDeerState
{
	private DeerController deer;
	private float fearLevel = 2.0f;
    private float fearLevelToRun = 100.0f;
	private float fearRadius = 2.0f;
    private float fearCoolDown = 1.0f;
    private float currentFearCoolDownValue = .0f;
	private float wanderRadius = 12.0f;
	private float currentWanderTime = 0.0f;
	private float changeDirectionTime = 9.0f;
    private GameObject head;
    private Material deerMaterial = null;
    public DeerIdleState (DeerController deer)
	{
		this.deer = deer;
        deer.NavMeshAgent.speed = deer.NormalSpeed;
        head = GameObject.FindGameObjectWithTag("DeerHead");
        Renderer renderer = GameObject.FindGameObjectWithTag("DeerFullBody").GetComponent<Renderer>();
        deerMaterial = renderer.material;
	}

    private void showFearLevelWithMaterial()
    {
        if (deerMaterial != null)
        {
            var colorLevel = (fearLevelToRun - fearLevel)/100.0f;
            var col = new Color(1, colorLevel, colorLevel);
            deerMaterial.SetColor("_Color",col );
        }
        
    }

	private void wander()
	{

		if (currentWanderTime >= changeDirectionTime) {
			Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderRadius;
			randomDirection += deer.transform.position;
			NavMeshHit hit;
			NavMesh.SamplePosition (randomDirection, out hit, wanderRadius, 1);
			Vector3 finalPosition = hit.position;     
			deer.NavMeshAgent.SetDestination (finalPosition);
			currentWanderTime = 0.0f;
        } else {
			currentWanderTime += Time.deltaTime;
		}


	  
	}

    private bool doesDeerSeePlayer()
    {

        RaycastHit raycastHit;

        if (Physics.Raycast(head.transform.position, head.transform.forward, out raycastHit, 10))
        {
            return raycastHit.collider.gameObject.tag.Equals("Player");
        }
        return false;
    }

	private float distFromPlayer()
	{
		float dist = Vector3.Distance (deer.transform.position, deer.player.transform.position);
		return dist;
	}

	private bool runAwayOrNot(){
        float distance = distFromPlayer();
        CharacterController cc = deer.player.GetComponent<CharacterController>();
        float velocity = cc.velocity.magnitude;
        if (currentFearCoolDownValue >= fearCoolDown)
        {
            if (distance < 15)
            {
                fearLevel += 70 * velocity * 1 / distance;
            }
            Debug.Log("FEAR LEVEL : " + fearLevel);
            if (fearLevel >= 10)
            {
                fearLevel-=10;
            }

            currentFearCoolDownValue = 0;
        }
        else
        {
            currentFearCoolDownValue += Time.deltaTime;
        }

        return fearLevel >= fearLevelToRun || distance < 2 || doesDeerSeePlayer();
	}

	#region IDeerState implementation

	public void updateState ()
	{
        bool b = runAwayOrNot();
        float dist = distFromPlayer();
		if (!b || dist > 20) {
			wander ();
		} else if(b){
			toRunAway ();
		}
        showFearLevelWithMaterial();
    }

	public void toRunAway ()
	{
		deer.CurrentState = new DeerRunAwayState (deer);
		
	}

	public void toIdleState ()
	{
		
	}

	#endregion
}

