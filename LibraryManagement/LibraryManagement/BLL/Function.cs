using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class Function
    {
        public string Date_Now()
        {
            string datetime = DateTime.Now.ToString();
            if (datetime.Contains("CH") || datetime.Contains("SA"))
            {
                datetime = datetime.Replace("CH", "PM");
                datetime = datetime.Replace("SA", "AM");
                string[] arrListStr = datetime.Split(' ');
                string date = arrListStr[0];
                string time = arrListStr[1];
                string pm = arrListStr[2];

                string[] arrListStr2 = date.Split('/');

                string dd = arrListStr2[0];
                string mm = arrListStr2[1];
                string yyyy = arrListStr2[2];

                datetime = mm + "/" + dd + "/" + yyyy + " " + time + " " + pm;
            }
            return datetime;
        }

        public string Date_Now_ToLimitTime()
        {
            string datetime = DateTime.Now.ToString();
            string DateNow;
            if (datetime.Contains("CH") || datetime.Contains("SA"))
            {
                DateNow = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0')
                + "/" + DateTime.Now.Year.ToString();
            }
            else
            {
                DateNow = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Day.ToString().PadLeft(2, '0')
                + "/" + DateTime.Now.Year.ToString();
            }
            return DateNow;
        }

        public bool ExceedDate(string DateInput)
        {
            //DateInput = SaveDate(DateInput);
            DateTime Date_input = Convert.ToDateTime(DateInput);
            string datetime = DateTime.Now.ToString();
            DateTime Date_now;
            if (datetime.Contains("CH") || datetime.Contains("SA"))
            {
                string DateNow = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0')
                + "/" + DateTime.Now.Year.ToString();
                Date_now = Convert.ToDateTime(DateNow);
            }
            else
            {
                string DateNow = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Day.ToString().PadLeft(2, '0')
                + "/" + DateTime.Now.Year.ToString();
                Date_now = Convert.ToDateTime(DateNow);
            }

            if (Date_input > Date_now) return false;
            else return true;
        }

        public string Date_Now_Return()
        {
            string datetime = DateTime.Now.ToString();
            string DateNow_Return;
            if (datetime.Contains("CH") || datetime.Contains("SA"))
            {
                DateNow_Return = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0')
                + "/" + DateTime.Now.Year.ToString();
            }
            else
            {
                DateNow_Return = DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Day.ToString().PadLeft(2, '0')
                + "/" + DateTime.Now.Year.ToString();
            }
            return DateNow_Return;
        }

        public string ShowDate(string dateTime)
        {
            string[] arrListStr = dateTime.Split(' ');
            string date = arrListStr[0];
            return FullDayMonth(date);
        }

        public string FullDayMonth(string Date)
        {
            if (Date != "")
            {
                string[] arrListStr = Date.Split('/');
                string one = arrListStr[0];
                string two = arrListStr[1];
                string three = arrListStr[2];
                if (one.Length == 1)
                    one = "0" + one;
                if (two.Length == 1)
                    two = "0" + two;
                return one + "/" + two + "/" + three;
            }
            else { return ""; }
        }
        public bool CheckDate(string Date)
        {
            string datetime = DateTime.Now.ToString();

            if (datetime.Contains("CH") || datetime.Contains("SA"))
            {
                //try
                //{
                DateTime fromDateValue;
                var formats = new[] { "dd/MM/yyyy" };
                return DateTime.TryParseExact(FullDayMonth(Date), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue);
                //}
                //catch { return false; }
            }
            else
            {
                try
                {
                    DateTime fromDateValue;
                    var formats = new[] { "MM/dd/yyyy" };
                    return DateTime.TryParseExact(FullDayMonth(Date), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue);
                }
                catch { return false; }
            }
        }

        public string SaveDate(string Date)
        {
            string datetime = DateTime.Now.ToString();

            if (datetime.Contains("CH") || datetime.Contains("SA"))
            {
                string[] arrListStr = Date.Split('/');
                string dd = arrListStr[0];
                string mm = arrListStr[1];
                string yyyy = arrListStr[2];
                Date = mm + "/" + dd + "/" + yyyy;
            }
            return Date;
        }
        public bool hasSpecialChar(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`1234567890-=[]\{}|;':,./<>?";
            foreach (char item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        public bool CheckPhone(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`qwertyuiopasdfghjklzxcvbnm-=[]{}|\;':,./<>?";
            foreach (char item in specialChar)
            {
                if (input.Contains(item)) return true;
            }
            return false;
        }
        public bool CheckEmail(string input)
        {
            string specialChar = @"@gmail.com";
            if (input.Contains(specialChar)) return true;

            return false;
        }
        public int CheckInt(string txt)
        {
            if (txt != "")
                return Int32.Parse(txt);
            else return 0;
        }
        public int GetMonth(string date)
        {
            string[] str = date.Split(' ');
            string[] str1 = str[0].Split('/');
            if (date.Contains("CH") || date.Contains("SA"))
            {
                return int.Parse(str1[1]);
            }
            return int.Parse(str1[0]);
        }
        public int GetYear(string date)
        {
            string[] str = date.Split(' ');
            string[] str1 = str[0].Split('/');
            return int.Parse(str1[2]);
        }
        public bool CheckEmail2(string email)
        {
            if (email.Contains("@")) return true;
            return false;
        }
        public bool CheckPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, "^[0-9]{9,11}$");
        }
        public bool CheckNumberBook(string number)
        {
            return Regex.IsMatch(number, "^[0-9]{1,11}$");
        }

        public bool CheckName(string un)
        {
            return Regex.IsMatch(un, @"^[A-ZÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ][a-zàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]*(?:[ ][A-ZÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ][a-zàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]*)*$");
        }
    }
}
