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





