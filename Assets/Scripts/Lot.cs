using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lot : MonoBehaviour
{

    public Rigidbody2D rb;
    public BoxCollider2D coll;

    public bool isGood;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.simulated = false;
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Chosen");
    }

    public void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        transform.position = mousePos;
    }

    public void OnMouseUp()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.simulated = true;
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
