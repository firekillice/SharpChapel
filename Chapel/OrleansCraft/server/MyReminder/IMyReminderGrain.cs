using Orleans.Runtime;

namespace Silos.MyReminder
{
    public interface IMyReminderGrain : IGrainWithStringKey
    {
        Task ReceiveReminder(string reminderName, TickStatus status);
        Task RegisterReminderAsync();
        Task UnregisterReminderAsync();
    }
}