using UnityEngine;

public class ColliderColorChange : MonoBehaviour
{
        private void Start()
        {
                
        }

        private void Update()
        {
                
        }

        private void OnTriggerEnter(Collider other)
        {
                if (other.gameObject.GetComponent<Vehicle>() != null)
                {
                        this.GetComponent<Renderer>().material.color = Color.red;
                }
        }

        private void OnTriggerExit(Collider other)
        {
                this.GetComponent<Renderer>().material.color = Color.gray;
        }
}