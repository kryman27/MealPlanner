using CsvParser.Strategies;
using FileParser;
using FileParser.Strategies;

namespace CsvParser
{
    public class DirectoryChecker
    {
        public IParseStrategies strategy;
        public string Directory { get; set; }
        public string InputFileName { get; set; }
        public string InputFilePath { get; set; }

        public DirectoryChecker(string directory)
        {
            Directory = directory;
        }

        public void CheckFilesInDirectory()
        {
            try
            {
                if (System.IO.Directory.Exists(Directory))
                {
                    var fileLocation = System.IO.Directory.GetFiles(Directory).FirstOrDefault();
                    var fileName = Path.GetFileName(fileLocation);
                    var fileExtension = Path.GetExtension(Path.Combine(Directory, fileName));
                    InputFileName = fileName;
                    InputFilePath = Path.Combine(Directory, fileName);
                    strategy = fileExtension switch
                    {
                        ".csv" => new CsvStrategy(),
                        ".json" => new JsonStrategy(),
                        ".txt" => new TxtStrategy(),
                        _ => throw new Exception("Unhandled file format")
                    };
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public List<ProductDataModel> ExecuteStrategy()
        {
            return strategy.Execute(InputFilePath);
        }
    }
}
