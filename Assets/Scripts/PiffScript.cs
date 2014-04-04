using System;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts
{
    public class PiffScript : MonoBehaviour
    {
        private readonly Random _rndGenerator = new Random(DateTime.Now.Millisecond);
        public Margin ScreenMargin;
        public bool CanInstantiateInMiddleOfScreen = false;
        public bool CanRotate = false;
        public bool AutoDirection = false;
        public ParticleStates State = ParticleStates.Idle;
        public Transform Direction;

        public void Setup()
        {
            State = ParticleStates.Busy;

            ScreenMargin = new Margin(-3.8f, 10, 3.8f, 0);
            if (CanInstantiateInMiddleOfScreen)
            {
                var direction = _rndGenerator.Next(1, (int) (ScreenMargin.Right - ScreenMargin.Left*100))/100.0f - 2.5f;

                transform.position = new Vector3(direction, transform.position.y, transform.position.z);

                if (CanRotate)
                {
                    float rRotation = _rndGenerator.Next(0, 360);
                    transform.rotation = Quaternion.Euler(rRotation, 90, 90);
                }
            }
            else
            {
                var rDirection = _rndGenerator.Next(1, 100);
                var direction = rDirection > 50 ? ScreenMargin.Right : ScreenMargin.Left;

                transform.position = new Vector3(direction, transform.position.y, transform.position.z);

                if (CanRotate)
                {
                    float rRotation = _rndGenerator.Next(0, 100) - 50;
                    if (direction < 0)
                    {
                        rRotation += 180;
                    }
                    transform.rotation = Quaternion.Euler(rRotation, 90, 90);
                }
            }
        }


        public void Update()
        {
            if (AutoDirection)
            {
                if (Direction)
                {
                    var angle = Mathf.Atan2(Direction.position.y - transform.position.y, transform.position.x - Direction.position.x)*Mathf.Rad2Deg;

                    transform.rotation = Quaternion.Euler(new Vector3(angle, 90, 90));
                }
            }

            if (State == ParticleStates.Busy)
            {
                if (Direction.transform.position.y - transform.position.y > 7)
                {
                    State = ParticleStates.Idle;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}