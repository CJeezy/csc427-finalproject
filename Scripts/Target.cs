using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent[] navAgents;
    public Transform targetMarker;
    private Manager manager;

    void Start ()
    {
	    navAgents = FindObjectsOfType(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent[];
        manager = GameObject.FindObjectOfType<Manager>();
    }

    void UpdateTargets ( Vector3 targetPosition  )
    {
	    foreach(UnityEngine.AI.NavMeshAgent agent in navAgents) 
        {
		    agent.destination = targetPosition;
	    }
    }

    void Update ()
    {
        int button = 0;
        /*
        //Get the point of the hit position when the mouse is being clicked
        if(Input.GetMouseButtonDown(button)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) 
            {
                Vector3 targetPosition = hitInfo.point;
                UpdateTargets(targetPosition);
                targetMarker.position = targetPosition + new Vector3(0,5,0);
            }
        }*/

        Vector3 targetPosition = this.gameObject.transform.position;
        UpdateTargets(targetPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            manager.restartScene();

        if (other.tag == "Food")
            manager.nextScene();
    }
}