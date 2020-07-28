using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class AIAnimation : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {

        bool shouldMove =  agent.remainingDistance > agent.radius;

        // Update animation parameters
        anim.SetBool("isWalking", shouldMove);

    }


}