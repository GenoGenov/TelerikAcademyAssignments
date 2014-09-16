namespace Mongo.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Media;
    using System.Windows.Shapes;

    using Mongo.Data;

    using Message = MongoChat.Model.Message;
    using TextBox = System.Windows.Controls.TextBox;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer getMessagesTimer;

        private DateTime lasMessagesUpdate;
        public MainWindow()
        {
            this.InitializeComponent();
            ChatSystemData.InitializeConnection();
            this.lasMessagesUpdate = DateTime.Now;
            this.InitTimer();
        }

        public void InitTimer()
        {
            this.getMessagesTimer = new Timer();
            this.getMessagesTimer.Tick += new EventHandler(this.timer_Tick);
            this.getMessagesTimer.Interval = 2000; // in miliseconds
            this.getMessagesTimer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            List<Message> messages;
            if (ChatSystemData.IsLoggedIn)
            {
                messages = ChatSystemData.GetMessagesSince(this.lasMessagesUpdate);
            }
            else
            {
                messages = ChatSystemData.GetMessagesSince(this.lasMessagesUpdate.Subtract(new TimeSpan(1, 0, 0, 0)));
                MessagesContainer.Inlines.Clear();
            }
            
            foreach (var message in messages)
            {
                MessagesContainer.Inlines.Add(message.User.Username+": "+message.Text+'\n');
            }
            
            this.lasMessagesUpdate = DateTime.Now;
            
           
        }

        public TextBox UsernameTextBox1
        {
            get
            {
                return this.UsernameTextBox;
            }
        }
        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!ChatSystemData.IsLoggedIn)
            {
                ChatSystemData.AssignCurrentUser(UsernameTextBox.Text);
                LoginButton.Content = "Send";
            }
            else
            {
                var text = SendMessageTextBox.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    ChatSystemData.SendMessage(SendMessageTextBox.Text);
                }
               
            }
            
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (ChatSystemData.IsLoggedIn)
            {
                ChatSystemData.DisposeConnection();
            }
            
        }
    }
}