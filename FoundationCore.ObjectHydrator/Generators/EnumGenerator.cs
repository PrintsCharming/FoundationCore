﻿using System;
using FoundationCore.ObjectHydrator.Interfaces;

namespace FoundationCore.ObjectHydrator.Generators
{
    public class EnumGenerator:IGenerator<object>
    {
        Random random;
        Array EnumValues;

        public EnumGenerator(Array enumValues)
        {
            EnumValues = enumValues;
            random = RandomSingleton.Instance.Random;

        }

        public object Generate()
        {
            return EnumValues.GetValue(random.Next(0, EnumValues.Length - 1));
        }
    }
}
