using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    // the bullet prefab
    [SerializeField] private GameObject bulletPrefab;
    // the position of the bullet when it is fired
    [SerializeField] private Transform bulletSpawn;
    // the force of the bullet
    [SerializeField] private float bulletForce=50f;
    // the amount of time between shots
    [SerializeField] private float timeBetweenShots=0.5f;
    // the time when the next shot can be fired
    private float nextShotTime=0f;
    
    // Update is called once per frame
    void Update()
    {
        // if the player presses the left mouse button and the time is greater than the next shot time
        if(Input.GetKey(KeyCode.Mouse0) && Time.time>=nextShotTime){
            // set the next shot time to the current time plus the time between shots
            nextShotTime=Time.time+timeBetweenShots;
            // create a bullet
            GameObject bullet=Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
            // add a force to the bullet
            bullet.GetComponent<Bullet>().velocity=bulletForce;      
        }
    }
}
