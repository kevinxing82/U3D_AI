using UnityEngine;

public class SteeringForAlignment : Steering
{
    private void Start()
    {
        
    }

    public override Vector3 Force()
    {
        Vector3 averageDirection = Vector3.zero;
        int neighborCount = 0;
        foreach (GameObject s in GetComponent<Radar>().neighbours)
        {
            if ((s != null) && (s != this.gameObject))
            {
                averageDirection += s.transform.forward;
                neighborCount++;
            }
        }

        if (neighborCount > 0)
        {
            averageDirection /= (float) neighborCount;
            averageDirection -= transform.forward;
        }

        return averageDirection;
    }
}