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
    public class BALTest
    {
        [Fact]
        public void ShouldReturnAll()
        {

            //Arrange
            var mockRepo = new Mock<IBookRepository>();
            var list = new List<Book>{ new Book { Name = "Test1", AuthorName = "AuthorTest1" }  ,  new Book { Name = "Test2", AuthorName = "AuthorTest2" }  };

            mockRepo.Setup(x => x.GetAll()).Returns(list);
            var bookService = new BooksService(mockRepo.Object);

            //Act
            var booksReturned = bookService.GetBooks();
            //Assert
            Assert.Equal(2, booksReturned.Count());
            Assert.Equal("Test1", booksReturned.FirstOrDefault().Name);
        }


        [Fact]
        public void ShouldReturnFiltered()
        {

            //Arrange
            var mockRepo = new Mock<IBookRepository>();
            var list = new List<Book> { new Book { Name = "Gone", AuthorName = "AuthorTest1" }, new Book { Name = "Gone in the wind", AuthorName = "AuthorTest2" },
                new Book { Name = "The Bible", AuthorName = "AuthorTest2" } };

            mockRepo.Setup(x => x.GetAll()).Returns(list);
            var bookService = new BooksService(mockRepo.Object);

            //Act
            var booksReturned = bookService.GetBooks("biB");
            var booksReturned2 = bookService.GetBooks("Bi");
            var booksReturned3 = bookService.GetBooks("GONE");
            var booksReturned4= bookService.GetBooks("");
            //Assert
            Assert.Single(booksReturned);
            Assert.Single(booksReturned2);
            Assert.Equal(2, booksReturned3.Count());
            Assert.Equal(3, booksReturned4.Count());

        }
    }
}
