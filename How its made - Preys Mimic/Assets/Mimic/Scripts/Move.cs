using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Move : MonoBehaviour
{
	private NavMeshAgent agent;
	public List< Transform> targetDestination;
	public UnityEvent OnLocationReached;

	Vector3 targetPosition = Vector3.zero;
	float distance { get { return Vector3.Distance(targetPosition, transform.position);  } }
	float changeDistance = 1;

    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		ChangeLocation();
    }


	bool locationReached = false;

	private void Update()
	{
		if (distance < changeDistance && !locationReached)
		{
			agent.velocity = Vector3.zero;
			agent.ResetPath();
			OnLocationReached.Invoke();
			locationReached = true;
			Debug.Log("reeached");
		}
		else if(distance > changeDistance)
		{
			locationReached = false;
		}
	}

	public void ChangeLocation()
	{
		int randomNumber = Random.Range(0, targetDestination.Count);
		targetPosition = targetDestination[randomNumber].position;
		agent.SetDestination(targetPosition);
	}
}
