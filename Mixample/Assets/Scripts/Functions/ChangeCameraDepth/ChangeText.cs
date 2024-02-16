using UnityEngine;

namespace Test
{
    [RequireComponent(typeof(PlayerAddScore))]
    public class ChangeText : MonoBehaviour
    { 
        private Color _currentTextColor;
        private PlayerAddScore _playerAddScore;

        private void Start()
        {
            _playerAddScore = GetComponent<PlayerAddScore>();
            _currentTextColor = _playerAddScore.Text.color;
        }

        public void ChangeTextColor(int value, Color color)
        {
            if (_playerAddScore.Score >= value)
                _playerAddScore.Text.color = color;

            else
                _playerAddScore.Text.color = _currentTextColor;
        }
    }
}