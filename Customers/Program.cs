// See https://aka.ms/new-console-template for more information
using Customers.Model;
using Customers.Src;

string csvP = @"C:\Users\javi\Downloads\PruebasCandidatos\PruebasCandidatos\Customers\Customers.csv";

FileParser fp = new FileParser(csvP);
fp.parse();
using (var db = new TestDbContext())
{
    db.Customers.AddRange(fp._customers);
    db.SaveChanges();
}