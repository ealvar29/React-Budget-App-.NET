using Microsoft.EntityFrameworkCore;
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

        public ExpenseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateExpense(Expenses expense)
        {
            _db.Expenses.Add(expense);
            return Save();
        }

        public bool DeleteExpense(Expenses expense)
        {
            _db.Expenses.Remove(expense);
            return Save();
        }

        public ICollection<Expenses> GetExpenses()
        {
            return _db.Expenses.Include(x => x.Id).ToList();
        }

        public Expenses GetExpense(int expensesId)
        {
            return _db.Expenses.FirstOrDefault(x => x.Id == expensesId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateExpense(Expenses expense)
        {
            _db.Expenses.Update(expense);
            return Save();
        }
    }
}
