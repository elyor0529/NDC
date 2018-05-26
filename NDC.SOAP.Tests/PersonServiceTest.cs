using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDC.Common.Enums;
using NDC.Common.ViewModels;
using NDC.SOAP.Models;
using NDC.SOAP.Respositories;
using NDC.SOAP.Services;

namespace NDC.SOAP.Tests
{
    [TestClass]
    public class PersonServiceTest
    {
        private const string MAIL = "elyor.blog@gmail.com";
        private IPersonService _soap;

        [TestInitialize]
        public void SetupTests()
        {
            // Arrange
            var serviceMoq = new Mock<IService>();
            serviceMoq.Setup(service => service.BatchSend(MAIL, new Person[1]));

            var repoMoq = new Mock<IRepository>();
            repoMoq.Setup(repository => repository.FindBy(person => It.IsAny<bool>()))
                .Returns(delegate
                {
                    return new Person[]
                    {
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 1,
                            FullName = "John White ",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Female,
                            Id = 2,
                            FullName = "Natalie Black ",
                            BirthDate = DateTime.Now.AddYears(-38),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 3,
                            FullName = "Simon Yellow",
                            BirthDate = DateTime.Now.AddYears(-18),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Female,
                            Id = 4,
                            FullName = "Jessica Red",
                            BirthDate = DateTime.Now.AddYears(-68),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Female,
                            Id = 5,
                            FullName = "Monika Brown",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 6,
                            FullName = "Joshua Aquamarine",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 7,
                            FullName = "Jim Blue",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Female,
                            Id = 8,
                            FullName = "Angela Green",
                            BirthDate = DateTime.Now.AddYears(-78),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 9,
                            FullName = "Dorian Gray",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Female,
                            Id = 10,
                            FullName = "Marina Violet",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 11,
                            FullName = "Modesty Gold",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 12,
                            FullName = "Markos Navy",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 13,
                            FullName = "Alanah White",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Male,
                            Id = 14,
                            FullName = "John Smith",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        },
                        new Person
                        {
                            Gender = Gender.Female,
                            Id = 15,
                            FullName = "Elena Barget",
                            BirthDate = DateTime.Now.AddYears(-28),
                            Country = "USA",
                            Height = 170,
                            Weight = 80
                        }
                    };
                });
            _soap = new PersonService(repoMoq.Object, serviceMoq.Object);
        }

        [TestMethod]
        public void Search_Test()
        {
            // Act 
            var result = _soap.Search(MAIL, new SearchModel
            {
                Gender = Gender.Male,
                Names = "John",
                MinWeight = 50,
                MaxWeight = 150,
                MinHeigth = 50,
                MaxHeigth = 200,
                MinAge = 5,
                MaxAge = 100,
                Nationality = "USA"
            });

            // Assert
            Assert.IsTrue(result > 0);
        }
    }
}
