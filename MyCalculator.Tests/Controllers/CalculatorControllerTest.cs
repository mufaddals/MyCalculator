using NUnit.Framework;
using System.Web.Mvc;
using MyCalculator.Controllers;
using MyCalculator.Models;

namespace MyCalculator.Tests.Controllers
{
    [TestFixture]
    class CalculatorControllerTest
    {
        [Test]
        public void TestIndexView()
        {
            var obj = new CalculatorController();
            var model = new CalculatorModel();
            var actResult = obj.Index(model) as ViewResult;

            Assert.IsNotNull(actResult);
        }

        /// <summary>
        /// Test to assert calculation is correct for combination: Red Green Blue White
        /// </summary>
        [Test]
        public void TestCalculatorValidRGBW()
        {
            var obj = new CalculatorController();
            var model = new CalculatorModel()
            {
                BandAColor = CalculatorModel.BandColor.Red,
                BandBColor = CalculatorModel.BandColor.Green,
                BandCColor = CalculatorModel.BandColor.Blue,
                BandDColor = CalculatorModel.BandColor.White
            };

            ViewResult result = obj.Index(model) as ViewResult;
            Assert.That(result.ViewBag.Message.Trim(), Is.EqualTo("25000000"));
        }

        /// <summary>
        /// Test to assert calculation is correct for combination: Green Green Green Black
        /// </summary>
        [Test]
        public void TestCalculatorValidGGGB()
        {
            var obj = new CalculatorController();
            var model = new CalculatorModel()
            {
                BandAColor = CalculatorModel.BandColor.Green,
                BandBColor = CalculatorModel.BandColor.Green,
                BandCColor = CalculatorModel.BandColor.Green,
                BandDColor = CalculatorModel.BandColor.Black
            };

            ViewResult result = obj.Index(model) as ViewResult;
            Assert.That(result.ViewBag.Message.Trim(), Is.EqualTo("5500000 +/- 5%"));
        }
        /// <summary>
        /// Test to assert calculation is correct for combination: White White White Black
        /// </summary>
        [Test]
        public void TestCalculatorValidWWWB()
        {
            var obj = new CalculatorController();
            var model = new CalculatorModel()
            {
                BandAColor = CalculatorModel.BandColor.White,
                BandBColor = CalculatorModel.BandColor.White,
                BandCColor = CalculatorModel.BandColor.White,
                BandDColor = CalculatorModel.BandColor.Black
            };

            ViewResult result = obj.Index(model) as ViewResult;
            Assert.That(result.ViewBag.Message.Trim(), Is.EqualTo("99000000000 +/- 5%"));
        }

        /// <summary>
        /// Test to assert ModelState.IsValid = False for combination: Brown Orange DisgustingColor Yellow
        /// </summary>
        [Test]
        public void TestCalculatorInvalidBODY()
        {
            var obj = new CalculatorController();
            var model = new CalculatorModel()
            {
                BandAColor = CalculatorModel.BandColor.Brown,
                BandBColor = CalculatorModel.BandColor.Orange,
                BandCColor = CalculatorModel.BandColor.DisgustingColor,
                BandDColor = CalculatorModel.BandColor.Yellow
            };
            
            ViewResult result = obj.Index(model) as ViewResult;
            Assert.False(obj.ModelState.IsValid);
        }
        /// <summary>
        /// Test to assert calculation is correct for combination mentioned in Wikipedia: red, violet, green, and brown
        /// </summary>
        [Test]
        public void TestCalculatorValidRVGBWikipedia()
        {
            var obj = new CalculatorController();
            var model = new CalculatorModel()
            {
                BandAColor = CalculatorModel.BandColor.Red,
                BandBColor = CalculatorModel.BandColor.Violet,
                BandCColor = CalculatorModel.BandColor.Green,
                BandDColor = CalculatorModel.BandColor.Brown
            };

            ViewResult result = obj.Index(model) as ViewResult;
            Assert.That(result.ViewBag.Message.Trim(), Is.EqualTo("2700000 +/- 1%"));
        }
        
    }
}
