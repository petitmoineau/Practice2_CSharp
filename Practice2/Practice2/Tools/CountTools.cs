using System;
using System.Threading;
using System.Threading.Tasks;

namespace Practice2.Tools
{
    public class CountTools
    {
        private static DateTime currentDate;
        private static DateTime birthDate;
        public static bool isBirthday;
        public static int age;
        public static string chineseSign;
        public static string sunSign;

        //i tried to do this:
        /*public static void CountIsBirthday(DateTime _currentDate, DateTime _birthDate, out bool isBirthday)
                {
                    currentDate = _currentDate;
                    birthDate = _birthDate;
                    isBirthday = CountIsBirthdayAsync().Result;

                }
                private static bool CountIsBirthday()
                {
                    return ((currentDate.Month - birthDate.Month) == 0) && ((currentDate.Day - birthDate.Day) == 0);
                }

                private static async Task<bool> CountIsBirthdayAsync()
                {
                    var isBirthday = await Task.Run(() => CountIsBirthday());
                    return isBirthday;
                }*/
        //and the program runs infinitely:(
        public static async Task CountAll(DateTime _currentDate, DateTime _birthDate)
        {
            
            currentDate = _currentDate;
            birthDate = _birthDate;
            Task task1 = CountIsBirthdayAsync();//the way you showed it on lecture didn`t work out so this is the only option i found to make it work async :(
            Task task2 = CountAgeAsync();//sorry(
            Task task4 = CountSunSignAsync();
            Task task3 = CountChineseSignAsync();
            

            await task1;
            await task2;
            await task3;
            await task4;

        }
        private static void CountIsBirthday()
        {
            isBirthday = ((currentDate.Month - birthDate.Month) == 0) && ((currentDate.Day - birthDate.Day) == 0);
        }

        private static async Task CountIsBirthdayAsync()
        {
            await Task.Run(() => CountIsBirthday());
        }

        private static void CountAge()
        {
            age = ((currentDate.Month - birthDate.Month) < 0) ? currentDate.Year - birthDate.Year - 1 :
                ((currentDate.Month == birthDate.Month) ? ((currentDate.Day - birthDate.Day) < 0 ? (currentDate.Year - birthDate.Year - 1) : (currentDate.Year - birthDate.Year)) : (currentDate.Year - birthDate.Year));
        }

        private static async Task CountAgeAsync()
        {
            await Task.Run(() => CountAge());
        }
        private static void CountChineseSign()
        {
            switch ((birthDate.Year - 4) % 12)
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
        }

        private static async Task CountChineseSignAsync()
        {
            await Task.Run(() => CountChineseSign());
        }

        private static void CountSunSign()
        {
            switch (birthDate.Month)
            {
                case 1:
                    if (birthDate.Day < 21)
                        sunSign = "Capricorn";
                    else
                        sunSign = "Aquarius";
                    break;
                case 2:
                    if (birthDate.Day < 20)
                        sunSign = "Aquarius";
                    else
                        sunSign = "Pisces";
                    break;
                case 3:
                    if (birthDate.Day < 21)
                        sunSign = "Pisces";
                    else
                        sunSign = "Aries";
                    break;
                case 4:
                    if (birthDate.Day < 21)
                        sunSign = "Aries";
                    else
                        sunSign = "Taurus";
                    break;
                case 5:
                    if (birthDate.Day < 22)
                        sunSign = "Taurus";
                    else
                        sunSign = "Gemini";
                    break;
                case 6:
                    if (birthDate.Day < 22)
                        sunSign = "Gemini";
                    else
                        sunSign = "Cancer";
                    break;
                case 7:
                    if (birthDate.Day < 23)
                        sunSign = "Cancer";
                    else
                        sunSign = "Leo";
                    break;
                case 8:
                    if (birthDate.Day < 22)
                        sunSign = "Leo";
                    else
                        sunSign = "Virgo";
                    break;
                case 9:
                    if (birthDate.Day < 24)
                        sunSign = "Virgo";
                    else
                        sunSign = "Libra";
                    break;
                case 10:
                    if (birthDate.Day < 24)
                        sunSign = "Libra";
                    else
                        sunSign = "Scorpio";
                    break;
                case 11:
                    if (birthDate.Day < 24)
                        sunSign = "Scorpio";
                    else
                        sunSign = "Sagittarius";
                    break;
                default:
                    if (birthDate.Day < 23)
                        sunSign = "Sagittarius";
                    else
                        sunSign = "Capricorn";
                    break;
                    
            }
        }

        private static async Task CountSunSignAsync()
        {
            await Task.Run(() => CountSunSign());
        }
    }
}
