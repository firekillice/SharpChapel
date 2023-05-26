using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orleans.Runtime;
using System.Threading.Tasks;

namespace Silos.MyReminder
{
    public class MyReminderGrain : Grain, IMyReminderGrain, IRemindable
    {
        private static readonly string ReminderName = "MyFirstReminder";

        public async Task RegisterReminderAsync()
        {
            await this.RegisterOrUpdateReminder(ReminderName, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(60));
        }

        public async Task UnregisterReminderAsync()
        {
            await this.UnregisterReminder(await this.GetReminder(ReminderName));
        }

        public Task ReceiveReminder(string reminderName, TickStatus status)
        {
            Console.WriteLine($"Reminder {reminderName} callback executed.");
            return Task.CompletedTask;
        }
    }
}
