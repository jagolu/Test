using Catalog.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Src
{
    internal class FileParser
    {
        private readonly string _categoriesPath = string.Empty;
        private readonly string _productsPath = string.Empty;
        private const string _delimiter = ";";
        public List<Product> _products { get; set; } = new List<Product>();
        public List<Category> _categories { get; set; } = new List<Category>();

        public FileParser(string categoriesP, string productsP)
        {
            _categoriesPath = categoriesP;
            _productsPath = productsP;
        }

        public void parse() 
        {
            _products = parseFile<Product>(_productsPath);
            _categories = parseFile<Category>(_categoriesPath);
        }

        private List<T> parseFile<T>(string path)
        {
            List<T> csvParsed = new List<T>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                bool firstLine = true;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(_delimiter);
                while(!parser.EndOfData)
                {
                    List<string> fields = parser.ReadFields().ToList();
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    csvParsed.Add(parseToModel<T>(fields));
                }
            }

            return csvParsed;
        }

        private T parseToModel<T>(List<string> fields)
        {
            T result;
            switch (typeof(T))
            {
                case Type type when type==typeof(Category):
                    result = (T)(object)parseCategorie(fields);
                    break;
                case Type type when type == typeof(Product):
                    result = (T)(object)parseProduct(fields);
                    break;
                default:
                    result = (T)(object)parseCategorie(fields);
                    break;
            }

            return result;
        }

        private Category parseCategorie(List<string> fields)
        {
            return new Category()
            {
                Id = Int32.Parse(fields[0]),
                Name = fields[1],
                Description = fields[2]
            };
        }

        private Product parseProduct(List<string> fields)
        {
            return new Product()
            {
                Id = Int32.Parse(fields[0]),
                CategoryId = Int32.Parse(fields[1]),
                Name = fields[2],
                Price = double.Parse(fields[3])
            }; ;
        }
    }
}
