using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;

namespace DelayOFF_Program
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Top_panel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == Close_btn)
            {
                this.Close();
            }
            if (e.OriginalSource == Minimized_btn)
            {
                this.WindowState = WindowState.Minimized;
            }         
        }

        private void Confirm_delayBtn_Click(object sender, RoutedEventArgs e)
        {
            string cmd;
            int time;

            try
            {
                if (hourBox.Text == String.Empty)
                {
                    hourBox.Text = "0";
                }
                if (minuteBox.Text == String.Empty)
                {
                    minuteBox.Text = "0";
                }
                if (secondBox.Text == String.Empty)
                {
                    secondBox.Text = "0";
                }
                
                time = (Convert.ToInt32(hourBox.Text) * 3600) + (Convert.ToInt32(minuteBox.Text) * 60) + (Convert.ToInt32(secondBox.Text));

                cmd = $"shutdown -s -t {time}";

                var exec_command = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = "/c " + cmd,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(exec_command);

                hourBox.Text = "";
                minuteBox.Text = "";
                secondBox.Text = "";
            }
            catch
            {           
                hourBox.Text = "";
                minuteBox.Text = "";
                secondBox.Text = "";
            }
            
        }

        private void Cancel_delayBtn_Click(object sender, RoutedEventArgs e)
        {
            string cmd;
            cmd = "shutdown -a";

            var exec_command = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(exec_command);
        }
    }
}
