﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {
    public KeyCode key;
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    Color old;
    public bool createMode;
    public GameObject n;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
        old = sr.color;
        PlayerPrefs.SetInt("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }

        }
        else
        {

            if (Input.GetKeyDown(key))
                StartCoroutine(Pressed());

            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                AddScore();
                active = false;
            }
            //Destroy(note);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
            note = col.gameObject;
           // Destroy(col.gameObject);
    }


    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);
    }

    IEnumerator Pressed()
    {
        old = sr.color;
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        sr.color = old;

    }
}
