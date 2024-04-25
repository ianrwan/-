using System.Collections;
using System.Collections.Generic;
using Megumin.Scene.HeroHouse;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving = false;
    private bool isCollide = false;
    private Vector3 direction;
    public LayerMask layerMask;
    private Animator animator;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    public void Update()
    {
        if(DialogueManager.instance.isDialoguePlaying || SpecialEventsControl.isSpecialEventStart)
        {
            StopAnimation();
            return;
        }

        Move(InputManager.instance.movement.x, InputManager.instance.movement.y);
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

    private void Move(float horizontal, float vertical)
    {
        direction = new Vector3(horizontal, vertical, 0);
        Vector3 movePosition = direction*9*moveSpeed*Time.fixedDeltaTime;

        Vector3 currentTransformPosition = transform.position + movePosition;

        rigidbody2D.MovePosition(currentTransformPosition);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        
        // set if the player is moving or not
        // direction == (0, 0, 0) means the player doesn't move
        if(direction == Vector3.zero)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        PlayerAnimation(direction);
    }

    private void PlayerAnimation(Vector3 direction)
    {
        animator.SetBool("isMove", isMoving);

        if(isMoving == true)
        {
            animator.SetFloat("moveX", direction.x);
            animator.SetFloat("moveY", direction.y);
        }
    }

    private void StopAnimation()
    {
        isMoving = false;
        PlayerAnimation(Vector3.zero);
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

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        isCollide = true;
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        isCollide = false;
    }
}
