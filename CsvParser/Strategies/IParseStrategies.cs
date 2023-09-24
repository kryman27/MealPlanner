namespace FileParser.Strategies
{
    public interface IParseStrategies
    {
        public List<ProductDataModel> Execute(string filePath);
    }
}
