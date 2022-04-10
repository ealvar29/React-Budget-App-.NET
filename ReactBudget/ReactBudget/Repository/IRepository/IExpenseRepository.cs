using ReactBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBudget.Repository.IRepository
{
    public interface IExpenseRepository
    {
        ICollection<Expense> GetExpenses();

        Expense GetExpense(int expensesId);

        // Not sure about adding these yet
        //bool ExpenseExists(string name);

        //bool ExpenseExists(int id);

        bool CreateExpense(Expense expense);

        bool UpdateExpense(Expense expense);

        bool DeleteExpense(Expense expense);

        bool Save();
    }
}
