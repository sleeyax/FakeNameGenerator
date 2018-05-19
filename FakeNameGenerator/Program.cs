﻿using System;

namespace FakeNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeNameGeneratorAPI FNGAPI = new FakeNameGeneratorAPI();
            FNGAPI.AdvancedOptions.Enable();
            FNGAPI.AdvancedOptions.MinAge = 18;

            Identity id = FNGAPI.CreateIdentity(new NameSet[] {NameSet.French, NameSet.American}, new Country[] {Country.Finland, Country.Brazil, Country.Estonia});
            //Identity id = FNGAPI.CreateIdentity(Gender.Male, NameSet.American, Country.Spain);

            Console.WriteLine("                 Name: {0}", id.Name);
            Console.WriteLine("              Address: {0}", id.Address);
            Console.WriteLine(" Mother's Maiden Name: {0}", id.MaidenName);
            Console.WriteLine("                  SSN: {0}", id.SSN);
            Console.WriteLine("                Phone: {0}-{1}", id.CountryCode, id.Phone);
            Console.WriteLine("             Birthday: {0}", id.Birthday);
            Console.WriteLine("                  Age: {0}", id.Age);
            Console.WriteLine("                Email: {0}", id.Email);
            Console.WriteLine("             Username: {0}", id.Username);
            Console.WriteLine("             Password: {0}", id.Password);
            Console.WriteLine("              Website: {0}", id.Website);
            Console.WriteLine("   Browser User Agent: {0}", id.UserAgent);
            Console.WriteLine("     Credit Card Type: {0}", id.CardType);
            Console.WriteLine("   Credit Card Number: {0}", id.CardNumber);
            Console.WriteLine("      Card Expiration: {0}", id.CardExpiration);
            Console.WriteLine("              Company: {0}", id.Company);
            Console.WriteLine("           Occupation: {0}", id.Occupation);
            Console.WriteLine("               Height: {0}", id.Height);
            Console.WriteLine("               Weight: {0}", id.Weight);
            Console.WriteLine("           Blood Type: {0}", id.BloodType);

            Console.ReadLine();
        }
    }
}
