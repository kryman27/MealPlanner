using CsvParser;

namespace FileParser
{
    public class FileParser
    {
        public static void Main()
        {
            List<ProductDataModel> entries = new List<ProductDataModel>();
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DbSourceFiles");
            var directoryChecker = new DirectoryChecker(directoryPath);
            directoryChecker.CheckFilesInDirectory();
            entries.AddRange(directoryChecker.ExecuteStrategy());
            string dbQueryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DbPreparedQueries", new string("query_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt"));
            var queryPreparer = new QueryPreparer();
            queryPreparer.PrepareQuery(entries, dbQueryPath);
            File.Delete(directoryChecker.InputFilePath);
        }
    }
}
