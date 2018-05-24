using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehavior : MonoBehaviour {
    public Transform player;
    public GameObject Border;
    float leftBorder;
    float rightBorder;
    RaycastHit hit;
    Ray ray;
    Camera cam;
    BoxCollider2D collider;
    // Use this for initialization
    void Start () {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        cam = Camera.main;
        if (transform.position.x+ cam.orthographicSize * cam.aspect > player.position.x)
        {
            leftBorder = (Border.GetComponent<EdgeCollider2D>().points[0].x);
            rightBorder = (Border.GetComponent<EdgeCollider2D>().points[2].x);
            //

            transform.position = new Vector3(leftBorder + cam.orthographicSize * cam.aspect, transform.position.y, transform.position.z);
            //print(rightBorder);
        }
        //collider = gameObject.AddComponent<BoxCollider2D>();
        //collider.size
        //collider.offset.Set(0, -5);
       // collider.isTrigger = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Enemy")
        col.gameObject.SendMessage("SetActive");
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        col.gameObject.SendMessage("SetNonActive");
    }

        // Update is called once per frame
        void Update () {
        if (player.position.x > leftBorder+ cam.orthographicSize * cam.aspect && player.position.x < rightBorder-cam.orthographicSize * cam.aspect) 
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
       
    }
}
