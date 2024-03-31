using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMeshPro;
        [SerializeField] private Score.Score _score;

        private void OnEnable()
        {
            _score.OnScoreChanged += RenderScore;
        }

        private void RenderScore(int score)
        {
            _textMeshPro.text = score.ToString();
        }

        private void OnDisable()
        {
            _score.OnScoreChanged -= RenderScore;
        }
    }
}
