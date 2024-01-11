namespace BlazorShop.Models
{
    public class TimeUTC : ITime
    {
        public DateTime GetTime()
        {
            return DateTime.UtcNow;
        }

        public override string ToString()
        {
            return DateTime.UtcNow.ToString("dd MMMM yyyyг., HH:mm:ss");
		}

    }
}
