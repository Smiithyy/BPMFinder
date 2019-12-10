using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BPMFinder
{
    public partial class MainPage : ContentPage
    {
        private List<DateTime> tapTimes;

        public MainPage()
        {
            InitializeComponent();
            tapTimes = new List<DateTime>();
        }

        //Code for calculating bpm
        private void Button_Clicked(object sender, EventArgs e)
        {
            tapTimes.Add(DateTime.Now);
            if (tapTimes.Count > 2)
            {
                var oldest = tapTimes.First();
                var newest = tapTimes.Last();
                var duration = newest - oldest;
                var average = new TimeSpan(duration.Ticks / tapTimes.Count);
                double bpm = 60 / average.TotalSeconds;
                bpmLabel.Text = Math.Round(bpm).ToString();
            }
        }

        //Code for final display box
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            string songName = SongName.Text;
            string bpmValue = bpmLabel.Text;

            SongNameLabel.Text = songName + " has a BPM count of: " + bpmValue;
        }
    }
}
