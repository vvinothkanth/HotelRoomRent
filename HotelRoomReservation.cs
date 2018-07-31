//*****************************
//
// Auther : vinothkanth
// Problem No : 4
//
// We have one hotel with fixed room rate for week day and week end  i.e., one room's week 
// day cost is 500 rupees and weekend's cost is 600 Rupees, and there are two types of customer,
// rewarded and regular, if regular, there will not be any change in room cost but if rewarded, 
// they will get 5% discount if the total cost is above 1000 Rupees. So, customer will come and 
// enter the dates for on which they need rooms, your program should see the date and determine 
// whether it is week day or weekend and based on that customer type and dates, it should display 
// the total amount with discount applied.
//
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
        /// To read and return the customer type and booking room dates
        /// </summary>
        /// <returns>the formated input of customer type and date</returns>
        public static string setRoomDetail()
        {
            string roomRentDetails = string.Empty;
            try
            {
                Console.WriteLine("Enter the room detail in formate of \n ");
                Console.WriteLine("<customer_type (Rewarded or Regular)> : <YYYY/MM/DD>, <YYYY/MM/DD>, ... ");
                roomRentDetails = Convert.ToString(Console.ReadLine());
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception);
                throw new ArgumentNullException(exception.Message);
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
                throw new IndexOutOfRangeException(arrayIndexException.Message);
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
                else
                {
                    Console.WriteLine("User Not Valid");
                    setRoomDetail();
                }
            }
            catch (ArithmeticException arithmeticException)
            {
                Console.WriteLine(arithmeticException);
                throw new ArithmeticException(arithmeticException.Message);
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
                    if ((CheckBookingDay.DayOfWeek == DayOfWeek.Sunday) == true || (CheckBookingDay.DayOfWeek == DayOfWeek.Saturday) == true)
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
                throw new IndexOutOfRangeException(dateConnotBeSplit.Message);
            }

            return roomRentAmount;

        }

        /// <summary>
        /// This function is return the string of room rent amount with discount value
        /// </summary>
        /// <param name="roomBookingDetail">string of  customer type with booking date</param>
        /// <returns>string or discount amount detail</returns>
        public static string generatingDiscountReport(string roomBookingDetail)
        {
            string discountAmountDetail = string.Empty;
            try
            {
                string[] splitDataAsCollen = HotelRoomReservation.splitDataAsGivenCharacter(roomBookingDetail, ':');
                string[] bookingDates = HotelRoomReservation.splitDataAsGivenCharacter(splitDataAsCollen[1], ',');
                double totalOfCost = 0.0;
                foreach (var checkDate in bookingDates)
                {
                    totalOfCost += checkWeekEnd(checkDate);
                }

                double discountAmount =  roomRentDiscount(splitDataAsCollen[0].Trim(), totalOfCost);

                discountAmountDetail = "Total Cost  : " + totalOfCost + ", Total Discount : " + discountAmount  + ", Net pay : " + (totalOfCost - discountAmount);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new IndexOutOfRangeException(e.Message);
            }

            return discountAmountDetail;
        }

        /// <summary>
        /// The Main Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string roomRent =  HotelRoomReservation.setRoomDetail();
            Console.WriteLine(HotelRoomReservation.generatingDiscountReport(roomRent));
            Console.ReadKey();
        }
    }
}
