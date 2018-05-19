﻿using System;
using System.Net;
using System.Text.RegularExpressions;

namespace FakeNameGenerator
{
    #region Structs & Enums
    enum Gender
    {
        Male,
        Female, 
        Random
    }

    enum NameSet
    {
        American,
        Arabic,
        Australian,
        Brazil,
        Chechen,
        Chinese,
        Croatian,
        Czech,
        Danish,
        Dutch,
        England,
        Eritrean,
        Finnish,
        French,
        German,
        Greenland,
        Hispanic,
        Hobbit,
        Hungarian,
        Icelandic,
        Igbo,
        Italian,
        Japanese,
        Norwegian,
        Persian,
        Polish,
        Russian,
        Scottish,
        Slovenian,
        Swedish,
        Thai,
        Vietnamese
    }

    enum Country
    {
        Australia,
        Austria,
        Belgium,
        Brazil,
        Canada,
        Cyprus,
        Czech,
        Denmark,
        Estonia,
        Finland,
        France,
        Germany,
        Greenland,
        Hungary,
        Iceland,
        Italy,
        Netherlands,
        NewZealand,
        Norway,
        Poland,
        Portugal,
        Slovenia,
        SouthAfrica,
        Spain,
        Sweden,
        Switzerland,
        Tunisia,
        UnitedKingdom,
        UnitedStates
    }

    struct Identity
    {
        public int Age;
        public string Name;
        public string SSN;
        public string Phone;
        public string Email;
        public string Height;
        public string Weight;
        public string Vehicle;
        public string Company;
        public string Website;
        public string Address;
        public string Username;
        public string Password;
        public string CardType;
        public string Birthday;
        public string BloodType;
        public string UserAgent;
        public string Occupation;
        public string MaidenName;
        public string CardNumber;
        public string CountryCode;
        public string CardExpiration;
    }
    #endregion

    class AdvancedOptions
    {
        public short MinAge { get; set; } = 0;
        public short MaxAge { get; set; } = 100;
        public short MalePercentage { get; set; } = 50;
        public bool _enabled;

        public bool Enabled {
            get { return _enabled; }
        }
        public void Enable() { _enabled = true; }
        public void Disable() { _enabled = false; }
    }

    class FakeNameGeneratorAPI
    {
        public FakeNameGeneratorAPI() { }
        public AdvancedOptions AdvancedOptions = new AdvancedOptions();

        #region Enum Handling
        private string GetCountry(Country c)
        {
            switch (c)
            {
                case Country.Australia:
                    return "au";
                case Country.Austria:
                    return "as";
                case Country.Belgium:
                    return "bg";
                case Country.Brazil:
                    return "br";
                case Country.Canada:
                    return "ca";
                case Country.Cyprus:
                    return "cyen";
                case Country.Czech:
                    return "cz";
                case Country.Denmark:
                    return "dk";
                case Country.Estonia:
                    return "ee";
                case Country.Finland:
                    return "fi";
                case Country.France:
                    return "fr";
                case Country.Germany:
                    return "gr";
                case Country.Greenland:
                    return "gl";
                case Country.Hungary:
                    return "hu";
                case Country.Iceland:
                    return "is";
                case Country.Italy:
                    return "it";
                case Country.Netherlands:
                    return "nl";
                case Country.NewZealand:
                    return "nz";
                case Country.Norway:
                    return "no";
                case Country.Poland:
                    return "pl";
                case Country.Portugal:
                    return "pt";
                case Country.Slovenia:
                    return "sl";
                case Country.SouthAfrica:
                    return "za";
                case Country.Spain:
                    return "sp";
                case Country.Sweden:
                    return "sw";
                case Country.Switzerland:
                    return "sz";
                case Country.Tunisia:
                    return "tn";
                case Country.UnitedKingdom:
                    return "uk";
                case Country.UnitedStates:
                    return "us";
                default: return "us";
            }
        }

