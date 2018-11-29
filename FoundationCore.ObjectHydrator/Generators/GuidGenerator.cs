using System;
using FoundationCore.ObjectHydrator.Interfaces;

namespace FoundationCore.ObjectHydrator.Generators
{
    public class GuidGenerator : IGenerator<Guid>
    {
        #region IGenerator Members

        public Guid Generate()
        {
            return Guid.NewGuid();
        }

        #endregion
    }
}
