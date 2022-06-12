using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyMovement : MonoBehaviour
{
    // TODO: Documentar juas juas
    public float speed;
    private Rigidbody2D myRigidbody2D;
    private Vector2 change;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private bool mvH;
    private bool mvV;
    private float mvHoz;
    private float mvVer;

    void Update()
    {
        mvHoz = Input.GetAxisRaw("Horizontal");
        mvVer = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        change.x = 0;
        change.y = 0;

        if (Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") != 0)
        {
            if (mvH)
            {
                change.y = mvVer;
            }
            else if (mvV)
            {
                change.x = mvHoz;
            }
            else
            {
                change.x = mvHoz;
                change.y = mvVer;
            }
        }
        else
        {
            mvH = mvHoz != 0;
            change.x = mvHoz;
            mvV = mvVer != 0;
            change.y = mvVer;
        }
        MoveCharacter();
    }


    void MoveCharacter()
    {
        myRigidbody2D.MovePosition(
            (Vector2)transform.position + change * speed * Time.deltaTime
        );
    }

}
