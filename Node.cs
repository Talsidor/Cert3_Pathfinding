using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	
	public int x,y,z;
	public Material red,green;
	Renderer ren;
	public bool impassible;
	
	private int _cost;
	public int cost
	{
		get
		{
			return _cost;
		}
		set
		{
			if(!impassible)
			{
				_cost = value;
			}
			else
				_cost = int.MaxValue;
		}
	}
	
	// Use this for initialization
	void Start () {
		z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ren.material.Lerp(red,green,cost/10.0f);
	}
	
	void OnMouseDown () {
		if(!Pathfinding.endNode)
			Pathfinding.endNode = this;
	}
	
	void OnTriggerEnter (Collider collision) {
		if(collision.gameObject.tag == "Wall")
		{
			impassible = true;
		}
	}
}
