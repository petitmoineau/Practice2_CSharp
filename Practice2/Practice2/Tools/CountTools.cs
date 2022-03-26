using System;
using System.Threading;

namespace Practice2.Tools
{
    public class CountTools
    {
        public static bool CountIsBirthday(DateTime currentDate, DateTime birthDate)
        {
            return ((currentDate.Month - birthDate.Month) == 0) && ((currentDate.Day - birthDate.Day) == 0);
        }
        public static void CountAge(DateTime currentDate, DateTime birthDate, out int age)
        {
            Console.WriteLine("CountAge func started");
            age = ((currentDate.Month - birthDate.Month) < 0) ? currentDate.Year - birthDate.Year - 1 :
               ((currentDate.Day - birthDate.Day) < 0 ? (currentDate.Year - birthDate.Year - 1) : (currentDate.Year - birthDate.Year));
           // Thread.Sleep(10000);
            Console.WriteLine("CountAge func ended");
        }
        public static void CountChineseSign(DateTime dt, out string chineseSign)
        {
            Console.WriteLine("CountChineseSign func started");
            switch ((dt.Year - 4) % 12)
            {
                case 0:
                    chineseSign = "Rat";
                    break;
                case 1:
                    chineseSign = "Ox";
                    break;
                case 2:
                    chineseSign = "Tiger";
                    break;
                case 3:
                    chineseSign = "Rabbit";
                    break;
                case 4:
                    chineseSign = "Dragon";
                    break;
                case 5:
                    chineseSign = "Snake";
                    break;
                case 6:
                    chineseSign = "Horse";
                    break;
                case 7:
                    chineseSign = "Goat";
                    break;
                case 8:
                    chineseSign = "Monkey";
                    break;
                case 9:
                    chineseSign = "Rooster";
                    break;
                case 10:
                    chineseSign = "Dog";
                    break;
                default:
                    chineseSign = "Pig";
                    break;

                    
            }
            Console.WriteLine("CountChineseSign func ended");
        }

        public static void CountSunSign(DateTime dt, out string sunSign)
        {
            Console.WriteLine("CountSunSign func started");
            switch (dt.Month)
            {
                case 1:
                    if (dt.Day < 21)
                        sunSign = "Capricorn";
                    else
                        sunSign = "Aquarius";
                    break;
                case 2:
                    if (dt.Day < 20)
                        sunSign = "Aquarius";
                    else
                        sunSign = "Pisces";
                    break;
                case 3:
                    if (dt.Day < 21)
                        sunSign = "Pisces";
                    else
                        sunSign = "Aries";
                    break;
                case 4:
                    if (dt.Day < 21)
                        sunSign = "Aries";
                    else
                        sunSign = "Taurus";
                    break;
                case 5:
                    if (dt.Day < 22)
                        sunSign = "Taurus";
                    else
                        sunSign = "Gemini";
                    break;
                case 6:
                    if (dt.Day < 22)
                        sunSign = "Gemini";
                    else
                        sunSign = "Cancer";
                    break;
                case 7:
                    if (dt.Day < 23)
                        sunSign = "Cancer";
                    else
                        sunSign = "Leo";
                    break;
                case 8:
                    if (dt.Day < 22)
                        sunSign = "Leo";
                    else
                        sunSign = "Virgo";
                    break;
                case 9:
                    if (dt.Day < 24)
                        sunSign = "Virgo";
                    else
                        sunSign = "Libra";
                    break;
                case 10:
                    if (dt.Day < 24)
                        sunSign = "Libra";
                    else
                        sunSign = "Scorpio";
                    break;
                case 11:
                    if (dt.Day < 24)
                        sunSign = "Scorpio";
                    else
                        sunSign = "Sagittarius";
                    break;
                default:
                    if (dt.Day < 23)
                        sunSign = "Sagittarius";
                    else
                        sunSign = "Capricorn";
                    break;
                    
            }
            //Thread.Sleep(400);
            Console.WriteLine("CountSunSign func ended");
        }
    }
}
