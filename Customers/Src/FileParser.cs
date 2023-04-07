using Microsoft.VisualBasic.FileIO;

namespace Customers.Src
{
    internal class FileParser
    {
        private readonly string _customersPath = string.Empty;
        private const string _delimiter = ";";
        public List<Model.Customer> _customers { get; set; } = new List<Model.Customer>();

        public FileParser(string categoriesP)
        {
            _customersPath = categoriesP;
        }

        public void parse()
        {
            _customers = parseFile<Model.Customer>(_customersPath);
        }

        private List<Model.Customer> parseFile<T>(string path)
        {
            List<Model.Customer> csvParsed = new List<Model.Customer>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                bool firstLine = true;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(_delimiter);
                while (!parser.EndOfData)
                {
                    List<string> fields = parser.ReadFields().ToList();
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    csvParsed.Add(parseCustomer(fields));
                }
            }

            return csvParsed;
        }

        private Model.Customer parseCustomer(List<string> fields)
        {
            return new Model.Customer()
            {
                Id = fields[0],
                Name = fields[1],
                Address = fields[2],
                City = fields[3],
                Country = fields[4],
                PostalCode = fields[5],
                Phone = fields[6]
            };
        }
    }
}
