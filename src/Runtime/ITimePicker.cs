using System;

namespace TimePicker
{
    /// <summary>
    /// Interface for displaying a native time picker dialog.
    /// </summary>
    public interface ITimePicker
    {
        /// <summary>
        /// Displays the time picker dialog with an initial time and invokes a callback with the selected time.
        /// </summary>
        /// <param name="initTime">The initial time to display in the time picker dialog.</param>
        /// <param name="callback">
        /// A callback function that is invoked when the user selects a time.
        /// The selected time is passed as a <see cref="TimeSpan"/>.
        /// </param>
        void Show(TimeSpan initTime, Action<TimeSpan> callback);
    }
}
