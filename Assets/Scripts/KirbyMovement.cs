using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody2D;
    private Vector2 change;
    enum LastPosition {Left, Right, Down, Up}
    private LastPosition lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        
        lastPosition = LastPosition.Down;
    }

    // Update is called once per frame
    void Update()
    {
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        // Right detection
        if(change.x > 0)
        {
            if(change.y > 0 && lastPosition == LastPosition.Right || lastPosition == LastPosition.Up && change.y > 0)
            {
                change.x = 0;
                MoveCharacter();
                lastPosition = LastPosition.Up;
            }else if (change.y < 0 && lastPosition == LastPosition.Right || lastPosition == LastPosition.Down && change.y < 0)
            {
                change.x = 0;
                MoveCharacter();
                lastPosition = LastPosition.Down;
            }
            else
            {
                change.y = 0;
                MoveCharacter();
                lastPosition = LastPosition.Right;
            }
        }

        // Left detection
        if (change.x < 0)
        {
            if (change.y > 0 && lastPosition == LastPosition.Left || lastPosition == LastPosition.Up && change.y > 0)
            {
                change.x = 0;
                MoveCharacter();
                lastPosition = LastPosition.Up;
            }
            else if (change.y < 0 && lastPosition == LastPosition.Left || lastPosition == LastPosition.Down && change.y < 0)
            {
                change.x = 0;
                MoveCharacter();
                lastPosition = LastPosition.Down;
            }
            else
            {
                change.y = 0;
                MoveCharacter();
                lastPosition = LastPosition.Left;
            }
        }

        // Up detection
        if (change.y > 0)
        {
            if (change.x > 0 && lastPosition == LastPosition.Up || lastPosition == LastPosition.Right && change.x > 0)
            {
                change.y = 0;
                MoveCharacter();
                lastPosition = LastPosition.Right;
            }
            else if (change.x < 0 && lastPosition == LastPosition.Up || lastPosition == LastPosition.Left && change.x < 0)
            {
                change.y = 0;
                MoveCharacter();
                lastPosition = LastPosition.Left;
            }
            else
            {
                change.x = 0;
                MoveCharacter();
                lastPosition = LastPosition.Up;
            }
        }

        // Down detection
        if (change.y < 0)
        {
            if (change.x > 0 && lastPosition == LastPosition.Down || lastPosition == LastPosition.Right && change.x > 0)
            {
                change.y = 0;
                MoveCharacter();
                lastPosition = LastPosition.Right;
            }
            else if (change.x < 0 && lastPosition == LastPosition.Down || lastPosition == LastPosition.Left && change.x < 0)
            {
                change.y = 0;
                MoveCharacter();
                lastPosition = LastPosition.Left;
            }
            else
            {
                change.x = 0;
                MoveCharacter();
                lastPosition = LastPosition.Down;
            }
        }
        print(change);
    }

    void MoveCharacter()
    {
        myRigidbody2D.MovePosition(
            (Vector2)transform.position + change * speed * Time.deltaTime
        );
    }

}
