using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Route : MonoBehaviour {
	
	private NavMeshAgent agent;
	public GameObject[] listOfWaypointObjects;
	private int currentTarget;
	
	// Use this for initialization
	void Start () {
		currentTarget = 0;
		agent = gameObject.GetComponent<NavMeshAgent> ();
		agent.SetDestination (listOfWaypointObjects[currentTarget].transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myPos = gameObject.transform.position;
		Vector3 targetPos = listOfWaypointObjects[currentTarget].transform.position;
		myPos.y = targetPos.y = 0;
		float distance = Vector3.Magnitude(myPos - targetPos);
		
		if(distance <= .5) {
			currentTarget++;
			if (currentTarget == listOfWaypointObjects.Length)
				currentTarget = 0;
			if(listOfWaypointObjects[currentTarget] != null)
				agent.SetDestination(listOfWaypointObjects[currentTarget].transform.position);
		}
		
		
		//float dist = Vector3.Magnitude(listOfWaypointObjects[currentTarget].transform.position - transform.position);
	}
}
