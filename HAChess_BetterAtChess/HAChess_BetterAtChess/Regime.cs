using System.Collections.Generic;
namespace HAChess_BetterAtChess
{
    public class Regime
    {
        public static List<string> names = new List<string>() { "Thi đấu", "Tiêu chuẩn", "Cờ chớp", "Cờ siêu chớp" };
        public static List<Regime> regimes = new List<Regime>() {
            new Regime(0, 60, 0),
            new Regime(1, 30, 0),
            new Regime(1, 10, 10),
            new Regime(1, 10, 0),
            new Regime(2, 5, 0),
            new Regime(2, 3, 5),
            new Regime(2, 3, 0),
            new Regime(3, 1, 5),
        };
        public int indexName;
        public int time;
        public int time_bonus;

        public Regime(int indexName, int time, int time_bonus)
        {
            this.indexName = indexName;
            this.time = time;
            this.time_bonus = time_bonus;
        }

        public override string ToString()
        {
            if (time_bonus == 0)
            {
                return names[indexName] + " | " + time + " phút";
            }
            return names[indexName] + " | " + time + " phút + " + time_bonus + " giây";
        }

        public string ToShortString()
        {
            if (time_bonus == 0)
            {
                return time + " phút";
            }
            return time + " | " + time_bonus;
        }

        public string getTime()
        {
            return Time.convertRealTimeToStr(time * 60);
        }

        public static int getIndexRegime(int indexName, int time, int time_bonus)
        {
            for (int i = 0; i < regimes.Count; i++)
            {
                if (regimes[i].indexName == indexName && regimes[i].time == time && regimes[i].time_bonus == time_bonus)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
