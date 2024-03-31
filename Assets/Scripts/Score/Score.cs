using System;
using UnityEngine;

namespace Score
{
    public class Score : MonoBehaviour
    {
        private int _score;
    
        public event Action<int> OnScoreChanged;

        private void Awake()
        {
            Reset();
        }

        public void Increment()
        {
            _score++;
            OnScoreChanged?.Invoke(_score);
        }

        public void Reset()
        {
            _score = 0;
            OnScoreChanged?.Invoke(_score);
        }
    }
}