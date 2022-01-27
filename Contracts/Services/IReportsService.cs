using System.Threading.Tasks;
using Entities.Models;

public interface IOzonReportsService {
    // Transactions
    Task<TransactionResult> GetTransactionsAsync();
    Task SaveTransactionAsync(TransactionResult result);

    // Stocks
    Task<StockResults> GetStocksAsync();
    Task SaveStocksAsync(StockResults result);

    // Postings
    Task<PostingResults> GetPostingsAsync();
    Task SavePostingsAsync(PostingResults results);

    Task SaveAll();
    Task UpdateAll();
}
