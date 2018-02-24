using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AustraliaPayment;
using AustraliaPayment.Models;

namespace AustraliaPayment.Testes.Models
{
    [TestClass]
    public class UtilTest
    {
        [TestMethod]
        public void LogTest()
        {
            // Arrange
            string textLog = "07:30:07;123-123;109204;JOHN OLIVER;SUSHI RESTAURANT;71.50";

            //Act
            string result = Util.Log(textLog);
            string fileName = "Payments_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            
            //Assert            
            Assert.AreEqual(result, fileName);
        }
    }
}