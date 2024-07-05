using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lot : MonoBehaviour
{

    public Rigidbody2D rb;

    public bool isGood;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.simulated = false;
        transform.localScale = new Vector3(0.75f, 1.5f, 1.5f);
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
        transform.localScale = new Vector3(0.5f, 1f, 1f);
    }
}
