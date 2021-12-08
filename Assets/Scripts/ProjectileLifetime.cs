using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    private float timer = 0;

    private float lifetime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < lifetime)
            timer += Time.deltaTime;
        else
        {
            //after 3 seconds destroy this gameobject
            Destroy(gameObject);
        }
    }
}
