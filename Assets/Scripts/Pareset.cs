using UnityEngine;

namespace Assets.Scripts
{
    public class Pareset : MonoBehaviour
    {
        public ParticleSystem PSystem;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PSystem.Clear(true);
            }
        }
    }
}