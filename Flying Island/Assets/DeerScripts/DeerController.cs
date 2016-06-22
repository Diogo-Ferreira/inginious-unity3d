using UnityEngine;
using System.Collections;

public class DeerController : MonoBehaviour {


	private IDeerState currentState;
	private NavMeshAgent navMeshAgent;
	private GameObject[] runAwayPoints;
	public GameObject player;

    private float runAwaySpeed = 1.0f;
    private float normalSpeed = 1.5f;

	// Use this for initialization
	void Start () {
		this.navMeshAgent = GetComponent<NavMeshAgent> ();
		this.runAwayPoints = GameObject.FindGameObjectsWithTag ("RunAwayPoint");
		this.currentState = new DeerIdleState (this);
        this.normalSpeed = navMeshAgent.speed;
        this.runAwaySpeed = normalSpeed * 2.5f;
 	}
	
	// Update is called once per frame
	void Update () {
		currentState.updateState ();
	}

	public GameObject[] RunAwayPoints {
		get {
			return this.runAwayPoints;
		}
		set {
			runAwayPoints = value;
		}
	}

	public NavMeshAgent NavMeshAgent {
		get {
			return this.navMeshAgent;
		}
		set {
			navMeshAgent = value;
		}
	}

	public IDeerState CurrentState {
		get {
			return this.currentState;
		}
		set {
			currentState = value;
		}
	}


    public float NormalSpeed
    {
        get
        {
            return this.normalSpeed;
        }
    }

    public float RunAwaySpeed
    {
        get
        {
            return this.runAwaySpeed;
        }
    }


}
