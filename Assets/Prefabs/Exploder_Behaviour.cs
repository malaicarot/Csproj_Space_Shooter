using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder_Behaviour : MonoBehaviour
{


    void Start(){
        
        // StartCoroutine(Invoke("DestroyExplode", 0.5f));
        StartCoroutine("DestroyExplode");
    }

   IEnumerator DestroyExplode(){
    AudioSource audioSource = GetComponent<AudioSource>();
    audioSource.Play();
    yield return new WaitForSeconds(1);

    Destroy(gameObject);

   }
}
