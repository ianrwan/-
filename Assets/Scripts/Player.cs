using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving = false;
    private Vector3 direction;
    public LayerMask layerMask;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += direction*9*moveSpeed*Time.deltaTime;
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        
        var temp = direction;
        if(direction != Vector3.zero)
        {
            isMoving = true;
            PlayerAnimation(direction, isMoving);
        }

        else
        {
            isMoving = false;
            PlayerAnimation(direction, isMoving);
        }

        // direction.y = Input.GetAxisRaw("Vertical")*9;

        // if(direction.x != 0 && direction.y != 0)
        //     return;

        // if(direction != Vector2.zero)
        // {
        //     var targetPos = transform.position;
        //     targetPos.x += direction.x;
        //     targetPos.y += direction.y;

        //     if(!isWakable(targetPos))
        //         return;

        //     StartCoroutine(Move(targetPos));
        // }
    }

    private void PlayerAnimation(Vector3 direction, bool isMoving)
    {
        animator.SetBool("isMove", isMoving);

        if(isMoving == true)
        {
            animator.SetFloat("moveX", direction.x);
            animator.SetFloat("moveY", direction.y);
        }
    }

    private IEnumerator IsStop()
    {
        yield return null;
    }

    private IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool isWakable(Vector3 targetPos)
    {
        Debug.Log(targetPos);
        // Debug.Log(Physics2D.OverlapCircle(targetPos, 100f, layerMask));

        var leftDownPos = new Vector2(targetPos.x-4.5f/2, targetPos.y-4.5f/2);
        var rightUpPos = new Vector2(targetPos.x+4.5f/2, targetPos.y+4.5f/2);
        if(Physics2D.OverlapArea(leftDownPos, rightUpPos, layerMask) != null)
            return false;
        Debug.Log("Pass");
        return true;
    }
}
