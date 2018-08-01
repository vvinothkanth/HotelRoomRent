// Problem No : 4
// Auther : vinothkanth
//
// Test Case for Room Rent 
//
//
//

/// <summary>
/// The HotelTesting Namespace
/// </summary>
namespace HotelTesting
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HotelRentSystem;

    /// <summary>
    /// The RoomRentTesting Class
    /// </summary>
    [TestClass]
    public class RoomRentTesting
    {
        /// <summary>
        /// To test the given string are splited in right formate
        /// </summary>
        [TestMethod]
        public void checkSplitingMethod()
        {
            string[] afterSplitAsColen =  HotelRoomReservation.splitDataAsGivenCharacter("type:date,date", ':');
            string[] afterSplitAsComma = HotelRoomReservation.splitDataAsGivenCharacter("date,date", ',');
            string[] afterSplitAsSlash = HotelRoomReservation.splitDataAsGivenCharacter("23/7/2018", '/');

            CollectionAssert.AreEqual(new string[] { "type", "date,date" }, afterSplitAsColen);
            CollectionAssert.AreNotEqual(new string[] { "type:", "date,date" }, afterSplitAsColen);
            CollectionAssert.AreEqual(new string[] { "date", "date" }, afterSplitAsComma);
            CollectionAssert.AreNotEqual(new string[] { "date,", "date," }, afterSplitAsComma);
            CollectionAssert.AreEqual(new string[] { "23", "7", "2018" }, afterSplitAsSlash);
            CollectionAssert.AreNotEqual(new string[] { "7", "23", "2018" }, afterSplitAsSlash);
        }

        /// <summary>
        /// To test the discount amount is correct or not
        /// </summary>
        [TestMethod]
        public void checkRoomRentDiscount()
        {
            double discountAmount = HotelRoomReservation.roomRentDiscount("Regular",1200);
            double discountAmount_I = HotelRoomReservation.roomRentDiscount("Rewarded", 1000);
            double discountAmount_II = HotelRoomReservation.roomRentDiscount("Rewarded", 600);

            Assert.AreEqual(0.0, discountAmount);
            Assert.AreNotEqual(1150, discountAmount);
            Assert.AreEqual(50, discountAmount_I);
            Assert.AreNotEqual(0.0, discountAmount_I);
            Assert.AreEqual(0.0, discountAmount_II);
        }

        /// <summary>
        /// To test a fuction return the correct room rent amount for weekday and weekends
        /// </summary>
        [TestMethod]
        public void checkWeekendOrNot()
        {
            double roomRent = HotelRoomReservation.checkWeekEnd("2018/7/23");
            double roomRent_I = HotelRoomReservation.checkWeekEnd("2018/7/29");

            Assert.AreEqual(500, roomRent);
            Assert.AreNotEqual(600, roomRent);
            Assert.AreEqual(600, roomRent_I);
            Assert.AreNotEqual(500, roomRent_I);
        }

        /// <summary>
        /// To checkthe result is correc or not
        /// </summary>
        [TestMethod]
        public void checkGenerateReport()
        {
            double report = HotelRoomReservation.totalAmountOfRoomRent("regular", new string[]{"2018/7/7","2018/6/6"});
            Assert.AreEqual(1100, report);
            Assert.AreNotEqual(1000, report);

        }
    }
}
