using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    //velocity of the bullet
    public float velocity=100f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity=transform.forward*velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // when the bullet collides with something
    private void OnCollisionEnter(Collision other) {
        // destroy the bullet
        if(other.gameObject.tag!="Player" && other.gameObject.tag!="Bullet")
        Destroy(gameObject,1f);
    }
}
