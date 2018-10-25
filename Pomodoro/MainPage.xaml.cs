using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pomodoro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        TextBlock min_block, second_block, sprint_block, info_block;
        int sprint_number;
        int orig_mins;
        int orig_seconds;
        int curr_mins;
        int curr_seconds;
        int norm_break = 5;
        int large_break = 30;
        int sprint_milestone = 4;
        bool isRunning;
        private void Pause_session(object sender, RoutedEventArgs e)
        {
            if (isRunning == true)
            {
                ElementSoundPlayer.State = ElementSoundPlayerState.On;
                ElementSoundPlayer.Play(ElementSoundKind.Invoke);
                isRunning = false;
                info_block.Text = "TAKE YOUR TIME";
            }
        }

        private async void Reset_session(object sender, RoutedEventArgs e)
        {
            if (isRunning == true)
            {
                isRunning = false;
                await Task.Delay(1000);

            }
            ElementSoundPlayer.State = ElementSoundPlayerState.On;
            ElementSoundPlayer.Play(ElementSoundKind.Invoke);
            sprint_number = 0;
            orig_mins = 25;
            orig_seconds = 60;
            curr_mins = orig_mins;
            curr_seconds = orig_seconds;
            isRunning = false;
            min_block.Text = Convert.ToString(orig_mins)+" MINS";
            second_block.Text = Convert.ToString(orig_seconds)+" SECS";
            sprint_block.Text = Convert.ToString(sprint_number)+ " SPRINTS";
            info_block.Text = "START YOUR SESSION";
        }

 
        public MainPage()
        {
            this.InitializeComponent();
            min_block = (TextBlock)this.FindName("min");
            second_block = (TextBlock)this.FindName("second");
            sprint_block = (TextBlock)this.FindName("sprint");
            info_block = (TextBlock)this.FindName("info");
            sprint_number = 0;
            orig_mins = 25;
            orig_seconds = 60;
            curr_mins = orig_mins;
            curr_seconds = orig_seconds;
            isRunning = false;
        }


        private async void Start_session(object sender, RoutedEventArgs e)
        {
            ElementSoundPlayer.State = ElementSoundPlayerState.On;
            ElementSoundPlayer.Play(ElementSoundKind.Invoke);
            min_block.Text = Convert.ToString(curr_mins) + " MINS";
            second_block.Text = Convert.ToString(curr_seconds) + " SECS";
            sprint_block.Text = Convert.ToString(sprint_number) + " SPRINTS";
            info_block.Text = "START HUSTLING!!";
            isRunning = true;

            while (isRunning == true)
            {
                while (isRunning == true && curr_mins > 0)
                {
                    second_block.Text = Convert.ToString(curr_seconds) + " SECS";
                    while (isRunning == true && curr_seconds > 0)
                    {
                        await Task.Delay(1000);
                        curr_seconds--;
                        second_block.Text = Convert.ToString(curr_seconds) + " SECS";
                    }
                    if (isRunning == false)
                        break;
                    curr_seconds = orig_seconds;
                    curr_mins--;
                    min_block.Text = Convert.ToString(curr_mins) + " MINS";
                }
                if (isRunning == false)
                    break;
                sprint_number++;
                sprint_block.Text = Convert.ToString(sprint_number) + " SPRINTS";
                curr_seconds = orig_seconds;
                if (sprint_number == sprint_milestone)
                    curr_mins = large_break;
                else
                    curr_mins = norm_break;
                min_block.Text = Convert.ToString(curr_mins) + " MINS";
                second_block.Text = Convert.ToString(curr_seconds) + " SECS";
                info_block.Text = "TIME FOR A BREAK :)";
                for(int i=0;i<5;i++)
                {
                    ElementSoundPlayer.State = ElementSoundPlayerState.On;
                    ElementSoundPlayer.Play(ElementSoundKind.Invoke);
                }
                while (isRunning == true && curr_mins > 0)
                {
                    second_block.Text = Convert.ToString(curr_seconds) + " SECS";
                    while (isRunning == true && curr_seconds > 0)
                    {
                        await Task.Delay(1000);
                        curr_seconds--;
                        second_block.Text = Convert.ToString(curr_seconds) + " SECS";
                    }
                    if (isRunning == false)
                        break;
                    curr_seconds = orig_seconds;
                    curr_mins--;
                    min_block.Text = Convert.ToString(curr_mins) + " MINS";
                }
                if (isRunning == false)
                    break;
                curr_seconds = orig_seconds;
                curr_mins = orig_mins;
                for (int i = 0; i < 5; i++)
                {
                    ElementSoundPlayer.State = ElementSoundPlayerState.On;
                    ElementSoundPlayer.Play(ElementSoundKind.Invoke);
                }
            }
        }
    }
}
