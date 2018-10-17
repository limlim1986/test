using System;
using System.Collections.Generic;

namespace Test
{
    class AlertingSystem
    {
        static void Main(string[] args)
        {
            alertservice a = new alertservice();
            var id1= a.RaiseAlert();
            Guid id2 = a.RaiseAlert();
            DateTime at = a.GetAlertTime(id2);

            Console.WriteLine("Alert with id " + id2 + " was raised " + at);
            Console.ReadLine();
        }
    }

    public class alertservice
    {
        private readonly AlertRepository repository = new AlertRepository();

        public Guid RaiseAlert()
        {
            return repository.AddAlert(DateTime.Now);
        }

        public DateTime GetAlertTime(Guid id)
        {
            return repository.GetAlert(id);
        }
    }

    public class AlertRepository
    {
        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            alerts.Add(id, time);
            return id;
        }

        public DateTime GetAlert(Guid id)
        {
            return this.alerts[id];
        }
    }
}
