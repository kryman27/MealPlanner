namespace FileParser.Strategies
{
    public class TxtStrategy : IParseStrategies
    {
        public List<ProductDataModel> Execute(string filePath)
        {
            throw new Exception("Currently .txt file can't be parsed");
        }
    }
}
