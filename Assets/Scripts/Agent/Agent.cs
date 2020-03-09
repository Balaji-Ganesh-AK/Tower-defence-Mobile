using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State {ToNextNode, ReachFinalNode};
public class Agent : MonoBehaviour
{
    public State agent_state;
    public Node to_node;
    public GameObject next_node;
    public float speed;
    public bool b_groundNav;
    //public List<GameObject> wayPoints;
    private NavMeshAgent agent;
    
    private void Start()
    {
        agent_state = State.ToNextNode;
        agent = GetComponent<NavMeshAgent>();
        if(agent!=null && b_groundNav)
        {
            agent.enabled = true;
            agent.isStopped = false;
            if (to_node != null)
                agent.SetDestination(to_node.transform.position);
        }
    }
    void Update()
    {
        switch (agent_state)
        {
            case State.ToNextNode:
                if (to_node != null)
                {
                    Vector3 translate_dir = to_node.transform.position - this.transform.position;
                    transform.Translate(translate_dir.normalized * speed * Time.deltaTime, Space.World);
                }
                if (Vector3.Distance(transform.position, to_node.transform.position) <= 0.1f)
                {
                    agent_state = State.ReachFinalNode;
                }
                break;
            case State.ReachFinalNode:
                break;
        }
    } 

    private void OnTriggerEnter(Collider other)
    {
        Node nextNode = other.transform.GetComponent<Node>()?.GetNextNode();
        //Debug.Log("Next node: " + nextNode.name);
        //Debug.Log("Trigger: " + other.name);
        if (nextNode != null)
        {
            to_node = nextNode;
            //SetAgentDestination(to_node); //???
        }
        
    }

    

    public void SetAgentDestination(Node i_nextNode)
    {
        agent.SetDestination(i_nextNode.transform.position);
    }

}
