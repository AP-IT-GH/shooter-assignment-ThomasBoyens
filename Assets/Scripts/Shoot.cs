using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform parent;
    float timer = 3f;
    bool start = false;
    public float shootRate = 3f;
    public int ProjectileSpeed = 50;
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        
        if (start)
        {
            if (timer <= shootRate){
                timer += Time.deltaTime;
                print(shootRate);
                print(timer);
            }
            else
            {
                timer = shootRate;
                start = false;
            }
           
        }
        
    }
    private void OnShoot()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position+transform.forward,transform.rotation * Quaternion.Euler(90f, 0, 0)) ;
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward* ProjectileSpeed, ForceMode.VelocityChange);
        changeParent(newProjectile, parent);
        start = true;
        timer = 0f;
  
    }

    void changeParent(GameObject newProjectile, Transform newParent)
    {
        newProjectile.transform.SetParent(newParent);
    }

}
