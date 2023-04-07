using Catalog.Model;
using System.Text.Json;
using System.Xml.Serialization;

namespace Catalog.Src
{
    public class CatalogGenerator
    {
        private FileParser _fileParser;
        private string _outPath;
        private List<CatalogCategory> _category = new List<CatalogCategory>();
        public CatalogGenerator(string categoriesP, string productP, string outPath)
        {
            _fileParser = new FileParser(categoriesP, productP);
            _fileParser.parse();
            parseToCatalog();
            _outPath = outPath;
        }

        public void generateJsonFile()
        {
            string json = JsonSerializer.Serialize(_category);
            File.WriteAllText($@"{_outPath}\return.json", json);
        }

        public void generateXmlFile()
        {
            XmlSerializer mySerializer = new
            XmlSerializer(typeof(List<CatalogCategory>));
            StreamWriter myWriter = new StreamWriter($@"{_outPath}\return.xml");
            mySerializer.Serialize(myWriter, _category);
            myWriter.Close();
        }

        private void parseToCatalog()
        {
            _fileParser._categories.ForEach(c =>
            {
                _category.Add(new CatalogCategory()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Products = getProducts(c.Id)
                });
            });
        }

        private List<CatalogProduct> getProducts(int categoryid)
        {
            List<CatalogProduct> products = new List<CatalogProduct>();
            _fileParser._products.Where(p => p.CategoryId == categoryid).ToList().ForEach(p =>
            {
                products.Add(new CatalogProduct()
                {
                    Id = p.Id,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    Price = p.Price,
                });
            });

            return products;
        }
    }
}
