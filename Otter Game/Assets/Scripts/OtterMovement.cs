using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterMovement : MonoBehaviour
{
    private Rigidbody2D otterBody;

    private bool canMove = true;
    private bool jumpOnExitRaycast = false;

    // Start is called before the first frame update
    void Start()
    {
        otterBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canMove == true)
        {
            MoveOtter();
        }
        boundaries();
    }

    private void MoveOtter()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.DrawLine(transform.position, hit.point, Color.red);
        if (hit.collider != null)
        {
            //(hit.transform.name);
            if (hit.transform.tag == "Otter")
            {
                var pos = Camera.main.ScreenToWorldPoint(new Vector2((float)Input.mousePosition.x, (float)Input.mousePosition.y));
                transform.position = new Vector2(pos.x, pos.y + 1.3f);

                if (transform.position.y > 0.1)
                {
                    transform.position = new Vector2(transform.position.x, 0.1f);
                }
                Turning();
                jumpOnExitRaycast = true;
            }
            else
            {
                jumpOnExitRaycast = false;
            }

            if (jumpOnExitRaycast == true)
            {
                jumpOnExitRaycast = false;
                StartCoroutine("JumpCoolDown");
            }
        }
    }

    private void OtterJump()
    {
        otterBody.velocity = new Vector2(2, 4);
    }

    private void Turning()
    {
        if (Input.touches[0].deltaPosition.y >= 0.01f && transform.GetChild(0).transform.localRotation.z <= 0.1f)
        {
            //print("FORWARD  UP");
            transform.GetChild(0).Rotate(0, 0, 0.2f * Input.touches[0].deltaPosition.y);
        }

        if (Input.touches[0].deltaPosition.y <= 0.01f && transform.GetChild(0).transform.localRotation.z >= -0.1f)
        {
            transform.GetChild(0).Rotate(0, 0, -0.2f * -Input.touches[0].deltaPosition.y);
            //print("FORWARD  DOWN");
        }
    }

    private void boundaries()
    {
        if (transform.position.y < -3.6)
        {
            transform.position = new Vector2(transform.position.x, -3.6f);
        }

        if (transform.position.y > 0.15)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (transform.position.y > 2.6)
        {
            StartCoroutine("StatusQuo");
        }

        if (transform.position.x < -8.35)
        {
            transform.position = new Vector2(-8.35f, transform.position.y);
        }

        if (transform.position.x > 8.35)
        {
            transform.position = new Vector2(8.35f, transform.position.y);
        }

        if (transform.position.y > 2f)
        {
            otterBody.gravityScale = 1;
        }
        else
        {
            otterBody.gravityScale = 0;
        }
    }

    IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(5f);
        if (Input.anyKey)
        {
            yield break;
        }
        else
        {
            OtterJump();
        }
    }

    IEnumerator StatusQuo()
    {
        yield return new WaitForSeconds(1.75f);
        otterBody.velocity = Vector2.zero;
        transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, 0);
        otterBody.AddForce(transform.right * -40);
    }
}