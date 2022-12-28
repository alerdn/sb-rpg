using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMovement : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
     
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(Input.mousePosition);
        }
    }
}
