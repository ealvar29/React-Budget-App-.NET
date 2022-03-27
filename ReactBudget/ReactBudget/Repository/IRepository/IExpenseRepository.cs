using ReactBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBudget.Repository.IRepository
{
    public interface IExpenseRepository
    {
        ICollection<Expenses> GetExpenses();

        Expenses GetExpense(int expensesId);

        // Not sure about adding these yet
        //bool ExpenseExists(string name);

        //bool ExpenseExists(int id);

        bool CreateExpense(Expenses expense);

        bool UpdateExpense(Expenses expense);

        bool DeleteExpense(Expenses expense);

        bool Save();
    }
}
