namespace BetisWebAPIPortalApis.Model
{
    public class Name
    {
        public static int counter = 0;
        public Name()
        {
            Interlocked.Increment(ref counter);
        }


    }
}
