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

        public bool CreateExpense(Expense expense)
        {
            _db.Expenses.Add(expense);
            return Save();
        }

        public bool DeleteExpense(Expense expense)
        {
            _db.Expenses.Remove(expense);
            return Save();
        }

        public ICollection<Expense> GetExpenses()
        {
            return _db.Expenses.OrderBy(x => x.Id).ToList();
        }

        public Expense GetExpense(int expensesId)
        {
            return _db.Expenses.FirstOrDefault(x => x.Id == expensesId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateExpense(Expense expense)
        {
            _db.Expenses.Update(expense);
            return Save();
        }
    }
}
