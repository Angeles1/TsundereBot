using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
    Rigidbody2D rb;
    public float speed;
    public Vector2 aPosition1 = new Vector2(3, 3);

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        rb.velocity = new Vector2(0, -speed);
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, 3 * Time.deltaTime);
    }
}
