using UnityEngine;

namespace Assets.Scripts
{
    public class BackgroundScript : MonoBehaviour
    {
        public Transform Origin;
        public float Distance = 11.15f;
        public float Jump;


        public void Start()
        {
            Jump = 2*renderer.bounds.size.y;
        }

        public void Update()
        {
            if (Origin.position.y - transform.position.y > Distance)
            {
                transform.position += Vector3.up*Jump;
            }
        }
    }
}