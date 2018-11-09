using UnityEngine;

public class SteeringForSeparation : Steering
{
    public float comfortDistance = 1;
    public float multiplierInsideComfortDistance = 2;

    void Start()
    {
        
    }

    public override Vector3 Force()
    {
        Vector3 steeringForce = Vector3.zero;
        foreach (GameObject s in GetComponent<Radar>().neighbours)
        {
            if ((s != null) && (s != this.gameObject))
            {
                Vector3 toNeighbour = transform.position - s.transform.position;
                float length = toNeighbour.magnitude;
                steeringForce += toNeighbour.normalized / length;
                if (length < comfortDistance)
                {
                    steeringForce *= multiplierInsideComfortDistance;
                }
            }
        }

        return steeringForce;
    }
}