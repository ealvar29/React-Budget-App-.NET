using ReactBudget.Data.Migrations;
using ReactBudget.Models;
using ReactBudget.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBudget.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _db;

        public bool CreateExpense(Expenses expense)
        {
            throw new NotImplementedException();
        }

        public bool DeleteExpense(Expenses expense)
        {
            throw new NotImplementedException();
        }

        public ICollection<Expenses> GetExpenses()
        {
            throw new NotImplementedException();
        }

        public Expenses GetTrail(int expensesId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateExpense(Expenses expense)
        {
            throw new NotImplementedException();
        }
    }
}
