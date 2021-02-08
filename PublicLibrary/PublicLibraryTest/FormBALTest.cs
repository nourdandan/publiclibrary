using System;
using Xunit;
using Moq;
using PublicLibrary.DAL;
using PublicLibrary.DAL.Repositories;
using System.Linq;
using System.Collections.Generic;
using PublicLibrary.Models;
using PublicLibrary.BAL.Services;

namespace PublicLibraryTest
{
    public class FormBALTest
    {

        [Theory]
        [InlineData("Oscar Lewis", "Children Of Sanchez", "When is this available?")]
        [InlineData("Jonathan Haidt", "The coddling of the american mind", "When is this available?")]
        public void ShouldAddEntity(string authorName , string bookName, string question)
        {

            //Arrange
            var mockRepo = new Mock<IFormRepository>();
            var listOfForms = new List<Form>();
            var form = new Form { AuthorName = authorName, BookName = bookName, Question = question};


            mockRepo.Setup(x => x.Add(It.IsAny<Form>())).Callback<Form>(item => listOfForms.Add(item));
            var formsService = new FormsService(mockRepo.Object);

            //Act
            formsService.AddFormQuery(form);

            //Assert
            Assert.Single(listOfForms);
            Assert.Equal(authorName,listOfForms.FirstOrDefault().AuthorName);
            Assert.Equal(bookName,listOfForms.FirstOrDefault().BookName);
            Assert.Equal(question,listOfForms.FirstOrDefault().Question);
        }



        [Theory]
        [InlineData("Oscar Lewis", "MW80sUotaJyEbS6RrarL7Pllb3041KUieMKrFxXYDISqTrGVWVb", "When is this available?")]
        [InlineData("XOR5QUhVeD5KjQhVY1zSkwRMyAfVxgEkdIFny0bLP", "The coddling of the american mind", "When is this available?")]
        [InlineData("Jonathan Haidt", "The coddling of the american mind",
            "0AZe1cN16nSlj3x5HHiVAffsDD2GMnbA5Sp7b84AQrpRQhiw2MUay8GUnt6LSMyzCTEp0jaJ5Gd1PSxfycMChWEkJGVbO3JGhPPVZSYarjmf793neE8SeQ2zs5Nx3qMua1O4klsY" +
            "G3PvG7D1pMD1jWpX9GJrLukGftdQmiMvAjhnxMxAqMcIunTXp47rgD6o4UYJxeQW5N2gxAokQa5uE2uD337DXY00xuZSnlVf6nRpy0IobhbLWBbCvRa671sas3gxJaDOs17RqsPGXq6R" +
            "18u5NfK7eHu9eZ0BdUg8CxmYEOe62BmJItXsEmlaunpHLtSnqbOHQRNc0wITQM1bKTQxU2An6W5uDi3zGO3DVyktoTcMECrITq9qHFUHfUkx1oa1XdaWIV58q6mgbpWPo2faCyEpHwnljrebI7yGJKt" +
            "S4gjIQ1X62L89UKEZR901WIWEj1bKU5DvK65i4PwHpKVIBcuAqyCQAAor84ozXsPBJjjJ3cZ0Y"
            )]
        public void ShouldRejectEveryData(string authorName, string bookName, string question)
        {

            //Arrange
            var mockRepo = new Mock<IFormRepository>();
            var listOfForms = new List<Form>();
            var form = new Form { AuthorName = authorName, BookName = bookName, Question = question };


            mockRepo.Setup(x => x.Add(It.IsAny<Form>())).Callback<Form>(item => listOfForms.Add(item));
            var formsService = new FormsService(mockRepo.Object);

            //Act
            formsService.AddFormQuery(form);

            //Assert
            Assert.Empty(listOfForms);
                
        }


    }
}
