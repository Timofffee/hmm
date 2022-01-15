using Game.hmm.Unit;
using UnityEngine;
using TMPro;

namespace Game.hmm.UI
{
    public class UpdateUnitCount : MonoBehaviour
    {
        [SerializeField] private UnitComponent _unitComponent;

        private TMP_Text _text;

        private void Awake() {
            _text = GetComponent<TMP_Text>();
        }
        public void UpdateCount()
        {
            _text.text = _unitComponent.Count.ToString();
        }
    }
}