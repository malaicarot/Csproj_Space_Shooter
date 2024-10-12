using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSelfDestructScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _health;

    [SerializeField] GameObject ExplodePrefabs;
    // [SerializeField] BoxCollider2D boxCollider2D;

    public int health {get => _health; set => _health = value;}
    public int damage { get => _damage; set => _damage = value; }
    public float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    void Start(){
        // boxCollider2D = GetComponent<BoxCollider2D>();
    }


    public void Move()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    public int Attack()
    {
        return 0;

    }

    public void TakeDamage(int dame)
    {
        health -= dame;

    }

    void Update()
    {
        Move();
        StartCoroutine(SelfDestruct());

    }

    IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(1f);
        GameObject explore = Instantiate(ExplodePrefabs, transform.position, Quaternion.identity);
        explore.transform.localScale = new Vector3(10f, 10f, 1f);
        Destroy(gameObject);
    }
}
