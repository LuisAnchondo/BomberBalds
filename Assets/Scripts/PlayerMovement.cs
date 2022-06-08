using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    private const string AXIS_H = "Horizontal", AXIS_V ="Vertical";
    public float speedMovement = 5;
    public GameObject bomb;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {   

        if(Input.GetAxisRaw(AXIS_V) != 0){
            float direction = Input.GetAxisRaw(AXIS_V);
            transform.position += ((direction/Math.Abs(direction)) * transform.up  * speedMovement *  Time.deltaTime);
        }else if(Input.GetAxisRaw(AXIS_H) != 0){
            float direction = Input.GetAxisRaw(AXIS_H);
            transform.position += ((direction/Math.Abs(direction)) * transform.right  * speedMovement *  Time.deltaTime);
        }

        if(Input.GetKeyDown("space")){
            Instantiate(bomb, transform.position, Quaternion.identity);
        }

        
    }
}
