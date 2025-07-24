using System;
using UnityEngine;

namespace TimePicker
{
#if UNITY_ANDROID
    public class AndroidTimePicker : ITimePicker
    {
        private Action<TimeSpan> _timeSelectedCallback;
        private TimeSpan _initTime;

        public void Show(TimeSpan initTime, Action<TimeSpan> callback)
        {
            _initTime = initTime;
            _timeSelectedCallback = callback;

            var unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var activity = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");

            activity.Call("runOnUiThread",
                new AndroidJavaRunnable(() =>
                {
                    new AndroidJavaObject("android.app.TimePickerDialog",
                        activity,
                        new TimeCallback(this),
                        _initTime.Hours,
                        _initTime.Minutes,
                        true // is24HourView
                    ).Call("show");
                }));
        }

        private void TimeSelectedHandler(TimeSpan time)
        {
            _timeSelectedCallback?.Invoke(time);
        }

        class TimeCallback : AndroidJavaProxy
        {
            private AndroidTimePicker mDialog;

            public TimeCallback(AndroidTimePicker d) : base("android.app.TimePickerDialog$OnTimeSetListener")
            {
                mDialog = d;
            }

            private void onTimeSet(AndroidJavaObject view, int hourOfDay, int minute)
            {
                var selectedTime = new TimeSpan(hourOfDay, minute, 0);
                mDialog.TimeSelectedHandler(selectedTime);
            }
        }
    }
#endif
}
