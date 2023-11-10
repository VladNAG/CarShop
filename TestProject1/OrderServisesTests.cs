using User.Servises;
using User.Interfeces;
using User.Data.Entityes;

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class OrderServisesTests
    {
        private readonly Mock<IDataProvider> _dataOrderMock = new Mock<IDataProvider>();
        private List<Order> GetALLTestOrder()
        {
            var order = new List<Order>
            {
                new Order {Id=1, LastName = "Tesla", FirstName = "Model X", Email = "tml", },
                    new Order {Id=2, LastName = "Lusid", FirstName = "Luxury", Email = "tml", },
                    new Order {Id=3, LastName = "BMW", FirstName = "X5", Email = "789005.html",},
                    new Order {Id = 4,  LastName = "Ford", FirstName = "Mustang", Email = "tml",}
            };
            return order;
        }
        private List<Order> GetALLNullTestOrder()
        {
            List<Order> order = null;
            return order;
        }

        [Fact]
        public void Create_OrderIsNotNull_ShouldCallCreateOrder()
        {
            // Arrange

            var services = new Servises(_dataOrderMock.Object);
            var car = new Order { Id = 1 };

            // Act
            services.Save(car);

            // Assert
            _dataOrderMock.Verify(x => x.SaveOrder(car), Times.Once);
        }

       
        [Fact]
        public void Create_OrderIsNull_ShouldNotCallCreateOrder()
        {
            // Arrange

            var services = new Servises(_dataOrderMock.Object);
            Order order = null;

            // Act
            services.Save(order);

            // Assert
            _dataOrderMock.Verify(x => x.SaveOrder(It.IsAny<Order>()), Times.Once);
        }

        [Fact]
        public void Create_OrderIsNotNull_ShouldCallOrder()
        {
            // Arrange

            var services = new Servises(_dataOrderMock.Object);
            var car = new Order { Id = 1 };

            // Act
            services.Save(car);

            // Assert
            _dataOrderMock.Verify(x => x.SaveOrder(car), Times.Once);
        }
    }
}
