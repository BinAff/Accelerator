using System;
using System.Text.RegularExpressions;

namespace BinAff.Utility
{

    public static class ValidationRule
    {

        public static DateTime Today = DateTime.Today;

        #region String

        /// <summary>
        /// Validate the maximum length of string
        /// </summary>
        /// <param name="data">Data to validate</param>
        /// <param name="maxLength">Maximum length allowed</param>
        /// <returns></returns>
        public static bool IsLengthExceeded(string data, int maxLength)
        {
            return IsLengthExceeded(data, 0, maxLength);
        }

        /// <summary>
        /// Validate the length of string
        /// </summary>
        /// <param name="data">Data to validate</param>
        /// <param name="minLength">Minimum allowed length</param>
        /// <param name="maxLength">Maximum length allowed</param>
        /// <returns></returns>
        public static bool IsLengthExceeded(string data, int minLength, int maxLength)
        {
            return (IsNullOrEmpty(data) ?
                        false :
                        (data.Trim().Length < minLength || data.Trim().Length > maxLength)
                   );
        }

        /// <summary>
        /// Validate string with alphabet only
        /// </summary>
        /// <param name="data">Data to validate</param>
        /// <returns></returns>
        public static bool IsAlphabet(string data)
        {
            return IsNullOrEmpty(data) ? false : data.Trim() == String.Empty ? true : new Regex(@"^[a-zA-Z]+$").IsMatch(data.Trim());
        }

        /// <summary>
        /// Validate string with alphabets, space( ) and dot(.) only
        /// </summary>
        /// <param name="data">Data to validate</param>
        /// <returns></returns>
        public static bool IsName(string data)
        {
            return IsNullOrEmpty(data) ? false : data.Trim() == String.Empty ? true : new Regex(@"^[a-zA-Z ].+$").IsMatch(data.Trim());
        }

        /// <summary>
        /// Validate string with alphabet and space
        /// </summary>
        /// <param name="data">Data to validate</param>
        /// <returns></returns>
        public static bool IsAlphabetWithSpace(string data)
        {
            return IsNullOrEmpty(data) ? false : data.Trim() == String.Empty ? true : new Regex(@"^[a-zA-Z ]+$").IsMatch(data.Trim());
        }

        /// <summary>
        /// Validate string is numeric
        /// </summary>
        /// <param name="data">Data to validate</param>
        /// <returns></returns>
        public static bool IsNumeric(string data)
        {
            return IsNullOrEmpty(data) ? false : data.Trim() == string.Empty ? true : new Regex(@"^[-+]?[0-9]+$").IsMatch(data.Trim());
        }

        /// <summary>
        /// Validates string is decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDecimal(string value)
        {
            if (value.StartsWith("."))
            {
                value = "0" + value;
            }
            return IsDecimal(value, 2);
        }

        /// <summary>
        /// Validates string is decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDecimal(string value, int decimalsCount)
        {
            return IsNullOrEmpty(value) ? false : new Regex(@"^[-+]?[0-9]+(\.\d{0," + decimalsCount.ToString() + "})?$").IsMatch(value.Trim());
        }

        /// <summary>
        /// Validates string contains alphabets & Numerics only
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(string value)
        {
            return IsNullOrEmpty(value) ? false : new Regex(@"^[0-9a-zA-Z]*$").IsMatch(value.Trim());
        }

        /// <summary>
        /// Validates string contains alphabets, Numerics & Special characters only
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsAlphaNumSpecial(String value)
        {
            return value.Trim() == string.Empty ? true : new Regex(@"^[\n\ra-zA-Z0-9-_#@&%^*()=`+{};:,.?\\/ ]+$").IsMatch(value.Trim());
        }

        /// <summary>
        /// validates string for given customer regular expression
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="expression">Regular expression for eg: [a-zA-Z]+[0-9]? </param>
        /// <returns></returns>
        public static bool IsCustom(string data, string expression)
        {
            return IsNullOrEmpty(data) ? false : new Regex(@"^" + expression + "$").IsMatch(data.Trim());
        }

