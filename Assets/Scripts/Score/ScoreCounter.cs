using System;
using UnityEngine;

namespace Score
{
    public class ScoreCounter : MonoBehaviour
    {
        private int _score;
    
        public event Action<int> ScoreChanged;

        private void Awake()
        {
            Reset();
        }

        public void Increment()
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }

        public void Reset()
        {
            _score = 0;
            ScoreChanged?.Invoke(_score);
        }
    }
}