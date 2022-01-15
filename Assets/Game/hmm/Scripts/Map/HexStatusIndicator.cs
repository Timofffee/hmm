using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.hmm.Map
{
    public class HexStatusIndicator : MonoBehaviour
    {
        [Header("Status Materials")]
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _focusedColor;
        [SerializeField] private Color _avalibaleColor;

        [Header("Dependencies")]
        [SerializeField] private HexComponent _hexComponent;

        private Material _material;


        private void Awake() {
            _material = GetComponent<MeshRenderer>().material;
            _hexComponent.onStatusChanged += UpdateVisual;
        }

        private void OnDestroy() {
            _hexComponent.onStatusChanged -= UpdateVisual;
        }

        private void UpdateVisual()
        {
            if (_hexComponent.IsAvaliable)
            {
                if (_hexComponent.IsFocused)
                {
                    _material.color = _focusedColor;
                }
                else
                {
                    _material.color = _avalibaleColor;
                }
            }
            else
            {
                _material.color = _defaultColor;
            }
        }
    }
}