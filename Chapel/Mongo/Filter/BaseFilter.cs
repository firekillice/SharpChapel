using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.Filter
{
    internal class BaseFilter
    {
        FilterDefinition<BsonDocument> filter = new BsonDocument();

        public BaseFilter()
        {

        }

        /// <summary>
        /// 获取过滤器
        /// </summary>
        /// <returns></returns>
        public FilterDefinition<BsonDocument> GetFilter()
        {
            return this.filter;
        }

        /// <summary>
        /// 相等选择子
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="val"></param>
        public void Equal<CompareType>(string selector, CompareType val)
        {
            this.filter = Builders<BsonDocument>.Filter.Eq(selector, val);
        }

        /// <summary>
        /// 小于
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="val"></param>
        public void Lt<CompareType>(string selector, CompareType val)
        {
            this.filter = Builders<BsonDocument>.Filter.Lt(selector, val);
        }

        /// <summary>
        /// 小于等于
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="val"></param>
        public void Lte<CompareType>(string selector, CompareType val)
        {
            this.filter = Builders<BsonDocument>.Filter.Lte(selector, val);
        }

        /// <summary>
        /// 大于
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="val"></param>
        public void Gt<CompareType>(string selector, CompareType val)
        {
            this.filter = Builders<BsonDocument>.Filter.Gt(selector, val);
        }

        /// <summary>
        /// 大于等于
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="val"></param>
        public void Gte<CompareType>(string selector, CompareType val)
        {
            this.filter = Builders<BsonDocument>.Filter.Gte(selector, val);
        }
    }
}
