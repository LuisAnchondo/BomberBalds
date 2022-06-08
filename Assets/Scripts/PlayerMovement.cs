using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private const string AXIS_H = "Horizontal", AXIS_V ="Vertical";
    public float speedMovement = 5;
    private Rigidbody2D _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw(AXIS_V)>0.2f){
            transform.position += (transform.up  * speedMovement *  Time.deltaTime);
        }
        if(Input.GetAxisRaw(AXIS_V)< -0.2f){
            transform.position += (-transform.up * speedMovement/2 *  Time.deltaTime);
        }

        if(Input.GetAxisRaw(AXIS_H)>0.2f){
            transform.position += (transform.right  * speedMovement *  Time.deltaTime);
        }
        if(Input.GetAxisRaw(AXIS_H)< -0.2f){
            transform.position += (-transform.right * speedMovement/2 *  Time.deltaTime);
        }
        
    }
}
