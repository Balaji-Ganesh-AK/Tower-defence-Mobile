using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> linkedNodes;


    public Node GetNextNode()
    {
        if(linkedNodes.Count>0 && linkedNodes[0]!=null)
        {
            return linkedNodes[0];
        }
        return null;
    }

#if UNITY_EDITOR
    /// Draws the links between nodes for editor purposes
    protected virtual void OnDrawGizmos()
    {
        if (linkedNodes == null)
        {
            return;
        }
        int count = linkedNodes.Count;
        for (int i = 0; i < count; i++)
        {
            Node node = linkedNodes[i];
            if (node != null)
            {
                Gizmos.DrawLine(transform.position, node.transform.position);
            }
        }
    }
#endif
}
