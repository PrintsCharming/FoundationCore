using FoundationCore.ObjectHydrator.Generators;
using FoundationCore.ObjectHydrator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FoundationCore.ObjectHydrator
{
    public class Hydrator<T>:IGenerator<T>
    {
        readonly Type typeOfT = null;
        readonly IDictionary<string, IMapping> propertyMap;
        private List<Action<T>> actions;
        private readonly IList<IMap> typeMap;
        private IList<IMap> defaultTypeMap;


        public T Generate()
        {
            var instance = (T)Activator.CreateInstance(typeOfT);
            Populate(instance);
            return instance;
        }

        private void Populate(T instance)
        {
            AddTypeMapToPropertyMap();
            foreach (IMapping mapping in propertyMap.Values)
            {
                PropertyInfo propertyInfo = instance.GetType().GetProperty(mapping.PropertyName, BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(instance, mapping.Generate(), null);
                }
            }

            if (actions != null)
            {
                foreach (var action in this.actions)
                {
                    action(instance);
                }
            }
        }

        private void AddTypeMapToPropertyMap()
        {
            AddDefaultTypeMapToTypeMap();

            foreach (PropertyInfo propertyInfo in typeOfT.GetProperties())
            {
                if (propertyInfo.CanWrite && !propertyMap.ContainsKey(propertyInfo.Name))
                {
                    PropertyInfo info = propertyInfo;
                    var map = typeMap.FirstOrDefault(infer => infer.Type == info.PropertyType && infer.Match(info));

                    if (map != null)
                    {
                        propertyMap[propertyInfo.Name] = map.Mapping(propertyInfo);
                    }
                    else if (!propertyInfo.PropertyType.IsInterface)
                    {
                        propertyMap[propertyInfo.Name] = new Mapping(propertyInfo, new Generator(propertyInfo));
                    }
                }
            }
        }
        private void AddDefaultTypeMapToTypeMap()
        {
            foreach (var map in defaultTypeMap)
            {
                typeMap.Add(map);
            }
        }
    }
}
