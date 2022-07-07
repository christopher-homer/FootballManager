namespace FootballManager.Core.Utilities.Generation
{
    public class WeightedValue<T>
    {
        public WeightedValue(T v, int w)
        {
            Value = v;
            Weight = w;
        }

        internal T Value { get; private set; }
        internal int Weight { get; private set; }
    }
}