        #endregion

        #region Numeric

        #region IsPositive

        /// <summary>
        /// Validate numeric value is positive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsPositive(short data)
        {
            return data >= 0;
        }

        /// <summary>
        /// Validate numeric value is positive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsPositive(int data)
        {
            return data >= 0;
        }

        /// <summary>
        /// Validate numeric value is positive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsPositive(long data)
        {
            return data >= 0;
        }

        /// <summary>
        /// Validate numeric value is positive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsPositive(float data)
        {
            return data >= 0;
        }

        /// <summary>
        /// Validate numeric value is positive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsPositive(double data)
        {
            return data >= 0;
        }

        /// <summary>
        /// Validate numeric value is positive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsPositive(decimal data)
        {
            return data >= 0;
        }

        #endregion

        #region IsNegative

        /// <summary>
        /// Validate numeric value is negetive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsNegative(short data)
        {
            return data < 0;
        }

        /// <summary>
        /// Validate numeric value is negetive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsNegative(int data)
        {
            return data < 0;
        }

        /// <summary>
        /// Validate numeric value is negetive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsNegative(long data)
        {
            return data < 0;
        }

        /// <summary>
        /// Validate numeric value is negetive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsNegative(float data)
        {
            return data < 0;
        }

        /// <summary>
        /// Validate numeric value is negetive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsNegative(double data)
        {
            return data < 0;
        }

        /// <summary>
        /// Validate numeric value is negetive
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsNegative(decimal data)
        {
            return data < 0;
        }

        #endregion

        #region IsInteger

