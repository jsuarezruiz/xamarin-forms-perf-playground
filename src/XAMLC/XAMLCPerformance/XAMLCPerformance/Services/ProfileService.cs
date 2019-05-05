using System.Collections.Generic;
using Xamarin.Forms;
using XAMLCPerformance.Models;

namespace XAMLCPerformance.Services
{
    public class ProfileService
    {
        private static ProfileService _instance;

        public static ProfileService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProfileService();

                return _instance;
            }
        }

        public Profile GetProfile()
        {
            return new Profile
            {
                Banner = "sevilla01",
                Picture = "javier",
                Name = "Javier Suárez Ruiz",
                Location = "Sevilla",
                About = "Community helper, speaker, geek, former Microsoft MVP. Senior Software Engineer at Microsoft.",
                Friends = new List<Friend>
                 {
                     new Friend { Name = "Miguel de Icaza", Picture = "miguel" },
                     new Friend { Name = "David Ortinau", Picture = "david" },
                     new Friend { Name = "Rui Marinho", Picture = "rui" },
                     new Friend { Name = "Matthew Leibowitz", Picture = "matthew" }
                 }
            };
        }
    }
}