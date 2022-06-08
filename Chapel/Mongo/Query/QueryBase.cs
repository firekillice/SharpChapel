using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.Query
{
    internal class QueryBase
    {
        protected string connectionString;
        protected MongoClient? client;
        private List<string> includes = new List<string> { };
        private List<string> excludes = new List<string> { };

        public QueryBase(string connectionString) => this.connectionString = connectionString;

        /// <summary>
        /// 获取连接客户端
        /// </summary>
        /// <returns></returns>
        public MongoClient GetClient()
        {
            if (this.client == null)
            {
                try
                {
                    this.client = new MongoClient(this.connectionString);
                    return this.client;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            else
            {
                return this.client;
            }
        }
            
        /// <summary>
        /// 列出所有数据库
        /// </summary>
        /// <returns></returns>
        public List<BsonDocument> ListDataBase()
        {
            return this.GetClient().ListDatabases().ToList();
        }

        /// <summary>
        /// 选取一个集合
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public IMongoCollection<BsonDocument> PickCollection(string dbName, string collectionName)
        {
            try
            {
                return this.GetClient().GetDatabase(dbName).GetCollection<BsonDocument>(collectionName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// 适应过滤器
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IAsyncCursor<BsonDocument> Find(
            IMongoCollection<BsonDocument> collection, 
            FilterDefinition<BsonDocument> filter,
            ProjectionDefinition<BsonDocument> projection
            )
        {
            return collection.Find(filter).Project(projection).ToCursor();
        }

        /// <summary>
        /// 设置包含式投射
        /// </summary>
        /// <param name="includes"></param>
        public void SetIncludeProjection(List<string> includes)
        {
            this.includes = includes;
        }

        /// <summary>
        /// 设置排斥式投射
        /// </summary>
        /// <param name="exccludes"></param>
        public void SetExcludeProjection(List<string> excludes)
        {
            this.excludes = excludes;
        }

    }
}
