using UnityEngine;
using Game.hmm.Unit;
using System;

namespace Game.hmm.Map
{
    // REMARK
    // В данном проекте была использована старая инпут система,
    // так как по непонятным причинам Unity наглухо отказывалась 
    // от работы с новой Input System...
    // чтож.. немного боли для ваших глаз в лице UnityEngine.Input API

    public class HexComponent : MonoBehaviour
    {
        [Header("Data")]
        public Vector2Int cellPos;

        public UnitComponent unitOnHex;

        private bool _isAvaliable;
        public bool IsAvaliable
        {
            get => _isAvaliable;
            set
            {
                if (_isAvaliable != value)
                {
                    _isAvaliable = value;

                    onStatusChanged?.Invoke();
                }
            }
        }

        private bool _isFocused;
        public bool IsFocused
        {
            get => _isFocused;
            set
            {
                if (_isFocused != value)
                {
                    _isFocused = value;

                    onStatusChanged?.Invoke();
                }
            }
        }

        public Action onStatusChanged;

        private void OnMouseEnter()
        {
            IsFocused = IsAvaliable;
        }

        private void OnMouseExit()
        {
            IsFocused = false;
        }
    }
}