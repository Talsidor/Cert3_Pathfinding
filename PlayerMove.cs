using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	Node node;
	Pathfinding myPath;
	Vector3 dest;
	
	// Use this for initialization
	void Start () {
		myPath = GetComponent<Pathfinding>();
		dest = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime);
	}
	
	void OnTriggerStay (Collider collision) {
		
		if(collision.gameObject.name == "Node(Clone)")
		{
			node = collision.gameObject.GetComponent<Node>();
			if(node.cost < int.MaxValue)
			{
				FindCheaperNode();
			}
		}
	}
	
	void FindCheaperNode () {
		Debug.Log(1);
		if(node.x+1 < 10 && myPath.nodeList[node.x+1, node.y].cost != int.MaxValue && !node.impassible)
		{
			Debug.Log(2);
			if(myPath.nodeList[node.x+1, node.y].cost < node.cost)
			{
				Debug.Log(3);
				dest = myPath.nodeList[node.x+1, node.y].transform.position;
			}
		}
		if(node.x-1 >= 0 && myPath.nodeList[node.x-1, node.y].cost != int.MaxValue && !node.impassible)
		{
			if(myPath.nodeList[node.x-1, node.y].cost < node.cost)
				dest = myPath.nodeList[node.x-1, node.y].transform.position;
		}
		if(node.y+1 < 10 && myPath.nodeList[node.x, node.y+1].cost != int.MaxValue && !node.impassible)
		{
			if(myPath.nodeList[node.x, node.y+1].cost < node.cost)
				dest = myPath.nodeList[node.x, node.y+1].transform.position;
		}
		if(node.y-1 >= 0 && myPath.nodeList[node.x, node.y-1].cost != int.MaxValue && !node.impassible)
		{
			if(myPath.nodeList[node.x, node.y-1].cost < node.cost)
				dest = myPath.nodeList[node.x, node.y-1].transform.position;
		}
		transform.LookAt(dest);
	}
}
