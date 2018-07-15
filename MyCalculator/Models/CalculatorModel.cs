using System;
using System.ComponentModel.DataAnnotations;

namespace MyCalculator.Models
{
    public class CalculatorModel : IOhmValueCalculator
    {
        [Required]
        [Display(Name = "Band A Color")]
        public BandColor BandAColor { get; set; }
        [Required]
        [Display(Name = "Band B Color")]
        public BandColor BandBColor { get; set; }

        [Required]
        [Display(Name = "Band C - Multiplier")]
        
        public BandColor BandCColor { get; set; }
        [Required]
        [Display(Name = "Band D - Tolerance")]
        
        public BandColor BandDColor { get; set; }

        public decimal GetResult()
        {
            return CalculateOhmValue(BandAColor.ToString(), BandBColor.ToString(), BandCColor.ToString(), BandDColor.ToString());
        }
        public decimal CalculateOhmValue(string aBandA, string aBandB, string aBandC, string aBandD)
        {
            int sf1, sf2;
            decimal multiplier;
            decimal result = 0;
            //convert string to BandColor and then to int to get the Significant Figure
            sf1 = (int)(BandColor)Enum.Parse(typeof(BandColor), aBandA);
            sf2 = (int)(BandColor)Enum.Parse(typeof(BandColor), aBandB);
            result = (sf1 * 10) + sf2;//sf1 is the first SF so place it in Tens position by multiplying it by 10
            multiplier = GetMultiplier(aBandC);

            result = result * multiplier;
            return result;
        }

       public enum BandColor {
            Black=0,
            Pink=0,
            Gold=0,
            Silver=0,
            Brown=1,
            Red=2,
            Orange=3,
            Yellow=4,
            Green=5,
            Blue=6,
            Violet=7,
            Gray=8,
            White=9,
            DisgustingColor=99//for error conditions
        }
        private decimal GetMultiplier(string aColorName)
        {
            decimal multiplier = 0;

            // could've used BandCColor.ToString() here but defeats the purpose of aBandC in CalculateOhmValue()
            switch (aColorName.ToLower())
            {
                case "pink":
                    multiplier = 0.001m;
                    break;
                case "silver":
                    multiplier = 0.01m;
                    break;
                case "gold":
                    multiplier = 0.1m;
                    break;
                case "black":
                    multiplier = 1;
                    break;
                case "brown":
                    multiplier = 10;
                    break;
                case "red":
                    multiplier = 100;
                    break;
                case "orange":
                    multiplier = 1000;
                    break;
                case "yellow":
                    multiplier = 10000;
                    break;
                case "green":
                    multiplier = 100000;
                    break;
                case "blue":
                    multiplier = 1000000;
                    break;
                case "violet":
                    multiplier = 10000000;
                    break;
                case "gray":
                    multiplier = 100000000;
                    break;
                case "white":
                    multiplier = 1000000000;
                    break;

                default:
                    throw new Exception(String.Format("Invalid color for Multiplier band: {0}. Please select a valid option", aColorName.ToString()));
            }

            return multiplier;
        }

        public string GetTolerance()
        {
            string tolerance = "";
            
            switch (BandDColor.ToString().ToLower())
            {
                case "pink":
                case "black":
                case "orange":
                case "white":
                    tolerance = "";
                    break;
                case "gray":
                    tolerance = "+/- 0.05%";
                    break;
                case "violet":
                case "purple":
                    tolerance = "+/- 0.10%";
                    break;
                case "blue":
                    tolerance = "+/- 0.25%";
                    break;
                case "green":
                    tolerance = "+/- 0.5%";
                    break;
                case "brown":
                    tolerance = "+/- 1%";
                    break;
                case "red":
                    tolerance = "+/- 2%";
                    break;
                case "gold":
                case "yellow":
                    tolerance = "+/- 5%";
                    break;
                case "silver":
                    tolerance = "+/- 10%";
                    break;
                default:
                    throw new Exception(String.Format("Invalid color for Tolerance band: {0}. Please select a valid option", BandDColor.ToString()));
            }
            return tolerance;
        }
    }
}