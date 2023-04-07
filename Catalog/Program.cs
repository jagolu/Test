// See https://aka.ms/new-console-template for more information
using Catalog.Src;
string categoriesPath = @"C:\Users\javi\Downloads\PruebasCandidatos\PruebasCandidatos\Catalog\Categories.csv";
string productsPath = @"C:\Users\javi\Downloads\PruebasCandidatos\PruebasCandidatos\Catalog\Products.csv";
string outPath = @"C:\Users\javi\Downloads\PruebasCandidatos\PruebasCandidatos\Catalog\";

CatalogGenerator c = new CatalogGenerator(categoriesPath, productsPath, outPath);
c.generateXmlFile();
c.generateJsonFile();