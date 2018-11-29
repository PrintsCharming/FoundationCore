using FoundationCore.ObjectHydrator.Interfaces;

namespace FoundationCore.ObjectHydrator.Generators
{
    public class NullGenerator:IGenerator<object>
    {
        public object Generate()
        {
            return null;
        }
    }
}
