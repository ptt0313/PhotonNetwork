using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum State
{
    WALK,
    ATTACK,
    DIE
}
public class Rake : MonoBehaviourPunCallbacks
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] GameObject destination;
    [SerializeField] PhotonView photonView;
    [SerializeField] Animator animator;
    [SerializeField] State state;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        state = State.WALK;
        destination = GameObject.Find("Nexus");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other == destination)
        {
            state = State.ATTACK;
        }
    }
    private void Update()
    {
        switch (state)
        {
            case State.WALK: Walk();
                break;
            case State.ATTACK: Attack();
                break;
            case State.DIE: Die();
                break;
        }
    }
    public void Walk()
    {
        navMeshAgent.SetDestination(destination.transform.position);
        transform.LookAt(destination.transform.position);
    }
    public void Attack()
    {
        animator.Play("Attack");
    }
    public void Die()
    {
        animator.Play("Die");
        PhotonNetwork.Destroy(gameObject);
    }
}
