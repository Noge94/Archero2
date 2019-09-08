using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public static Player instance;
    public float speed;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    
    private void Update()
    {

        Vector3 movement = InputController.instance.stick * speed * Time.deltaTime;

        transform.position = transform.position + movement;

    }
}
