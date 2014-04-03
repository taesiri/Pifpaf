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

        public BackgroundScript Bg1;
        public BackgroundScript Bg2;

        public void Start()
        {
            _lastTick = Time.time;

            Bg1.transform.position = new Vector3(transform.position.x, 11.9273f, -1);
            Bg2.transform.position = new Vector3(transform.position.x, 11.9273f + Bg1.renderer.bounds.size.y, -1);
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
            var index = GenerateIndex();

            Piffs[index].gameObject.SetActive(true);
            Piffs[index].transform.position = new Vector3(0, PasheTransform.position.y + 10, -1.7f);
            Piffs[index].Setup();
        }

        private int GenerateIndex()
        {
            var index = _rndGenerator.Next(0, Piffs.Length);

            while (Piffs[index].State != ParticleStates.Idle)
            {
                index = _rndGenerator.Next(0, Piffs.Length);
            }

            return index;
        }
    }
}