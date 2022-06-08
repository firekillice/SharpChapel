
namespace Mongo.Query
{
    internal class YakyuBiBehaviorQuery : QueryBase
    {
        private readonly string dbNamePrefix = "BQ-Behavior";
        private DateTime start = new DateTime();
        private DateTime end = new DateTime();
        private DateTime current = new DateTime();

        public YakyuBiBehaviorQuery(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 设置时间范围
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void SetRange(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
            this.current = this.start;
        }

        /// <summary>
        /// 获取下一个数据库
        /// </summary>
        /// <returns></returns>
        public string GetNextDbName()
        {
            if (this.current <= this.end)
            {
                var name = this.dbNamePrefix + "-" + this.current.ToString("yyyyMMdd");
                this.current = this.current.AddDays(1);
                return name;
            }
            return "";
        }
    }
}
