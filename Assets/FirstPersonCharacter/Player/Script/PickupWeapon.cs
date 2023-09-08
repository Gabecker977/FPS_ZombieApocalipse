using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Interactable
{   
    // The position of the weapon when it is picked up
    [SerializeField] private Transform parent;

    
    public override void OffInteract()
    {
        
    }

    public override void OnFocus()
    {
        
    }

    public override void OnInteract()
    {
        
        // remove the rigidbody and the box collider from the weapon
        GetComponent<Rigidbody>().isKinematic=true;
        GetComponent<BoxCollider>().enabled=false;
        // set the position of the weapon to the position of the parent
        
        transform.position=parent.position;
        transform.parent=parent;
        transform.localPosition+=new Vector3(0.62f,-0.81f,0.45f);
        transform.localRotation=Quaternion.Euler(0,0,0);
        // Add the FireGun script to the weapon
        gameObject.GetComponent<FireGun>().enabled=true;
        // disable this script
        this.enabled=false;    
    }

    public override void OnLoseFocus()
    {
        
    }
}
