using FoundationCore.ObjectHydrator.Generators;
using FoundationCore.ObjectHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FoundationCore.ObjectHydrator
{
    public class EnumMap : IMap
    {

        #region IMap Members

        Type IMap.Type
        {
            get { return typeof(object); }
        }

        bool IMap.Match(PropertyInfo info)
        {
            return info.PropertyType.IsEnum;
        }

        IMapping IMap.Mapping(PropertyInfo info)
        {
            return new Mapping<object>(info, new EnumGenerator(Enum.GetValues(info.PropertyType)));
        }

        #endregion
    }
}
