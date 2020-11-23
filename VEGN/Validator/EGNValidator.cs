using System;
using System.Globalization;
using System.Linq;
using Common;

namespace Validator
{
    public class EGNValidator : IEGNvalidator
    {
        public validatinResult ValidateEGNFormat(string eGN)
        {
            validatinResult result = new validatinResult();

            if (eGN.Length == 0)
            {
                result.IsValid = false;
                result.Error = ValidationError.EmptyString;

                return result;
            }

            if (eGN.Length > 10)
            {
                result.IsValid = false;
                result.Error = ValidationError.TooLongString;

                return result;
            }

            if (eGN.Length < 10)
            {
                result.IsValid = false;
                result.Error = ValidationError.TooShortString;

                return result;
            }

            if (eGN.All(char.IsDigit) == false)
            {
                result.IsValid = false;
                result.Error = ValidationError.InvalidSymbols;

                return result;
            }

            DateTime birthDate;
            int month = int.Parse(eGN.Substring(2, 2));
            string date = string.Format("{0}/{1}/{2}", eGN.Substring(0, 2), eGN.Substring(2, 2), eGN.Substring(4, 2));

            if (month > 40)
            {
                date = date.Remove(3, 2);
                string monthString = (month - 40).ToString();
                if (monthString.Length == 1)
                {
                    monthString = monthString.Insert(0, "0");
                }
                date = date.Insert(3, monthString);
                date = string.Format("20{0}", date);
            }
            else if (month > 20)
            {
                date = date.Remove(3, 2);
                string monthString = (month - 20).ToString();
                if (monthString.Length == 1)
                {
                    monthString = monthString.Insert(0, "0");
                }
                date = date.Insert(3, monthString);
                date = string.Format("18{0}", date);
            }
            else
            {
                date = string.Format("19{0}", date);
            }
            
            if (DateTime.TryParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out birthDate) == false)
            {
                result.IsValid = false;
                result.Error = ValidationError.InvalidDate;

                return result;
            }

            string areaCode = eGN.Substring(6,3);

            int first = int.Parse(eGN.Substring(0, 1));
            int second = int.Parse(eGN.Substring(1, 1));
            int third = int.Parse(eGN.Substring(2, 1));
            int fourth = int.Parse(eGN.Substring(3, 1));
            int fifth = int.Parse(eGN.Substring(4, 1));
            int sixt = int.Parse(eGN.Substring(5, 1));
            int seventh = int.Parse(eGN.Substring(6, 1));
            int eighth = int.Parse(eGN.Substring(7, 1));
            int nineth = int.Parse(eGN.Substring(8, 1));
            int control = int.Parse(eGN.Substring(9, 1));

            first *= 2;
            second *= 4;
            third *= 8;
            fourth *= 5;
            fifth *= 10;
            sixt *= 9;
            seventh *= 7;
            eighth *= 3;
            nineth *= 6;

            var remain = (first + second + third + fourth + fifth + sixt + seventh + eighth + nineth) % 11;

            if (remain > 10)
            {
                remain = 0;
            }

            if (remain != control)
            {
                result.IsValid = false;
                result.Error = ValidationError.InvalidControlNumber;

                return result;
            }

            result.IsValid = true;
            result.Error = ValidationError.None;

            return result;
        }
    }
}
