using System;
using System.Threading.Tasks;
using PaymentApp.Domain.Interface;
using PaymentApp.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace PaymentApp.Infrastructure.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public async Task TransactionComplete(Action function)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                function();
                await Complete();
                transaction.Commit();
            }
        }

        public async Task TransactionCompleteAsync(Func<Task> function)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                await function();
                await Complete();
                transaction.Commit();
            }
        }
    }
}