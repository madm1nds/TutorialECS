using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerComponent
{
    static readonly int isMovingId = Animator.StringToHash("IsMoving");


    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
            transform.position += new Vector3(x, y, 0) * (Time.deltaTime * moveSpeed);

            if (!isMoving)
            {
                isMoving = true;
                animator.SetBool(isMovingId, isMoving);
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                animator.SetBool(isMovingId, isMoving);
            }
        }
    }

}
