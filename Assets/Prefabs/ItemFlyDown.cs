using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFlyDown : MonoBehaviour
{

    [SerializeField] float speed = 8f;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }


}
