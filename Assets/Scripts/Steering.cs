using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    public float weight = 1;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public virtual Vector3 Force()
    {
        return Vector3.zero;
    }
}