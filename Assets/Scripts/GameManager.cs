using System;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private readonly Random _rndGenerator = new Random(DateTime.Now.Millisecond);
        private float _score = 10f;
        public PiffScript[] Piffs;
        public Transform PasheTransform;
        public int DeployInterval = 1;
        private float _lastTick;

        public Margin ScreenMargin;

        public void Start()
        {
            _lastTick = Time.time;
        }

        public void Update()
        {
            if (Time.time - _lastTick > DeployInterval)
            {
                CreatePiff();
                _lastTick = Time.time;
            }
        }

        private void CreatePiff()
        {
            var index = _rndGenerator.Next(0, Piffs.Length);
            var newParticle = (GameObject) Instantiate(Piffs[index].gameObject, PasheTransform.position + Vector3.up*8, Piffs[index].transform.rotation);
            newParticle.GetComponent<PiffScript>().Direction = PasheTransform;
        }
    }
}