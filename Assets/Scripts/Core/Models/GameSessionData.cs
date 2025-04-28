using System;

namespace Core.Models
{
    public class GameSessionData
    {
        public event Action OnDataChanged;
        
        private int _linesCompleted;
        private int _gameLevel;

        public int LinesCompleted
        {
            get => _linesCompleted;
            set
            {
                _linesCompleted = value;
                OnDataChanged?.Invoke();
            }
        }

        public int GameLevel
        {
            get => _gameLevel;
            set
            {
                _gameLevel = value;
                OnDataChanged?.Invoke();
            }
        }

        public void ResetValues()
        {
            LinesCompleted = 0;
            GameLevel = 0;
        }
    }
}