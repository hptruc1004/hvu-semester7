using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClock
{
    public partial class DClock : UserControl
    {
        // Time 
        int m_iTime = 0;
        ClockState m_sState;
        AlarmEvent m_AlarmEvent;

        public enum ClockState
        {
            RUNNING,
            STOPPED,
            PAUSED
        }

        #region Clock
        public DClock()
        {
            InitializeComponent();

            m_iTime = 0;
            m_sState = ClockState.STOPPED;

            m_AlarmEvent = null;
        }

        public void SetTime(int min, int second)
        {
            m_iTime = min * 60 + second;
        }

        public void Start()
        {
            if (m_sState == ClockState.STOPPED || m_sState == ClockState.PAUSED)
            {
                timerUpdate.Start();
                m_sState = ClockState.RUNNING;
            }
        }

        public void Stop()
        {
            if (m_sState == ClockState.RUNNING)
            {
                m_iTime = 0;
                timerUpdate.Stop();
                m_sState = ClockState.STOPPED;

                UpdateDisplay();
            }
        }

        public void Pause()
        {
            if (m_sState == ClockState.RUNNING)
            {
                timerUpdate.Stop();
                m_sState = ClockState.PAUSED;
            }
        }

        public void Resume()
        {
            if (m_sState == ClockState.PAUSED)
            {
                timerUpdate.Start();
                m_sState = ClockState.RUNNING;
            }
        }

        public ClockState CurrentState
        {
            get
            {
                return m_sState;
            }
        }

        public ImageList ListDigitImages { get; set; }

        public Image DashImage { get; set; }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            // Inscrease time
            m_iTime++;

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            // Calculate time
            int min = m_iTime / 60;
            int sec = m_iTime % 60;

            // Update img
            int min1 = min / 10;
            int min2 = min % 10;
            int sec1 = sec / 10;
            int sec2 = sec % 10;

            ptbMin1.Image = ListDigitImages.Images[min1];
            ptbMin2.Image = ListDigitImages.Images[min2];
            ptbSec1.Image = ListDigitImages.Images[sec1];
            ptbSec2.Image = ListDigitImages.Images[sec2];

            // Dash
            if ((sec2 % 2) == 0)
            {
                ptbDash.Image = DashImage;
            }
            else
            {
                ptbDash.Image = null;
            }
        }
        #endregion

        #region Alarm
        public void SetAlarm(int countdown, AlarmEvent.Handler handler, object eventPara)
        {
            m_AlarmEvent = new AlarmEvent(countdown, handler, eventPara);
        }

        public void AlarmOn()
        {
            m_AlarmEvent.On();
            AlarmState = AlarmEvent.AlarmState.RUNNING;
        }

        public void AlarmOff()
        {
            m_AlarmEvent.Off();
            AlarmState = AlarmEvent.AlarmState.RUNNING;
        }

        public AlarmEvent.AlarmState AlarmState
        {
            get
            {
                return m_AlarmEvent.State;
            }
            set
            {
                m_AlarmEvent.State = value;
            }
        }
        #endregion
    }     
}
