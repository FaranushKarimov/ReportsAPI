using Entities.Models;
using System.Threading.Tasks;

public interface IOzonReportsService {
    // Transactions
    Task<TransactionResult> GetTransactionsAsync();
    Task SaveTransactionAsync(TransactionResult result);

    // Stocks
    Task<StockResults> GetStocksAsync();
    Task SaveStocksAsync(StockResults result);

    // Posting
    PostingResultResult GetPosting(string id);
    Task SavePostingAsync(string id);

    // Postings
    Task<PostingResults> GetPostingsAsync();
    Task SavePostingsAsync(PostingResults results);


    Task SaveAll();
    Task UpdateAll();
}