        private string GetNameSet(NameSet ns)
        {
            switch (ns)
            {
                case NameSet.American:
                    return "us";
                case NameSet.Arabic:
                    return "ar";
                case NameSet.Australian:
                    return "au";
                case NameSet.Brazil:
                    return "br";
                case NameSet.Chechen:
                    return "celat";
                case NameSet.Chinese:
                    return "ch";
                case NameSet.Croatian:
                    return "hr";
                case NameSet.Czech:
                    return "cs";
                case NameSet.Danish:
                    return "dk";
                case NameSet.Dutch:
                    return "nl";
                case NameSet.England:
                    return "en";
                case NameSet.Eritrean:
                    return "er";
                case NameSet.Finnish:
                    return "fi";
                case NameSet.French:
                    return "fr";
                case NameSet.German:
                    return "gr";
                case NameSet.Greenland:
                    return "gl";
                case NameSet.Hispanic:
                    return "sp";
                case NameSet.Hobbit:
                    return "hobbit";
                case NameSet.Hungarian:
                    return "hu";
                case NameSet.Icelandic:
                    return "is";
                case NameSet.Igbo:
                    return "ig";
                case NameSet.Italian:
                    return "it";
                case NameSet.Japanese:
                    return "jpja";
                case NameSet.Norwegian:
                    return "no";
                case NameSet.Persian:
                    return "fa";
                case NameSet.Polish:
                    return "pl";
                case NameSet.Russian:
                    return "ru";
                case NameSet.Scottish:
                    return "gd";
                case NameSet.Slovenian:
                    return "sl";
                case NameSet.Swedish:
                    return "sw";
                case NameSet.Thai:
                    return "th";
                case NameSet.Vietnamese:
                    return "vn";
                default: return "us";
            }
        }
        #endregion

        #region Create Identity
        /// <summary>
        /// Returns new Identity with default settings.
        /// </summary>
        /// <returns>Identity</returns>
        public Identity CreateIdentity()
        {
            return CreateIdentity(Gender.Random, NameSet.American, Country.UnitedStates);
        }

        /// <summary>
        /// Returns new Identity with gender settings.
        /// </summary>
        /// <param name="g">Male or Female</param>
        /// <returns>Identity</returns>
        public Identity CreateIdentity(Gender g)
        {
            return CreateIdentity(g, NameSet.American, Country.UnitedStates);
        }

        /// <summary>
        /// Returns new Identity with gender and nameset settings.
        /// </summary>
        /// <param name="g">Male or Female</param>
        /// <param name="ns">Country origin for name.</param>
        /// <returns>Identity</returns>
        public Identity CreateIdentity(Gender g, NameSet ns)
        {
            return CreateIdentity(g, ns, Country.UnitedStates);
        }

        /// <summary>
        /// Returns new Identity with gender, nameset, and country settings.
        /// </summary>
        /// <param name="g">Male or Female</param>
        /// <param name="ns">Country origin for name.</param>
        /// <param name="c">Country origin for Identity.</param>
        /// <returns>Identity</returns>
        public Identity CreateIdentity(Gender g, NameSet ns, Country c)
        {
            string url = (AdvancedOptions.Enabled)
                ? "https://www.fakenamegenerator.com/advanced.php?t=country&n[]=" + String.Format("{0}&c[]={1}&gen={2}&age-min={3}&age-max={4}", GetNameSet(ns), GetCountry(c), AdvancedOptions.MalePercentage, AdvancedOptions.MinAge, AdvancedOptions.MaxAge)
                : "http://www.fakenamegenerator.com" + String.Format("/gen-{0}-{1}-{2}.php", (g == Gender.Male) ? "male" : ((g == Gender.Female) ? "female" : "random"), GetNameSet(ns), GetCountry(c))
            ;

            return FetchIdentityData(url);
        }

