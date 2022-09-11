using System;
using System.Collections;

public class Service
{
    //Key
    public int ID_Service { get; set; }
    //FK
    public int ID_Mantenimiento { get; set; }
    public string Service_Type { get; set; }
    public DateTime FechaPromesa { get; set; }

    // The WorkShop where the services were done
    public WorkShop WorkShop;

    public Service()
    {

    }

    public bool Notifications ()
    {
        // The notifications of the app
        return false;
    }

    // A Notification to email from: https://stackoverflow.com/questions/40229511/email-notification-system-in-c-sharp
    // Another one here: https://www.c-sharpcorner.com/article/sending-email-using-c-sharp/
    /*
    public class EmailExchange : IDisposable
    {
        public string Password { get; set; }
        public string EmailID { get; set; }
        public string Domain { get; set; }            
        public string ExchangeURL
        {
            get { return "https://outlook.office365.com/EWS/Exchange.asmx"; }
        }        
        private StreamingSubscriptionConnection connection = null;
        private ExchangeService service = null;
        public void Watch()
        {
            service = new ExchangeService();
            service.Credentials = new WebCredentials(EmailID, Password, Domain);            
            service.Url = new Uri(ExchangeURL);
            StreamingSubscription streamingsubscription = service.SubscribeToStreamingNotifications(new FolderId[] { WellKnownFolderName.Inbox }, EventType.NewMail);            
            connection = new StreamingSubscriptionConnection(service, 5);
            connection.AddSubscription(streamingsubscription);
            connection.OnNotificationEvent += OnNotificationEvent;
            connection.OnSubscriptionError += OnSubscriptionError;
            connection.OnDisconnect += OnDisconnect;
            connection.Open();
        }

        private void OnDisconnect(object sender, SubscriptionErrorEventArgs args)
        {
            Console.WriteLine("Disconnected");
            if (!connection.IsOpen)
                connection.Open();
        }

        private void OnSubscriptionError(object sender, SubscriptionErrorEventArgs args)
        {

        }

        private void OnNotificationEvent(object sender, NotificationEventArgs args)
        {
            foreach (var notification in args.Events)
            {
                if (notification.EventType != EventType.NewMail) continue;

                var itemEvent = (ItemEvent)notification;               
                // add you code here
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    */
}