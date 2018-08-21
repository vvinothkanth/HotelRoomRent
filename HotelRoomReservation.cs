//*****************************
// Auther : vinothkanth
// Problem No : 4
//******************************

/// <summary>
/// The HotelRentSystem Namespace
/// </summary>
namespace HotelRentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// The HotelRoomReservation Class
    /// </summary>
    public class HotelRoomReservation
    {
        /// <summary>
        /// 
        /// </summary>
        private double CookingCost;

        /// <summary>
        /// 
        /// </summary>
        public double MyProperty
        {
            get { return CookingCost; }
            set { CookingCost = value; }
        }
        

        /// <summary>
        /// To read and return the customer type and booking room dates
        /// </summary>
        /// <returns>the formated input of customer type and date</returns>
        public static string setRoomDetail()
        {
            string roomRentDetails = string.Empty;
            try
            {
                roomRentDetails = Convert.ToString(Console.ReadLine());
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return roomRentDetails;
        }

        /// <summary>
        /// To split the string as given charecter
        /// </summary>
        /// <param name="splitData">string data</param>
        /// <param name="splitTo">splited char</param>
        /// <returns>string array of given dataa</returns>
        public static string[] splitDataAsGivenCharacter(string splitData, char splitTo)
        {
            string[] afterSplitData = new string[] { };
            try
            {
                afterSplitData = splitData.Split(splitTo);
            }
            catch (IndexOutOfRangeException arrayIndexException)
            {
                Console.WriteLine(arrayIndexException);
                throw;
            }
            return afterSplitData;
        }

        /// <summary>
        /// To return the customer discount price for the given user type (Regular / rewarded)
        /// </summary>
        /// <param name="customerType">Customer Type(Regular/ Rewarded)</param>
        /// <param name="totalCost">Total cost of room </param>
        /// <returns>discount amount</returns>
        public static double roomRentDiscount(string customerType, double totalCost)
        {
            try
            {
                if (customerType == "rewarded" || customerType == "Rewarded")
                {
                    if (totalCost >= 1000)
                    {
                        return totalCost * 0.05;
                    }
                }
                else if (customerType == "regular" || customerType == "Regular")
                {
                    return 0;
                }
            }
            catch (ArithmeticException arithmeticException)
            {
                Console.WriteLine(arithmeticException);
                throw;
            }

            return 0;

        }
        
        /// <summary>
        /// To chenck whether the given date is weekend or not if weekend it return 600 else it return 500
        /// </summary>
        /// <param name="bookingDate">Input date</param>
        /// <returns>room rent amount</returns>
        public static double checkWeekEnd(string bookingDate)
        {
            double roomRentAmount = 0.0;

            try
            {
                string[] splitDateAsDash = HotelRoomReservation.splitDataAsGivenCharacter(bookingDate, '/');
                if (splitDateAsDash.Length == 3)
                {
                    DateTime CheckBookingDay = new DateTime(Convert.ToInt32(splitDateAsDash[0].Trim()), Convert.ToInt32(splitDateAsDash[1].Trim()), Convert.ToInt32(splitDateAsDash[2].Trim()));
                    bool isWeekEnd = (CheckBookingDay.DayOfWeek == DayOfWeek.Sunday) == true || (CheckBookingDay.DayOfWeek == DayOfWeek.Saturday) == true;
                    if (isWeekEnd)
                    {
                        roomRentAmount = 600;
                    }
                    else
                    {
                        roomRentAmount = 500;
                    }

                }
                else
                {
                    Console.WriteLine("Check Date Formate");
                    setRoomDetail();
                }

            }
            catch (IndexOutOfRangeException dateConnotBeSplit)
            {
                Console.WriteLine(dateConnotBeSplit);
                throw;
            }

            return roomRentAmount;

        }

        /// <summary>
        /// This function is return the string of room rent amount with discount value
        /// </summary>
        /// <param name="roomBookingDetail">string of  customer type with booking date</param>
        /// <returns>string or discount amount detail</returns>
        public static double totalAmountOfRoomRent(string customerDescountType, string[] roomBookingDetail)
        {
            double discountAmountDetail = 0.0;
            try
            {
                foreach (var checkDate in roomBookingDetail)
                {
                    discountAmountDetail += checkWeekEnd(checkDate);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }

            return discountAmountDetail;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the room detail in formate of \n ");
            Console.WriteLine("<customer_type (Rewarded or Regular)> : <YYYY/MM/DD>, <YYYY/MM/DD>, ... ");
            string roomRent =  HotelRoomReservation.setRoomDetail();

            string[] splitDataAsCollen = splitDataAsGivenCharacter(roomRent, ':');
            string[] bookingDates = splitDataAsGivenCharacter(splitDataAsCollen[1], ',');
            string customerType = splitDataAsCollen[0].Trim();

            double totalAmount = HotelRoomReservation.totalAmountOfRoomRent(customerType, bookingDates);
            double paymentDiscount = roomRentDiscount(customerType, totalAmount);
            string discountAmountDetail = string.Format( "Total Cost  : " + totalAmount + ", Total Discount : " + paymentDiscount + ", Net pay : " + (totalAmount - paymentDiscount));
            Console.WriteLine(discountAmountDetail);
            Console.ReadKey();
        }
    }
}
