using FoundationCore.ObjectHydrator.Interfaces;

namespace FoundationCore.ObjectHydrator.Generators
{
    public class TypeGenerator<T>:IGenerator<T>
    {
        public T Generate()
        {
            return new Hydrator<T>().GetSingle();
        }
    }
}
