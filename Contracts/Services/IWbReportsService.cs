using System.Threading.Tasks;

public interface IWbReportsService {
    // Incomes
    Task GetIncomes();
    Task SaveIncomes();

    // Sales
    Task GetSales();
    Task SaveSales();

    // Reports
    Task GetReports();
    Task SaveReports();

    // Orders
    Task GetOrders();
    Task SaveOrders();

    Task SaveAll();
    Task UpdateAll();
}
