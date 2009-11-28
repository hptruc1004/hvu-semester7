using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalClock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            AlarmEvent.Handler handler = new AlarmEvent.Handler(ShowMessage);
            dClock.SetAlarm(3, handler, "Alibaba");
            UpdateButtons();
        }

        private object ShowMessage(object message)
        {
            MessageBox.Show(message.ToString(), "Alarm");
            return true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            dClock.SetTime(0, 0);
            dClock.Start();
            UpdateButtons();
        }

        bool isPaused = false;
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                dClock.Resume();
                isPaused = false;
                btnPause.Text = "Pause";
            }
            else
            {
                dClock.Pause();
                isPaused = true;
                btnPause.Text = "Resume";
            }
            UpdateButtons();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            dClock.Stop();
            UpdateButtons();
        }

        private void btnAlarmOff_Click(object sender, EventArgs e)
        {
            if (dClock.AlarmState == AlarmEvent.AlarmState.STOPPED)
            {
                MessageBox.Show("Alarm is already off.", "Info");
                return;
            }
            dClock.AlarmOff();
            UpdateButtons();
        }

        private void btnAlarmOn_Click(object sender, EventArgs e)
        {
            if (dClock.AlarmState == AlarmEvent.AlarmState.RUNNING)
            {
                MessageBox.Show("Alarm is already on.", "Info");
                return;
            }
            dClock.AlarmOn();
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (dClock.CurrentState == DClock.ClockState.RUNNING)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnPause.Enabled = true;
            }
            else if (dClock.CurrentState == DClock.ClockState.PAUSED)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnPause.Enabled = true;
            }
            else if (dClock.CurrentState == DClock.ClockState.STOPPED)
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnPause.Enabled = false;
            }

            /*
            if (dClock.AlarmState == AlarmEvent.AlarmState.STOPPED)
            {
                btnAlarmOff.Enabled = false;
                btnAlarmOn.Enabled = true;
            }
            else if (dClock.AlarmState == AlarmEvent.AlarmState.RUNNING)
            {
                btnAlarmOff.Enabled = true;
                btnAlarmOn.Enabled = false;
            }
            */
        }
    }
}
