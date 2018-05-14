using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehavior : MonoBehaviour {
    public Transform player;
    public int leftBorder;
    public int rightBorder;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.position.x > leftBorder && player.position.x < rightBorder) 
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
