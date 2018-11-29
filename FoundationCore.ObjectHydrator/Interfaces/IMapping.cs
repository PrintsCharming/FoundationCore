using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FoundationCore.ObjectHydrator.Interfaces
{
    public interface IMapping
    {
        string PropertyName { get; }
        PropertyInfo PropertyInfo { get; }
        object Generate();
    }
}
