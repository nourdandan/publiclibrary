using Microsoft.Extensions.Logging;
using Moq;
using PublicLibrary.BAL.Services;
using Xunit;
using PublicLibrary.Web.UI.Administration.Controllers;
using Microsoft.AspNetCore.Hosting;
using PublicLibrary.Models;
using System;
using PublicLibrary.Web.UI.Administration.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace PublicLibraryTest
{
    public class BookControllerTest
    {
        BookController bookController;
        Mock<IBooksService> mockBookService = new Mock<IBooksService>();
        Mock<IFormsService> mockFormService = new Mock<IFormsService>();
        Mock<IWebHostEnvironment> mockWebHost = new Mock<IWebHostEnvironment>();
        Mock<IErrorHandler> mockErrorhandler = new Mock<IErrorHandler>();
        private BookController GetBookController()
        {
           return new BookController(
                       mockBookService.Object,
                       mockFormService.Object,
                       mockWebHost.Object,
                       mockErrorhandler.Object);
        }

        private void Dispose()
        {
            mockBookService.Reset();
            mockFormService.Reset();
            mockWebHost.Reset();
            mockErrorhandler.Reset();
        }


        [Theory]
        [InlineData("An Error has occured at Form Service level",1)]
        [InlineData("The Exception was catched in controller",1)]
        public void FormServices_HandleExceptionLog(string errorMessage , int index)
        {
            //Arrange
            var exceptionMessage = string.Empty;
            mockFormService.Setup(x => x.AddFormQuery(It.IsAny<Form>())).Throws(new System.Exception(errorMessage));
            mockErrorhandler.Setup(x => x.HandleErrorException(It.IsAny<string>())).Callback((string message) 
                => { exceptionMessage = $"{index}:{errorMessage}"; });
            bookController = GetBookController();

            //Act
            var result = bookController.PostQuestion(string.Empty, string.Empty, string.Empty);

            //Assert
            Assert.Equal($"{index}:{errorMessage}", exceptionMessage);
            Assert.IsType<ViewResult>(result);

            Dispose();
        }
    }
}
