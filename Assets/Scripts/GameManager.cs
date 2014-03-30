using System;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private Random _rndGenerator = new Random(DateTime.Now.Millisecond);
        private float _score = 10f;
        public GameObject[] Piffs;
        public Transform PasheTransform;
        public int DeployInterval = 1;
        private float _lastTick;

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
            Instantiate(Piffs[index], PasheTransform.position + Vector3.up*5, Piffs[index].transform.rotation);
        }
    }
}