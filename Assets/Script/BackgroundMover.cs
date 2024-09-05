using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private Renderer bckRenderer;
    private float speed = 0.5f;

    

    // Update is called once per frame
    void Update()
    {
        bckRenderer.material.mainTextureOffset += new Vector2(0f, speed * Time.deltaTime);
        
    }
}
