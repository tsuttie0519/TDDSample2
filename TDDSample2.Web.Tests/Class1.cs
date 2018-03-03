using System.Reflection.PortableExecutable;
using TDDSample.Web.Models.Rentals;
using Xunit;

namespace TDDSample2.Web.Tests
{

    public class RentalTest
    {
        private readonly Movie _movie;
        private readonly Customer _customer;
        private readonly Movie _movie2;

        public RentalTest()
        {
            _movie = new Movie("コードギアス", MovieRentalType.NewRelease);
            _customer = new Customer("太郎");
            _movie2 = new Movie("銀魂", MovieRentalType.Regular);
        }

        [Fact]
        public void 新作を借りたら300円()
        {
            _customer.AddRental(new Rental(_movie, 1));

            var result = _customer.Statement();

            Assert.Equal("300 円", result);
        }

        [Fact]
        public void 新作を三泊借りたら900円()
        {
            _customer.AddRental(new Rental(_movie, 3));
            var result = _customer.RentalFee();
            Assert.Equal(900, result);
        }

        [Fact]
        public void 整形1200円にはカンマが入る()
        {
            _customer.AddRental(new Rental(_movie, 4));

            var result = _customer.Statement();

            Assert.Equal("1,200 円", result);
        }

        [Fact]
        public void 普通を二泊借りたら200円()
        {
            _customer.AddRental(new Rental(_movie2, 2));

            var result = _customer.RentalFee();

            Assert.Equal(200, result);
        }

        [Fact]
        public void 新作と旧作を一本ずつ()
        {
            _customer.AddRental(new Rental(_movie2, 1));
            _customer.AddRental(new Rental(_movie, 1));

            var result = _customer.RentalFee();

            Assert.Equal(500, result);
        }


    }
}
