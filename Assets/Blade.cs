﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;

    bool isCutting = false;
    GameObject currentBladeTrail;
    Rigidbody2D rb;
    Camera cam;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } else if (Input.GetMouseButtonUp(0)) 
        {
            StopCutting();
        }

        if (isCutting) 
        {
            UpdateCut();
        }
    }

    private void StartCutting() 
    {
        isCutting = true;
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = rb.position;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
    }

    private void StopCutting() 
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
    }

    private void UpdateCut()
    {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
