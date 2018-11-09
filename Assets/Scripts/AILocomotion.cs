using UnityEngine;

public class AILocomotion : Vehicle
{
    private CharacterController controller;
    private Vector3 moveDistance;
    private Rigidbody theRigidbody;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        theRigidbody = GetComponent<Rigidbody>();
        moveDistance = Vector3.zero;
        animator = GetComponent<Animator>();
        base.Start();
    }

    private void FixedUpdate()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        if (velocity.sqrMagnitude > sqrMaxSpeed) velocity = velocity.normalized * maxSpeed;

        moveDistance = velocity * Time.fixedDeltaTime;
        if (isPlanar)
        {
            velocity.y = 0;
            moveDistance.y = 0;
        }

        if (controller != null)
            controller.SimpleMove(velocity);
        else if (theRigidbody == null || theRigidbody.isKinematic)
            transform.position += moveDistance;
        else
            theRigidbody.MovePosition(theRigidbody.position + moveDistance);

        if (velocity.sqrMagnitude > 0.00001)
        {
            var newForward = Vector3.Slerp(transform.forward, velocity, damping * Time.deltaTime);
            if (isPlanar) newForward.y = 0;
            transform.forward = newForward;
        }
        Walk();
    }

    public void Attack(int type)
    {
        animator.SetBool("attack", true);
        animator.SetInteger("int_arg", type);
    }

    public void Walk()
    {
        animator.SetBool("walk", true);
    }

    public void Run()
    {
        animator.SetBool("run", true);
    }
}