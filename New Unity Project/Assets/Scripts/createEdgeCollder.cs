using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEdgeCollder : MonoBehaviour {

    //public List<Vector2> newVerticies = new List<Vector2>();
    // Use this for initialization
    public int leftBorder = -7;
    public int rightBorder = 200;
    public int lowerBorder = -4;
    public int upperBorder = 9;
    void Awake () {
         
    Vector2[] myVector2Array = { new Vector2(leftBorder, lowerBorder),  new Vector2(leftBorder, upperBorder), new Vector2(rightBorder, upperBorder), new Vector2(rightBorder, lowerBorder), new Vector2(leftBorder, lowerBorder) };
        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        edgeCollider.points = myVector2Array;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
