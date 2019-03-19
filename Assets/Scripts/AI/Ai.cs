using System.Collections;
using UnityEngine;

namespace AI
{
    public class Ai : MonoBehaviour
    {
        private IStrategy _strategy;
        private Move _move;
        private Shooting _shooting;

        public void Awake()
        {
            _strategy = GetComponent<IStrategy>();
            _move = GetComponent<Move>();
            _shooting = GetComponent<Shooting>();
        }

        public void Start()
        {
            if (_strategy != null)
                StartCoroutine(_strategy.Run(_move, _shooting));
        }
    }
}