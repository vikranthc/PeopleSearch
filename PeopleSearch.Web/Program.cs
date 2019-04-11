using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Data;
using PeopleSearch.Data.Domain;

namespace PeopleSearch.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {

            SeedDatabase();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void SeedDatabase()
        {
            var firstNames = new[]
            {
                "Vikranth",
                "John",
                "Jack",
                "Alan",
                "Mike",
                "Chris",
                "Paul",
                "Eric",
                "Santiago",
                "Joseph"
            };

            var lastNames = new[]
            {
                "Reddy",
                "Ceakala",
                "Smith",
                "Cruz",
                "Hanks",
                "Hinkelman",
                "Hiesenberg",
                "Edison",
                "Turing",
                "Torvalds"
            };

            var streets = new[]
            {
                "121 S 134 E Apt 305",
                "345 N 134 W Apt 205",
                "222 N 134 W Apt 115",
                "300  134 E Apt 115",
                "12 S 134 E Apt 165",
                "12 N 134 W Apt 285"
            };

            var cities = new[]
            {
                "Salt Lake City",
                "Nephi",
                "Logan",
                "Boise",
                "St. George",
                "New York",
            };

            var states = new[]
            {
                "UT",
                "NV",
                "PA",
                "OR"
            };

            var zipCodes = new[]
            {
                "84070",
                "84321",
                "84101",
                "58945",
                "95689",
            };

            var interests = new[]
            {
                "Skiiing",
                "Bowling",
                "Painting",
                "Pottery",
                "Automobiles",
                "Space",
                "Wildlife",
                "Sports",
                "Swimming",
                "Hiking",
                "Knitting",
                "Cooking",
                "Politics"
            };
            
            byte[] getRandomImage()
            {
                var rnd = new Random();
                var i = rnd.Next(8);
                var img = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), @"Resources\") + i + ".png");
                return img;
            }

            DateTime getRandomBirthday()
            {
                var gen = new Random();
                DateTime start = new DateTime(1940, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(gen.Next(range));
            }

            string getRandomFrom(string[] source)
            {
                var rand = new Random();
                var index = rand.Next(source.Length);
                return source[index];
            }

            List<PersonalInterest> getRandomInterests()
            {
                var interestList = new List<PersonalInterest>();
                var rnd = new Random();
                foreach (var i in Enumerable.Range(1, rnd.Next(4)))
                {
                    var text = getRandomFrom(interests);
                    interestList.Add(new PersonalInterest(text));
                }

                return interestList;
            }

            Person getRandomPerson()
            {
                var firstName = getRandomFrom(firstNames);
                var lastName = getRandomFrom(lastNames);
                var img = getRandomImage();
                var dob = getRandomBirthday();
                var personalInterests = getRandomInterests();
                var address = new Address()
                {
                    State = getRandomFrom(states),
                    City = getRandomFrom(cities),
                    Street = getRandomFrom(streets),
                    Zip = getRandomFrom(zipCodes)

                };

                return new Person(firstName, lastName, dob, personalInterests, address, img);
            }

            var connection = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=HealthCatalystDB;Trusted_Connection=True;ConnectRetryCount=0";
            var options = new DbContextOptionsBuilder<PeopleSearchContext>()
                .UseSqlServer(connection)
                .Options;

            using (var ctx = new PeopleSearchContext(options))
            {
                var needsSeeding = ctx.Database.EnsureCreated();

                if (needsSeeding)
                {
                    foreach (var i in Enumerable.Range(1, 100))
                    {
                        ctx.Persons.Add(getRandomPerson());
                    }

                    ctx.SaveChanges();
                }
            }
        }
    }
}
