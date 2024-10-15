using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder_Behaviour : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;

    void Start(){
        boxCollider2D = GetComponent<BoxCollider2D>();
        UpdateColliderSize();
        StartCoroutine("DestroyExplode");
    }
    void UpdateColliderSize(){
        boxCollider2D.size = transform.localScale / 33f;
    }
    void Update(){
        UpdateColliderSize();
    }

   IEnumerator DestroyExplode(){
    SoundController._instance.ExplodeAudioPlay();
    yield return new WaitForSeconds(1);
    Destroy(gameObject);

   }
}
