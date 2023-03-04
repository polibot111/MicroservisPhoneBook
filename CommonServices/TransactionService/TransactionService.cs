using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CommonServices.TransactionService
{
    public class TransactionService: ITransactionService
    {
        protected bool hasTransactionStarted;
        protected TransactionScope transactionScope;
        public void Begin(System.Transactions.IsolationLevel isolationLevel = System.Transactions.IsolationLevel.ReadCommitted)
        {
            hasTransactionStarted = true;
            var options = new TransactionOptions()
            {
                IsolationLevel = isolationLevel
            };
            transactionScope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);
        }

        public async Task Commit(CancellationToken cancellationToken = default)
        {
            transactionScope.Complete();
        }
        }
}
