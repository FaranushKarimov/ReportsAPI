using Entities.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

public interface IWbReportsService {
    // Incomes
    Task<List<Income>> GetIncomesAsync();
    Task SaveIncomesAsync(List<Income> result);

    // Sales
    Task<List<Sale>> GetSalesAsync();
    Task SaveSalesAsync(List<Sale> result);

    // Reports
    Task<List<ReportDetailByPeriod>> GetReportsAsync();
    Task SaveReportsAsync(List<ReportDetailByPeriod> result);

    // Orders
    Task<List<OrderResult>> GetOrdersAsync();
    Task SaveOrdersAsync(List<OrderResult> result);

    Task UpdateAll();
}

