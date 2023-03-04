using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServices.TransactionService
{
    public interface ITransactionService
    {
        void Begin(System.Transactions.IsolationLevel isolationLevel = System.Transactions.IsolationLevel.ReadCommitted);
        Task Commit(CancellationToken cancellationToken = default);
    }
}
