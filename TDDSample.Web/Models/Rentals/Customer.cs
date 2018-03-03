using System;
using System.Collections.Generic;
using Microsoft.Extensions.DiagnosticAdapter.Internal;

namespace TDDSample.Web.Models.Rentals
{
    public sealed class Customer{
        private readonly List<Rental> _rentals = new List<Rental>();

        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }
        
        /**
         * レンタル金額を円で返す。
         */
        public string Statement()
        {
            var fee = RentalFee();
            return $"{fee:N0} 円";
        }

        public int RentalFee()
        {
            
            var fee = 0;

            foreach (var t in _rentals)
            {
                fee += Fee(t);
            }

            return fee;
        }

        private static int Fee(Rental t)
        {
            if (t.Movie.RentalType == MovieRentalType.Regular)
            {
                return 200;
            }

            if (t.Movie.RentalType == MovieRentalType.NewRelease)
            {
                return 300 * t.DaysRented;
            }

            throw new InvalidOperationException();
        }
    }
}