using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    [RequireComponent(typeof(Text))]
    [RequireComponent(typeof(ChangeText))]
    public class PlayerAddScore : MonoBehaviour
    {
        public Text Text => _text;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        [SerializeField] private CameraSwitch _camera;

        private Text _text;
        private int _score;
        private ChangeText _changeText;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _changeText = GetComponent<ChangeText>();
        }

        private void Update() => AddingMoney(KeyCode.Space);

        private void AddingMoney(KeyCode space)
        {
            _text.text = _score.ToString();

            if (_camera.MainCamera.depth == 1)
            {
                if (Input.GetKeyDown(space))
                {
                    _score++;
                    _changeText.ChangeTextColor(10, Color.blue);
                }
            }

            else if(Input.GetKey(space))
                _score--;
        }
    }
}