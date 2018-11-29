using System;
using System.Collections.Generic;
using System.Text;

namespace FoundationCore.ObjectHydrator.Interfaces
{
    public interface IGenerator
    {
        object Generate();
    }

    public interface IGenerator<T>
    {
        T Generate();
    }
}
