// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Sql.Model;






void firstQuery(){
    using (var db = new NorthwindContext())
    {
        var query = from p in db.Products.Include(c => c.Category)
                    where !p.Discontinued
                    orderby p.ProductName
                    select p;
        foreach (var item in query)
        {
            Console.WriteLine($"{item.ProductName} -- {item.Category?.CategoryName}");
        }
    }
}

void secondQuery()
{
    using (var db = new NorthwindContext())
    {
        var query = (from o in db.Orders.Include(o => o.Customer)
                     let empIds = (from e in db.Employees
                                   where e.FirstName.Equals("Nancy")
                                   && e.LastName.Equals("Davolio")
                                   select e.EmployeeId).ToList()
                     where empIds.Any(a => a == o.EmployeeId)
                     select o.Customer.ContactName).Distinct();


        foreach (var item in query)
        {
            Console.WriteLine($"{item}");
        }
    }
}

void thirdQuery()
{
    using (var db = new NorthwindContext())
    {
        var query = from o in db.Orders.Include(o => o.OrderDetails)
                    let empIds = (from e in db.Employees
                                  where e.FirstName.Equals("Steven")
                                  && e.LastName.Equals("Buchanan")
                                  select e.EmployeeId).ToList()
                    where empIds.Any(a => a == o.EmployeeId)
                    select o.OrderDetails;

        double totalIncome = 0;

        foreach (var orderDetails in query)
        {
            foreach (var ordDetail in orderDetails)
            {
                totalIncome += (double)ordDetail.UnitPrice * ordDetail.Quantity * (1 - ordDetail.Discount);
            }
        }

        Console.WriteLine($"Total income: {totalIncome}");
    }
}

void fourthQuery()
{
    using (var db = new NorthwindContext())
    {
        var reportsRelated = db.Employees.Include(e => e.InverseReportsToNavigation).Include(e => e.ReportsToNavigation).
            First(em => em.FirstName.Equals("Andrew") && em.LastName.Equals("Fuller"));


        reportsRelated.InverseReportsToNavigation.ToList().ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
        Console.WriteLine($"{reportsRelated.ReportsToNavigation?.FirstName} {reportsRelated.ReportsToNavigation?.LastName}");
    }
}