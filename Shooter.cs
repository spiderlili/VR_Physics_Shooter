using UnityEngine;
using System.Collections;

//shoot projectiles to knock rigidbodies down

public class Shooter : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shotPos;     //store the position to shoot projectiles from an empty game object
    public float shotForce = 1000f; //the amount of force to shoot with
    public float moveSpeed = 10f; //movement speed of the camera to aim the shots
    
    void Update ()
    {
    
    //use deltaTime for smoothing and moveSpeed for speed increase
    
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        
        //move the camera around
        
        transform.Translate(new Vector3(h, v, 0f));
        
        if(Input.GetButtonUp("Fire1"))
        {
        //create instances of the projectile prefab and add force to it
        //cast results of this to the rigidbody type rather than an instantiate object
            Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
            shot.AddForce(shotPos.forward * shotForce);
        }
    }
}
