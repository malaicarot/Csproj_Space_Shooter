using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Flying_Down : MonoBehaviour
{
   [SerializeField] float speed = 5.0f;
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