        public static bool IsInteger(String data)
        {
            try
            {
                Int32.Parse(data);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// Validate greater than 24
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsGreaterThan24Hours(int data)
        {
            return data <= 24;
        }

        #endregion

        #region Date

        /// <summary>
        /// Validates whether date is in dd-MM-yyyy format or not
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsValidDate(string data)
        {
            return Converter.ToDefaultDateTime(data) != DateTime.MinValue;
        }

        /// <summary>
        /// Validates whether date is in MM-dd-yyyy format or not
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsValidSystemDate(string data)
        {
            return Converter.ToDefaultSystemDateTime(data) != DateTime.MinValue;
        }

        /// <summary>
        /// Validates date with Year as four digit
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsValidDate(string data, bool OnlyYearCheck)
        {
            return Converter.ToDefaultDateTime(data).Year.ToString().Length == 4;
        }

        /// <summary>
        /// Validates date with Year as four digit
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsValidDate(DateTime data)
        {
            return data.Year.ToString().Length == 4;
        }

        /// <summary>
        /// Validates whether date is greater than today's date or not
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsDateGreaterThanToday(DateTime date)
        {
            return IsDateGreater(date, Today);
        }

        /// <summary>
        /// Validates whether date is less than today's date or not
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsDateLessThanToday(DateTime date)
        {
            return IsDateLess(date, Today);
        }

        /// <summary>
        /// Validates whether date1 is less than date2 or not
        /// </summary>
        /// <param name="date1">date 1</param>
        /// <param name="date2">date 2</param>
        /// <returns></returns>
        public static bool IsDateLess(DateTime date1, DateTime date2)
        {
            return DateTime.Compare(date1.Date, date2.Date) < 0;
        }

        /// <summary>
        /// Validates whether date1 is less than/ equal to date2 or not
        /// </summary>
        /// <param name="date1">date 1</param>
        /// <param name="date2">date 2</param>
        /// <returns></returns>
        public static bool IsDateLessThanEqual(DateTime date1, DateTime date2)
        {
            return DateTime.Compare(date1.Date, date2.Date) <= 0;
        }

        /// <summary>
        /// Validates whether date1 is greater than date2 or not
        /// </summary>
        /// <param name="date1">date 1</param>
        /// <param name="date2">date 2</param>
        /// <returns></returns>
        public static bool IsDateGreater(DateTime date1, DateTime date2)
        {
            return DateTime.Compare(date1, date2) > 0;
        }

        /// <summary>
        /// Validates whether date1 is greater than/ equal to date2 or not
        /// </summary>
        /// <param name="date1">date 1</param>
        /// <param name="date2">date 2</param>
        /// <returns></returns>
        public static bool IsDateGreaterThanEqual(DateTime date1, DateTime date2)
        {
            return DateTime.Compare(date1.Date, date2.Date) >= 0;
        }

        /// <summary>
        /// Validates whether date1 & date2 are equal or not
        /// </summary>
        /// <param name="date1">date 1</param>
        /// <param name="date2">date 2</param>
        /// <returns></returns>
        public static bool IsDateEqual(DateTime date1, DateTime date2)
        {
            return DateTime.Compare(date1.Date, date2.Date) == 0;
        }

        /// <summary>
        /// Checks whether the given date is falling in given current financial year or not
        /// </summary>
        /// <param name="data">date</param>
        /// <param name="financialYear">financial year</param>
        /// <returns></returns>
        public static bool IsDateFallsInCurrentFinancialYear(DateTime data, int financialYear)
        {
            DateTime start = new DateTime(financialYear, 04, 1); // 1st April + current year
            DateTime end = new DateTime(financialYear + 1, 03, 31); // 31st march + next year
            return data >= start && data <= end;
        }

        /// <summary>
        /// Checks whether the given date is falling in between given dates
        /// </summary>
        /// <param name="data">date</param>
        /// <param name="StartDate">date</param>
        /// <param name="EndDate">date</param>
        /// <returns></returns>
        public static bool IsDateFallsInBetweenDate(DateTime dataToBeChecked, DateTime StartDate, DateTime EndDate)
        {
            return dataToBeChecked >= StartDate && dataToBeChecked <= EndDate;
        }

        /// <summary>
        /// Checks whether the given date is falling in current financial year or not
        /// </summary>
        /// <param name="data">date</param>
        /// <returns></returns>
        public static bool IsDateFallsInCurrentFinancialYear(DateTime data)
        {
            if (Today.Month == 1 || Today.Month == 2 || Today.Month == 3)
                return IsDateFallsInCurrentFinancialYear(data, Today.Year - 2);
            else
                return IsDateFallsInCurrentFinancialYear(data, Today.Year - 1);
        }

        /// <summary>
        /// Calculates age(in Years) for the given date
        /// </summary>
        /// <param name="dateOfBirth">date of birth</param>
        /// <returns></returns>
        public static int GetAge(DateTime dateOfBirth)
        {
            int YearsPassed = Today.Year - dateOfBirth.Year;
            if (Today.Month < dateOfBirth.Month ||
                (Today.Month == dateOfBirth.Month && Today.Day < dateOfBirth.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }

        /// <summary>
        /// checks given date is less than 01/01/1900
        /// </summary>
        /// <param name="date">date</param>
        /// <returns></returns>
        public static bool IsMinimumDate(DateTime date)
        {
            return (date < Convert.ToDateTime("01-01-1900"));
        }

        #endregion

        #region IsNullOrEmpty

        /// <summary>
        /// Validate string is null or empty
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(string data)
        {
            return data == null ? true : string.IsNullOrEmpty(data.Trim());
        }

        public static bool IsNullOrEmpty(object data)
        {
            return data == null;
        }

        public static bool IsNullOrEmpty(DateTime data)
        {
            return data == DateTime.MinValue || data == null;
        }

        public static bool IsNullOrEmpty(long data)
        {
            return data == 0 || data == long.MinValue;
        }

        public static bool IsNullOrEmpty(long? data)
        {
            return data == 0 || data == long.MinValue || data == null;
        }

        public static bool IsNullOrEmpty(int data)
        {
            return data == 0 || data == int.MinValue;
        }

        public static bool IsNullOrEmpty(int? data)
        {
            return data == 0 || data == int.MinValue || data == null;
        }

        public static bool IsNullOrEmpty(double data)
        {
            return data == 0 || data == double.MinValue;
        }

        public static bool IsNullOrEmpty(double? data)
        {
            return data == 0 || data == double.MinValue || data == null;
        }

        #endregion

        #region Lexical

        /// <summary>
        /// Validate PIN pattern
        /// </summary>
        /// <param name="data">Data to validate</param>
        /// <returns></returns>
        public static bool IsPinCode(string data)
        {
            return IsNullOrEmpty(data) ? false : data.Trim() == string.Empty ? true : new Regex(@"^[1-9]{1}[0-9]{5}$").IsMatch(data.Trim());
        }

        /// <summary>
        /// Validate mobile number pattern
        /// </summary>
        /// <param name="value">Data to validate</param>
        /// <returns></returns>
        public static bool IsMobileNo(string value)
        {
            //ToDo : Below condition for validating ISD code needs to be corrected later 
            if (value.Contains("+91"))
            {
                String ISD = value.Substring(1, value.IndexOf("-")-1);

                if (!ValidationRule.IsInteger(ISD) || ISD.Length > 4)
                    return false;
                else 
                    value = value.Substring(value.IndexOf("-") + 1);
            }

            return IsNullOrEmpty(value) ? false : value.Trim() == string.Empty ? true : new Regex(@"^[0-9]{10,12}$").IsMatch(value.Trim());
        }

        /// <summary>
        /// Validate telephone number pattern
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static bool IsTelephoneNumber(string value, int minimum, int maximum)
        {
            //ToDo : Below condition for validating ISD code needs to be corrected later 
            if (value.Contains("+91"))
            {
                String ISD = value.Substring(1, value.IndexOf("-") - 1);

                if (!ValidationRule.IsInteger(ISD) || ISD.Length > 4)
                    return false;
                else
                    value = value.Substring(value.IndexOf("-") + 1);
            }

            return IsNullOrEmpty(value) ? false : new Regex(@"^[0-9\-]{" + minimum.ToString() + "," + maximum.ToString() + "}$").IsMatch(value.Trim());
        }

        /// <summary>
        /// Validate telephone number pattern
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsTelephoneNumber(string value)
        {
            return IsTelephoneNumber(value, 8, 12);
        }

        /// <summary>
        /// Validate FAX number pattern
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFaxNumber(string value)
        {
            return IsTelephoneNumber(value, 8, 12);
        }


        public static bool IsPANNumber(string value, PanType type, string lastName)
        {
            string fourthCharacter = string.Empty;
            string fifthCharacter = "a-zA-Z";

            if ((type & PanType.Any) == PanType.Any)
                fourthCharacter = "a-zA-Z";
            else
            {
                if ((type & PanType.Individual) == PanType.Individual)
                    fourthCharacter += "pP";
                if ((type & PanType.HUF) == PanType.HUF)
                    fourthCharacter += "hH";
                if ((type & PanType.Company) == PanType.Company)
                    fourthCharacter += "cC";
                if ((type & PanType.PartnershipFirm) == PanType.PartnershipFirm)
                    fourthCharacter += "fF";
                if ((type & PanType.AOP) == PanType.AOP)
                    fourthCharacter += "aA";
                if ((type & PanType.AOPTrust) == PanType.AOPTrust)
                    fourthCharacter += "tT";
                if ((type & PanType.BOI) == PanType.BOI)
                    fourthCharacter += "bB";
                if ((type & PanType.LocalAuthority) == PanType.LocalAuthority)
                    fourthCharacter += "lL";
                if ((type & PanType.ArtificialJuridicalPerson) == PanType.ArtificialJuridicalPerson)
                    fourthCharacter += "jJ";
                if ((type & PanType.LimitedLiabilityPartnership) == PanType.LimitedLiabilityPartnership)
                    fourthCharacter += "fFcC";
            }

            if (!ValidationRule.IsNullOrEmpty(lastName))
                fifthCharacter = lastName[0].ToString().ToLower() + lastName[0].ToString().ToUpper();

            return IsNullOrEmpty(value) ? false :
                new Regex(@"^[a-zA-Z]{3}[" + fourthCharacter + "]{1}[" + fifthCharacter + "]{1}[0-9]{4}[a-zA-Z]{1}$").IsMatch(value.Trim());
        }

        public static bool IsPANNumber(string value, PanType type)
        {
            return IsPANNumber(value, type, null);
        }

        public static bool IsPANNumber(string value, string lastName)
        {
            return IsPANNumber(value, PanType.Any, lastName);
        }

        /// <summary>
        /// Validate PAN pattern
        /// </summary>
        /// <param name="value">Data to validate</param>
        /// <returns></returns>
        public static bool IsPANNumber(string value)
        {
            return IsPANNumber(value, PanType.Any, null);
        }

        /// <summary>
        /// Validate TAN pattern
        /// </summary>
        /// <param name="value">Data to validate</param>
        /// <returns></returns>
        public static bool IsTANNumber(string value)
        {
            return IsNullOrEmpty(value) ? false : new Regex(@"^[a-zA-Z]{4}[0-9]{5}[a-zA-Z]{1}$").IsMatch(value.Trim());
        }

        /// <summary>
        /// Validate STC pattern
        /// </summary>
        /// <param name="value">Data to validate</param>
        /// <returns></returns>
        public static bool IsSTCNumber(string value)
        {
            return IsNullOrEmpty(value) ? false : new Regex(@"^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[sS]{1}[tT]{1}[0-9]{3}$").IsMatch(value.Trim());
        }

        /// <summary>
        /// Validate Email pattern
        /// </summary>
        /// <param name="value">Data to validate</param>
        /// <returns></returns>
        public static bool IsEmailId(string value)
        {

            return IsNullOrEmpty(value) ? false : new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$").IsMatch(value.Trim());

        }

        // <summary>
        /// Validate URL
        /// </summary>
        /// <param name="value">Data to validate</param>
        /// <returns></returns>
        public static bool IsUrlValid(string value)
        {

            return IsNullOrEmpty(value) ? false : new Regex(@"(((ht|f)tp(s?):\/\/)|(www\.[^ \[\]\(\)\n\r\t]+)|(([012]?[0-9]{1,2}\.){3}[012]?[0-9]{1,2})\/)([^ \[\]\(\),;&quot;'&lt;&gt;\n\r\t]+)([^\. \[\]\(\),;&quot;'&lt;&gt;\n\r\t])|(([012]?[0-9]{1,2}\.){3}[012]?[0-9]{1,2})").IsMatch(value.Trim());
        }


        /// <summary>
        /// Validate STD Code
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsSTDCode(string value)
        {
            if (value.Trim().Length < 3)
                return false;
            else if (!(new Regex(@"^[0-9]*$").IsMatch(value.Trim())))
                return false;
            
            return true;
        }


        #endregion

        public static bool IsDouble(String data)
        {
            try
            {
                Convert.ToDouble(data);
            }
            catch{
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Type of the Pan for the 4th Character
    /// Any - will accept any character,
    /// Individual/Personal - will accept only 'P' or 'p' character,
    /// Hindu Undivided Family (HUF) -will accept only 'H' or 'h' character
    /// Company - will accept only 'C' or 'c' character,
    /// Partnership Firm - 'F' or 'f' character
    /// Association of Persons, Co-operative Society or Co-operative Bank - 'A' or 'a' character
    /// Association of Persons (Trust) - will accept only 'T' or 't' character
    /// Body of Individuals BOI - will accept only 'B' or 'b' character,
    /// Local Authority - will accept only 'L' or 'l' character,
    /// Artificial Juridical Person - will accept only 'J' or 'j' character
    /// Limited Liability Partnership  - will accept only 'F' or 'f' or 'C' or 'c' character
    /// </summary>
    public enum PanType
    {
        Any = 1,
        Individual = 2,
        HUF = 4,
        Company = 8,
        PartnershipFirm = 16,
        AOP = 32,
        AOPTrust = 64,
        BOI = 128,
        LocalAuthority = 256,
        ArtificialJuridicalPerson = 512,
        LimitedLiabilityPartnership = 1024
    }

}

