using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using System.Collections.Generic;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController _bcontroller;
        private IBookService _bookService;
        private OrderController _ocontroller;
        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _bookService = new BookService(new BookRepository());
            _bcontroller = new BookController(_bookService);
            _orderService = new OrderService(new OrderRepository());
            _ocontroller = new OrderController(_orderService);
        }

        [Test]
        public void GetAllBooks_ReturnsOk()
        {
            // Arrange

            // Act
            var result = _bcontroller.GetAllBooks() as ActionResult<List<Book>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetBook_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingBookId = 999;

            // Act
            var result = _bcontroller.GetBook(nonExistingBookId) as ActionResult<Book>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void AddBook_ValidData_ReturnsOk()
        {
            // Arrange
            var newBook = new Book
            {
                BookId = 2,
                BookName = "New Book",
                Category = "Fiction",
                Price = 15.99M
            };

            // Act
            var result = _bcontroller.AddBook(newBook) as ActionResult<Book>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void DeleteBook_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingBookId = 999;

            // Act
            var result = _bcontroller.DeleteBook(nonExistingBookId) as IActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public void GetAllOrders_ReturnsOk()
        {
            // Arrange

            // Act
            var result = _ocontroller.GetAllOrders() as ActionResult<List<Order>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetOrder_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingOrderId = 999;

            // Act
            var result = _ocontroller.GetOrder(nonExistingOrderId) as ActionResult<Order>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void AddOrder_ValidData_ReturnsOk()
        {
            // Arrange
            var newOrder = new Order
            {
                OrderId = 2,
                CustomerName = "John Doe",
                TotalAmount = 100
            };

            // Act
            var result = _ocontroller.AddOrder(newOrder) as ActionResult<Order>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void DeleteOrder_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingOrderId = 999;

            // Act
            var result = _ocontroller.DeleteOrder(nonExistingOrderId) as IActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
