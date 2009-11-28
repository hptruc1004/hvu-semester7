using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClock
{
    public class AlarmEvent
    {
        Timer m_timerCountdown;
        public delegate object Handler(object parameter);
        object m_eventParam;

        public enum AlarmState
        {
            RUNNING,
            STOPPED
        }

        /// <summary>
        /// Countdown, seconds
        /// </summary>
        public int Countdown { get; set; }
        public object Result { get; set; }
        public Handler AlarmHandler { get; set; }
        public AlarmState State { get; set; }

        public AlarmEvent(int countdown, Handler handler, object para)
        {
            this.Countdown = countdown;
            this.AlarmHandler = handler;
            this.m_eventParam = para;

            m_timerCountdown = new Timer();
            m_timerCountdown.Interval = this.Countdown * 1000;
            m_timerCountdown.Tick += new EventHandler(m_timerCountdown_Tick);

            State = AlarmState.STOPPED;
        }

        void m_timerCountdown_Tick(object sender, EventArgs e)
        {
            try
            {
                m_timerCountdown.Stop();
                if (AlarmHandler != null)
                {
                    this.Result = AlarmHandler(m_eventParam);
                }
                State = AlarmState.STOPPED;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void On()
        {
            m_timerCountdown.Start();
            State = AlarmState.RUNNING;
        }

        public void Off()
        {
            m_timerCountdown.Stop();
            State = AlarmState.STOPPED;
        }
    }
}
