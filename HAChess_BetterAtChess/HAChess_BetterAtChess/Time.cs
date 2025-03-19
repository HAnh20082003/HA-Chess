namespace HAChess_BetterAtChess
{
    public class Time
    {
        public int hours;
        public int minutes;
        public int seconds;
        public Time()
        {

        }

        public Time(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public static Time convertStrTimeRealTime(string strTime)
        {
            Time time = new Time();
            string[] splitTime = strTime.Split(':');
            if (splitTime.Length == 1)
            {
                time.hours = 0;
                time.minutes = 0;
                time.seconds = int.Parse(splitTime[0]);
            }
            else if (splitTime.Length == 2)
            {
                time.hours = 0;
                time.minutes = int.Parse(splitTime[0]);
                time.seconds = int.Parse(splitTime[1]);
            }
            else
            {
                time.hours = int.Parse(splitTime[0]);
                time.minutes = int.Parse(splitTime[1]);
                time.seconds = int.Parse(splitTime[2]);
            }
            return time;
        }

        public static string convertRealTimeToStr(int timeSecond)
        {
            int hour = timeSecond / 3600;
            int minute = timeSecond % 3600;
            int tmp = minute % 60;
            minute /= 60;
            int second = tmp;
            string result = General.getDecimal(second, 2);
            if (hour != 0)
            {
                result = General.getDecimal(minute, 2) + ":" + result;
                if (hour < 10)
                {
                    result = hour + ":" + result;
                }
                else
                {
                    result = General.getDecimal(hour, 2) + ":" + result;
                }
            }
            else
            {
                if (minute < 10)
                {
                    result = minute + ":" + result;
                }
                else
                {
                    result = General.getDecimal(minute, 2) + ":" + result;
                }
            }
            return result;
        }

        public static string convertRealTimeToStr(Time time)
        {
            string result = General.getDecimal(time.seconds, 2);
            if (time.hours != 0)
            {
                result = General.getDecimal(time.minutes, 2) + ":" + result;
                if (time.hours < 10)
                {
                    result = time.hours + ":" + result;
                }
                else
                {
                    result = General.getDecimal(time.hours, 2) + ":" + result;
                }
            }
            else
            {
                if (time.minutes < 10)
                {
                    result = time.minutes + ":" + result;
                }
                else
                {
                    result = General.getDecimal(time.minutes, 2) + ":" + result;
                }
            }
            return result;
        }

        public static Time getNextSeconds(Time time)
        {
            if (time.seconds == 59)
            {
                time.seconds = 0;
                if (time.minutes == 59)
                {
                    time.minutes = 0;
                    time.hours++;
                }
                else
                {
                    time.minutes++;
                }
            }
            else
            {
                time.seconds++;
            }
            return time;
        }
        public static Time getPrevSeconds(Time time)
        {
            if (time.seconds == 0)
            {
                time.seconds = 59;
                if (time.minutes == 0)
                {
                    time.minutes = 59;
                    time.hours--;
                }
                else
                {
                    time.minutes--;
                }
            }
            else
            {
                time.seconds--;
            }
            return time;
        }

        public int getSeconds()
        {
            return hours * 3600 + minutes * 60 + seconds;
        }
    }
}
