using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour {
	
	static public Node startNode, endNode;
	public Node nodePrefab;
	public Node[,] nodeList;
	ArrayList waitingNodes;
	
	// Use this for initialization
	void Start () {
		nodeList = new Node[10,10];
		waitingNodes = new ArrayList();
		
		for(int y=0;y<10;y++)
		{
			for(int x=0;x<10;x++)
			{
				nodeList[x,y] = Instantiate(nodePrefab,new Vector3(x,1,y), Quaternion.identity) as Node;
				nodeList[x,y].cost = int.MaxValue;
				nodeList[x,y].x = x;
				nodeList[x,y].y = y;
				
				// If node's position is equal to player position, set as start node.
				if(nodeList[x,y].x == transform.position.x && nodeList[x,y].y == transform.position.z)
					startNode = nodeList[x,y];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(startNode && endNode)
		{
			if(waitingNodes.Count < 1)
			{
				endNode.cost = 0;
				SetAdjacent(endNode);
			}
			else
			{
				SetAdjacent(waitingNodes[0] as Node);
				waitingNodes.RemoveAt(0);
			}
		}
	}
	
	void SetAdjacent (Node node) {
		if(node.x+1 < 10 && nodeList[node.x+1, node.y].cost == int.MaxValue && !node.impassible)
		{
			nodeList[node.x+1, node.y].cost = node.cost+1;
			waitingNodes.Add(nodeList[node.x+1, node.y]);
		}
		if(node.x-1 >= 0 && nodeList[node.x-1, node.y].cost == int.MaxValue && !node.impassible)
		{
			nodeList[node.x-1, node.y].cost = node.cost+1;
			waitingNodes.Add(nodeList[node.x-1, node.y]);
		}
		if(node.y+1 < 10 && nodeList[node.x, node.y+1].cost == int.MaxValue && !node.impassible)
		{
			nodeList[node.x, node.y+1].cost = node.cost+1;
			waitingNodes.Add(nodeList[node.x, node.y+1]);
		}
		if(node.y-1 >= 0 && nodeList[node.x, node.y-1].cost == int.MaxValue && !node.impassible)
		{
			nodeList[node.x, node.y-1].cost = node.cost+1;
			waitingNodes.Add(nodeList[node.x, node.y-1]);
		}
	}
}