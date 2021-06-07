using System;
using System.Windows.Forms;

namespace MCItemChecker.GUI.Controls
{
    public class DelayedTextBox : TextBox
    {
        private Timer m_timer;

        public event EventHandler DelayedTextChanged;
        public int Delay
        {
            get => m_timer.Interval;
            set => m_timer.Interval = value;
        }

        public DelayedTextBox()
            : base()
        {
            m_timer = new Timer();
            m_timer.Tick += HandleTimerTimeout;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            m_timer.Stop();
            base.OnTextChanged(e);
            m_timer.Start();
        }

        private void HandleTimerTimeout(object sender, EventArgs e)
        {
            DelayedTextChanged?.Invoke(sender, e);

            m_timer.Stop();
        }
    }
}
