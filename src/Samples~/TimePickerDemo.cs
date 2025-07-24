using System;
using UnityEngine;
using UnityEngine.UI;

namespace TimePicker.Samples
{
    public class TimePickerrDemo : MonoBehaviour
    {
        // Recommended to use TextMeshPro instead
        [SerializeField] private Text _text;
        [SerializeField] private Button _button;

        private ITimePicker _timePicker;

        private void Start()
        {
            _button.onClick.AddListener(OnTimeButtonClicked);

#if UNITY_EDITOR
            _timePicker = new UnityEditorTimePicker();
#elif UNITY_ANDROID
            _timePicker = new AndroidTimePicker();
#endif
        }

        private void OnTimeButtonClicked()
        {
            _timePicker?.Show(DateTime.Now.TimeOfDay, OnTimeSelected);
        }

        private void OnTimeSelected(TimeSpan value)
        {
            var formattedTime = value.ToString(@"hh\:mm");

            _text.text = formattedTime;

            Debug.Log($"Time selected: {formattedTime}");
        }
    }

#if UNITY_EDITOR
    class UnityEditorTimePicker : ITimePicker
    {
        public void Show(TimeSpan initTime, Action<TimeSpan> callback)
        {
            callback?.Invoke(initTime);
        }
    }
#endif
}