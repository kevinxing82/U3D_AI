using UnityEngine;

public class Vehicle : MonoBehaviour
{

    protected Vector3 acceleration;
    public float computeInterval = 0.2f;
    public float damping = 0.9f;
    public bool isPlanar = true;
    public float mass = 1;
    public float maxForce = 100;
    public float maxSpeed = 1;
    protected float sqrMaxSpeed;
    private Vector3 steeringForce;
    private Steering[] steerings;
    private float timer;
    public Vector3 velocity;

    protected void Start()
    {
        steeringForce = Vector3.zero;
        sqrMaxSpeed = maxSpeed * maxSpeed;
        timer = 0;
        steerings = GetComponents<Steering>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        steeringForce = Vector3.zero;
        if (timer > computeInterval)
        {
            foreach (var s in steerings)
            {
                if (s.enabled)
                {
                    steeringForce += s.Force() * s.weight;
                }
            }
            steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
            acceleration = steeringForce / mass;
            timer = 0;
        }
    }
}