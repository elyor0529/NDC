using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using NDC.Common.Enums;
using NDC.SOAP.Models;

namespace NDC.SOAP.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NDCDbContext>
    {
        private static Person[] GeneratetestData()
        {
            var peoples = new List<Person>();

            for (var i = 0; i < 150; i += 15)
                peoples.AddRange(new[]
                {
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 1,
                        FullName = "John White " + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Female,
                        Id = i + 2,
                        FullName = "Natalie Black " + i,
                        BirthDate = DateTime.Now.AddYears(-38),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 3,
                        FullName = "Simon Yellow" + i,
                        BirthDate = DateTime.Now.AddYears(-18),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Female,
                        Id = i + 4,
                        FullName = "Jessica Red" + i,
                        BirthDate = DateTime.Now.AddYears(-68),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Female,
                        Id = i+5,
                        FullName = "Monika Brown" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 6,
                        FullName = "Joshua Aquamarine" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 7,
                        FullName = "Jim Blue" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Female,
                        Id = i + 8,
                        FullName = "Angela Green" + i,
                        BirthDate = DateTime.Now.AddYears(-78),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 9,
                        FullName = "Dorian Gray" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Female,
                        Id = i + 10,
                        FullName = "Marina Violet" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 11,
                        FullName = "Modesty Gold" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 12,
                        FullName = "Markos Navy" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 13,
                        FullName = "Alanah White" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Male,
                        Id = i + 14,
                        FullName = "John Smith" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    },
                    new Person
                    {
                        Gender = Gender.Female,
                        Id = i + 15,
                        FullName = "Elena Barget" + i,
                        BirthDate = DateTime.Now.AddYears(-28),
                        Country = "USA",
                        Height = 170,
                        Weight = 80
                    }
                });

            return peoples.ToArray();
        }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NDCDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.People.AddOrUpdate(p => p.Id, GeneratetestData());
        }


    }
}