using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
   
    //velocity of the bullet
    public float velocity=100f;
    private int damege=0;

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

        // if the bullet collides with an enemy
        if(other.gameObject.tag=="Inimigo")
        {
            //try get the health component of the enemy
            if(other.gameObject.TryGetComponent<Health>(out Health health))
                health.DealDamege(damege);
        } 
        Destroy(gameObject,5f);
    }
    //set damege of the bullet
    public void SetDamege(int damege){
        this.damege=damege;
    }
}
