﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLeaveScreen : MonoBehaviour
{
    public float minX = -12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }
}
