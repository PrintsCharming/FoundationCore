using System.Collections.Generic;
using FoundationCore.ObjectHydrator.Interfaces;


namespace FoundationCore.ObjectHydrator.Generators
{
    public class CreditCardTypeGenerator:IGenerator<string>
    {
 
        public string Generate()
        {
            return
                new FromListGetSingleGenerator<string>(new List<string>
                                                  {
                                                      "MasterCard",
                                                      "Visa",
                                                      "Discover",
                                                      "American Express"
                                                  })
                    .Generate();
        }
    }
}