        /// <summary>
        /// Returns new identity from multiple namesets and countries
        /// </summary>
        /// <param name="ns">NameSet[] array of namesets</param>
        /// <param name="c">Country[] array of countries</param>
        /// <returns>Identity</returns>
        public Identity CreateIdentity(NameSet[] ns, Country[] c)
        {
            //https://www.fakenamegenerator.com/advanced.php?t=country&n[]=nl&n[]=fr&c[]=cygk&gen=50&age-min=19&age-max=85
            string url = "https://www.fakenamegenerator.com/advanced.php?t=country";

            foreach (NameSet nameset in ns)
            {
                url += "&n[]=" + GetNameSet(nameset);
            }
            foreach (Country country in c)
            {
                url += "&c[]=" + GetCountry(country);
            }

            if (AdvancedOptions.Enabled)
            {
                url += String.Format("&gen={0}&age-min={1}&age-max={2}", AdvancedOptions.MalePercentage, AdvancedOptions.MinAge, AdvancedOptions.MaxAge);
            }
            
            return FetchIdentityData(url);
        }
        /// <summary>
        /// Returns an identity object of scraped data
        /// </summary>
        /// <param name="url">URL to fetch data from</param>
        /// <returns>Identity</returns>
        private Identity FetchIdentityData(string url)
        {
            Identity id = new Identity();
            try
            {
                using (WebClient wClient = new WebClient())
                {
                    string html_source = wClient.DownloadString(url);

                    Match m = Regex.Match(html_source, "<h3>(.*?)<");
                    id.Name = m.Groups[1].Value;

                    m = Regex.Match(html_source, "\"adr\">\n(.*?)<");
                    string street = m.Groups[1].Value.Trim();

                    m = Regex.Match(html_source, ".<br.>(.*?)<.div>");
                    id.Address = (street + " " + m.Groups[1].Captures[0].Value.Trim());
                    //Lazy bug fix
                    if (id.Address.Contains("</br>") || id.Address.Contains("<br>"))
                        id.Address = id.Address.Remove(id.Address.IndexOf('<'), 5);

                    m = Regex.Match(html_source, "<.dt>\\n\\s*<dd>(.*)<.");
                    id.MaidenName = m.Groups[1].Value;

                    m = Regex.Match(html_source, "SSN<.dt><dd>(.*?)<div class=");
                    id.SSN = (!string.IsNullOrEmpty(m.Groups[1].Value)) ? m.Groups[1].Value : "N/A";

                    m = Regex.Match(html_source, "Phone<.dt>\\n\\s*<dd>(.*?)<.dd>");
                    id.Phone = m.Groups[1].Value;

                    m = Regex.Match(html_source, "Country code<.dt>\\n\\s*<dd>(.*?)<.dd>");
                    id.CountryCode = m.Groups[1].Value;

                    m = Regex.Match(html_source, "Birthday<.dt>\\n\\s*<dd>(.*?)<.dd>");
                    id.Birthday = m.Groups[1].Value;
                    id.Age = (int)(DateTime.Now - Convert.ToDateTime(id.Birthday)).TotalDays / 365;

                    m = Regex.Match(html_source, @"Email Address<.dt>\n\n\s*<dd>(.*?)<div");
                    id.Email = m.Groups[1].Value.Trim();

                    m = Regex.Match(html_source, @"Username<.dt>\n\s*<dd>(.*?)<.dd>");
                    id.Username = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"Password<.dt>\n\s*<dd>(.*?)<.dd>");
                    id.Password = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"Website<.dt>\n\s*<dd>(.*?)<.dd>");
                    id.Website = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"Browser user agent<.dt>\n\s*<dd>(.*?)<.dd>");
                    id.UserAgent = m.Groups[1].Value;

                    m = Regex.Match(html_source, "Finance</h3>(.*?)</dl>", RegexOptions.Singleline);
                    Match m2 = Regex.Match(m.Groups[1].Value, "<dt>(.*?)<.dt>");
                    m = Regex.Match(m.Groups[1].Value, @"<.dt>\n\s*<dd>(.*?)<.dd>");
                    id.CardNumber = m.Groups[1].Value;
                    id.CardType = m2.Groups[1].Value;

                    m = Regex.Match(html_source, @"<dt>Expires<.dt>\n\s*<dd>(.*?)</dd>");
                    id.CardExpiration = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"<dt>Company<.dt>\n\s*<dd>(.*?)</dd>");
                    id.Company = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"<dt>Occupation<.dt>\n\s*<dd>(.*?)</dd>");
                    id.Occupation = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"<dt>Height<.dt>\n\s*<dd>(.*?)</dd>");
                    id.Height = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"<dt>Weight<.dt>\n\s*<dd>(.*?)</dd>");
                    id.Weight = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"<dt>Blood type<.dt>\n\s*<dd>(.*?)<.dd>");
                    id.BloodType = m.Groups[1].Value;

                    m = Regex.Match(html_source, @"<dt>Vehicle<.dt>\n\s*<dd>(.*?)<.dd>");
                    id.Vehicle = m.Groups[1].Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return id;
        }
        #endregion
    }
}
