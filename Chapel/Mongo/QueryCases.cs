using Mongo.Filter;
using Mongo.Query;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo
{
    internal class QueryCases
    {
        public static void QueryLeagueMatchEnd(long pid, string start, string end)
        {
            var filePath = "./"
                + System.Reflection.MethodBase.GetCurrentMethod().Name
                + "-" + pid.ToString()
                + "-" + start
                + "-" + end
                + ".csv";
            QueryCases.ClearLogFile(filePath);

            var qb = new YakyuBiBehaviorQuery("mongodb://reader:u123123@104.215.194.129:20001");
            qb.SetRange(DateTime.Parse(start), DateTime.Parse(end));
            while (true)
            {
                var dbName = qb.GetNextDbName();
                if (dbName == "")
                {
                    break;
                }
                Console.WriteLine("handling db " + dbName);

                var collection = qb.PickCollection(dbName, "league_match");
                var filter = new BaseFilter();
                filter.Equal("player.Id", pid);
                var projection = Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("logTime")
                    .Include("player.Id")
                    .Include("details.prviousLeagueState")
                    .Include("details.currentLeagueState");
                var cursor = qb.Find(collection, filter.GetFilter(), projection);

                foreach (var document in cursor.ToEnumerable())
                {
                    var details = document.GetElement("details").Value.AsBsonDocument;
                    var player = document.GetElement("player").Value.AsBsonDocument;

                    var timeString = document.GetElement("logTime").Value.ToString();
                    var content = QueryCases.GetDateTime(int.Parse(timeString)).ToString("yyyy-MM-dd hh:mm:ss")
                        + "\t" + timeString
                        + "\t" + player.GetElement("Id").Value.ToString()
                        + "\t" + details.GetElement("prviousLeagueState").Value.ToString()
                        + "\t" + details.GetElement("currentLeagueState").Value.ToString() + "\n";
                    QueryCases.WriteFile(filePath, content);
                }
            }
        }


        public static void QueryLeagueMatchStart(long pid, string start, string end)
        {
            var filePath = "./"
                + System.Reflection.MethodBase.GetCurrentMethod().Name
                + "-" + pid.ToString()
                + "-" + start
                + "-" + end
                + ".csv";
            QueryCases.ClearLogFile(filePath);

            var qb = new YakyuBiBehaviorQuery("mongodb://reader:u123123@104.215.194.129:20001");
            qb.SetRange(DateTime.Parse(start), DateTime.Parse(end));
            while (true)
            {
                var dbName = qb.GetNextDbName();
                if (dbName == "")
                {
                    break;
                }
                Console.WriteLine("handling db " + dbName);

                var collection = qb.PickCollection(dbName, "league_match_start");
                var filter = new BaseFilter();
                filter.Equal("player.Id", pid);
                var projection = Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("logTime")
                    .Include("player.Id")
                    .Include("details.currentLeagueState");
                var cursor = qb.Find(collection, filter.GetFilter(), projection);

                foreach (var document in cursor.ToEnumerable())
                {
                    var details = document.GetElement("details").Value.AsBsonDocument;
                    var player = document.GetElement("player").Value.AsBsonDocument;

                    var timeString = document.GetElement("logTime").Value.ToString();
                    var content = QueryCases.GetDateTime(int.Parse(timeString)).ToString("yyyy-MM-dd hh:mm:ss")
                        + "\t" + timeString
                        + "\t" + player.GetElement("Id").Value.ToString()
                        + "\t" + details.GetElement("currentLeagueState").Value.ToString() + "\n";
                    QueryCases.WriteFile(filePath, content);
                }
            }
        }

        public static void QueryLadderMatchStart(long pid, string start, string end)
        {
            var filePath = "./"
                + System.Reflection.MethodBase.GetCurrentMethod().Name
                + "-" + pid.ToString()
                + "-" + start
                + "-" + end
                + ".csv";
            QueryCases.ClearLogFile(filePath);

            var qb = new YakyuBiBehaviorQuery("mongodb://reader:u123123@104.215.194.129:20001");
            qb.SetRange(DateTime.Parse(start), DateTime.Parse(end));
            while (true)
            {
                var dbName = qb.GetNextDbName();
                if (dbName == "")
                {
                    break;
                }
                Console.WriteLine("handling db " + dbName);

                var collection = qb.PickCollection(dbName, "laddermatch_match_start");
                var filter = new BaseFilter();
                filter.Equal("player.Id", pid);
                var projection = Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("logTime")
                    .Include("player.Id")
                    .Include("details");
                var cursor = qb.Find(collection, filter.GetFilter(), projection);

                foreach (var document in cursor.ToEnumerable())
                {
                    var details = document.GetElement("details").Value.AsBsonDocument;
                    var player = document.GetElement("player").Value.AsBsonDocument;

                    var timeString = document.GetElement("logTime").Value.ToString();
                    var content = QueryCases.GetDateTime(int.Parse(timeString)).ToString("yyyy-MM-dd hh:mm:ss")
                        + "\t" + timeString
                        + "\t" + player.GetElement("Id").Value.ToString()
                        + "\t" + details.GetElement("isCasualMode").Value.ToString()
                        + "\t" + details.GetElement("opponentId").Value.ToString() + "\n";
                    QueryCases.WriteFile(filePath, content);
                }
            }
            var absPath = Directory.GetCurrentDirectory() + filePath;
            Console.WriteLine(absPath);
        }

        public static void QueryLadderMatchEnd(long pid, string start, string end)
        {
            var filePath = "./"
                + System.Reflection.MethodBase.GetCurrentMethod().Name
                + "-" + pid.ToString()
                + "-" + start
                + "-" + end
                + ".csv";
            QueryCases.ClearLogFile(filePath);

            var qb = new YakyuBiBehaviorQuery("mongodb://reader:u123123@104.215.194.129:20001");
            qb.SetRange(DateTime.Parse(start), DateTime.Parse(end));
            while (true)
            {
                var dbName = qb.GetNextDbName();
                if (dbName == "")
                {
                    break;
                }
                Console.WriteLine("handling db " + dbName);

                var collection = qb.PickCollection(dbName, "laddermatch_match_end");
                var filter = new BaseFilter();
                filter.Equal("player.Id", pid);
                var projection = Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("logTime")
                    .Include("player.Id")
                    .Include("details");
                var cursor = qb.Find(collection, filter.GetFilter(), projection);

                foreach (var document in cursor.ToEnumerable())
                {
                    var details = document.GetElement("details").Value.AsBsonDocument;
                    var player = document.GetElement("player").Value.AsBsonDocument;

                    var timeString = document.GetElement("logTime").Value.ToString();
                    var content = QueryCases.GetDateTime(int.Parse(timeString)).ToString("yyyy-MM-dd hh:mm:ss")
                        + "\t" + timeString
                        + "\t" + player.GetElement("Id").Value.ToString()
                        + "\t" + details.GetElement("isCasualMode").Value.ToString()
                        + "\t" + details.GetElement("currentScore").Value.ToString()
                        + "\t" + details.GetElement("playerScore").Value.ToString() + "\n";
                    QueryCases.WriteFile(filePath, content);
                }
            }
            var absPath = Directory.GetCurrentDirectory() + filePath;
            Console.WriteLine(absPath);
        }

        public static void QueryPvpCoreMatchEnd(long pid, string start, string end)
        {
            var filePath = "./"
                + System.Reflection.MethodBase.GetCurrentMethod().Name
                + "-" + pid.ToString()
                + "-" + start
                + "-" + end
                + ".csv";
            QueryCases.ClearLogFile(filePath);

            var qb = new YakyuBiBehaviorQuery("mongodb://reader:u123123@104.215.194.129:20001");
            qb.ChangePrefix();
            qb.SetRange(DateTime.Parse(start), DateTime.Parse(end));
            while (true)
            {
                var dbName = qb.GetNextDbName();
                if (dbName == "")
                {
                    break;
                }
                Console.WriteLine("handling db " + dbName);

                var collection = qb.PickCollection(dbName, "match_end");
                var filter = new BaseFilter();
                filter.Equal("player.Id", pid);
                filter.Equal("details.extra.matchRule", "pvp");
                var projection = Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("logTime")
                    .Include("player.Id")
                    .Include("details.extra.matchType");
                var cursor = qb.Find(collection, filter.GetFilter(), projection);

                foreach (var document in cursor.ToEnumerable())
                {
                    var details = document.GetElement("details").Value.AsBsonDocument;
                    var extra = details.GetElement("extra").Value.AsBsonDocument;
                    var player = document.GetElement("player").Value.AsBsonDocument;

                    var timeString = document.GetElement("logTime").Value.ToString();
                    var content = QueryCases.GetDateTime(int.Parse(timeString)).ToString("yyyy-MM-dd hh:mm:ss")
                        + "\t" + timeString
                        + "\t" + player.GetElement("Id").Value.ToString()
                        + "\t" + extra.GetElement("matchType").Value.ToString()
                        + "\n";
                    QueryCases.WriteFile(filePath, content);
                }
            }
            var absPath = Directory.GetCurrentDirectory() + filePath;
            Console.WriteLine(absPath);
        }

        public static void QueryArenaMatchEnd(long pid, long opponent, string start, string end)
        {
            var filePath = "./"
                + System.Reflection.MethodBase.GetCurrentMethod().Name
                + "-" + pid.ToString()
                + "-" + start
                + "-" + end
                + ".csv";
            QueryCases.ClearLogFile(filePath);

            var qb = new YakyuBiBehaviorQuery("mongodb://reader:u123123@104.215.194.129:20001");
            qb.SetRange(DateTime.Parse(start), DateTime.Parse(end));
            while (true)
            {
                var dbName = qb.GetNextDbName();
                if (dbName == "")
                {
                    break;
                }
                Console.WriteLine("handling db " + dbName);

                var collection = qb.PickCollection(dbName, "arena_match_end");
                var filter = new BaseFilter();
                filter.Equal("player.Id", pid);
                //filter.Equal("details.opponentId", opponent);
                var projection = Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("logTime")
                    .Include("player.Id")
                    .Include("details");
                var cursor = qb.Find(collection, filter.GetFilter(), projection);

                foreach (var document in cursor.ToEnumerable())
                {
                    var details = document.GetElement("details").Value.AsBsonDocument;
                    var player = document.GetElement("player").Value.AsBsonDocument;

                    var timeString = document.GetElement("logTime").Value.ToString();
                    var content = QueryCases.GetDateTime(int.Parse(timeString)).ToString("yyyy-MM-dd hh:mm:ss")
                        + "\t" + timeString
                        + "\t" + player.GetElement("Id").Value.ToString()
                        + "\t" + details.GetElement("opponentId").Value.ToString()
                        + "\t" + details.GetElement("matchResult").Value.ToString()
                        + "\t" + details.GetElement("matchWinStar").Value.ToString()
                        + "\t" + details.GetElement("matchOperateStar").Value.ToString() + "\n";
                    QueryCases.WriteFile(filePath, content);
                }
            }
            var absPath = Directory.GetCurrentDirectory() + filePath;
            Console.WriteLine(absPath);
        }

        public static void QueryActivityTakeReward(string start, string end)
        {
            var filePath = "./"
                + System.Reflection.MethodBase.GetCurrentMethod().Name
                + "-" + start
                + "-" + end
                + ".csv";
            QueryCases.ClearLogFile(filePath);

            var qb = new LuciferBiBehaviorQuery("mongodb://bi_ro:GnJefJfsVx@101.36.114.49:27017");
            qb.ChangePrefix();
            qb.SetRange(DateTime.Parse(start), DateTime.Parse(end));
            while (true)
            {
                var dbName = qb.GetNextDbName();
                if (dbName == "")
                {
                    break;
                }
                Console.WriteLine("handling db " + dbName);

                var collection = qb.PickCollection(dbName, "activity_take_reward");
                var filter = new BaseFilter();

                filter.Equal("details.ActivityType", "HolidaySign");
                filter.Equal("details.Reward.Days", 2);
                filter.Equal("details.Reward.Gift.0.Id", "ChaoYiWenMic");
                var projection = Builders<BsonDocument>.Projection.Exclude("_id")
                    .Include("logTime")
                    .Include("logDate")
                    .Include("player")
                    .Include("details.Reward");
                var cursor = qb.Find(collection, filter.GetFilter(), projection);

                foreach (var document in cursor.ToEnumerable())
                {
                    var details = document.GetElement("details").Value.AsBsonDocument;
                    var player = document.GetElement("player").Value.AsBsonDocument;
                    var reward = details.GetElement("Reward").Value.AsBsonDocument;
                    var gift = reward.GetElement("Gift").Value.AsBsonArray;
                    var firstGift = gift[0].AsBsonDocument;

                    var timeString = document.GetElement("logTime").Value.ToString();
                    var dateString = document.GetElement("logDate").Value.ToString();
                    var content = dateString + " " + timeString
                        + "\t" + player.GetElement("Id").Value.ToString()
                        + "\t" + player.GetElement("Name").Value.ToString()
                        + "\t" + player.GetElement("ZoneID").Value.ToString()
                        + "\t" + reward.GetElement("Days").Value.ToString()
                        + "\t" + firstGift.GetElement("Id").Value.ToString() + "\n";
                    QueryCases.WriteFile(filePath, content);
                }
            }
            var absPath = Directory.GetCurrentDirectory() + filePath;
            Console.WriteLine(absPath);
        }

        /// <summary>
        /// 转换时间戳
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        private static DateTime GetDateTime(int timeStamp)//时间戳Timestamp转换成日期
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = ((long)timeStamp * 10000000);
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime targetDt = dtStart.Add(toNow);
            return targetDt;
        }

        private static void ClearLogFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="contents"></param>
        private static void WriteFile(string filename, string contents)
        {
            File.AppendAllText(filename, contents);
        }

    }
}





