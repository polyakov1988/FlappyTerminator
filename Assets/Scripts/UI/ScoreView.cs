using Score;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMeshPro;
        [SerializeField] private ScoreCounter _scoreCounter;

        private void OnEnable()
        {
            _scoreCounter.ScoreChanged += RenderScoreCounter;
        }

        private void RenderScoreCounter(int score)
        {
            _textMeshPro.text = score.ToString();
        }

        private void OnDisable()
        {
            _scoreCounter.ScoreChanged -= RenderScoreCounter;
        }
    }
}
