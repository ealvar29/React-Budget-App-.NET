import React, { useEffect, useState } from 'react';
import Expense from './Transaction';

const mockTransactions = [
  {
    id: '1',
    amount: -120.5,
    category: 'Automotive',
    description: 'Arco Gas 2 Gallons',
    date: new Date(),
  },
  {
    id: '2',
    amount: -53.12,
    category: 'Utilities',
    description: 'SO CAL GAS BILL',
    date: new Date(),
  },
  {
    id: '3',
    amount: 100.0,
    category: 'Transfer',
    description: 'Online Transfer from Checkings',
    date: new Date(),
  },
  {
    id: '4',
    amount: -67.49,
    category: 'Entertainment',
    description: 'Steam - Elden Ring',
    date: new Date(),
  },
  {
    id: '5',
    amount: 69.42,
    category: 'Income',
    description: 'OnlyFans Inc Monthly',
    date: new Date(),
  },
];

const itemsPerPage = 5;

function TransactionsPage() {
  const [transactions, setTransactions] = useState(mockTransactions);
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    const randomTransactions = [];
    for (let i = 0; i < 25; i++) {
      randomTransactions.push({
        id: Math.floor(Math.random() * 10000).toString(),
        amount: (Math.random() * 100 - 50).toFixed(2),
        category: 'Unknown',
        description: 'A random expense',
        date: new Date(),
      });
    }
    setTransactions((transactions) => [...transactions, ...randomTransactions]);
  }, []);

  const onShowNextPage = () => {
    setCurrentPage((page) => {
      page++;
      return (page =
        page > Math.ceil(transactions.length / itemsPerPage)
          ? Math.ceil(transactions.length / itemsPerPage)
          : page < 1
          ? 1
          : page);
    });
  };

  const onShowPreviousPage = () => {
    setCurrentPage((page) => {
      page--;
      return (page =
        page > transactions.length / itemsPerPage
          ? transactions.length / itemsPerPage
          : page < 1
          ? 1
          : page);
    });
  };

  const onRemoveExpense = (id) => {
    // TODO: Remove this from the database as well!
    setTransactions((transactions) =>
      transactions.filter((transaction) => transaction.id !== id)
    );
  };

  const onAddExpense = (event) => {
    // TODO: Add the expense to the database as well!
    // TODO: Allow expense data to be created from a user form, not just hard-coded here!
    const newTransaction = {
      id: Math.floor(Math.random() * 1000).toString(),
      amount: (Math.random() * 100 - 50).toFixed(2),
      category: 'Unknown',
      description: 'A random expense',
      date: new Date(),
    };
    setTransactions((transactions) => [...transactions, newTransaction]);
  };

  let totalLoss = 0;
  let totalGain = 0;
  transactions.forEach((transaction) => {
    if (transaction.amount < 0) {
      totalLoss += parseFloat(transaction.amount);
    } else {
      totalGain += parseFloat(transaction.amount);
    }
  });
  console.log('TOTAL GAIN', totalGain);
  console.log('TOTAL LOSS', totalLoss);

  return (
    <div>
      <div className='bg-white p-8 rounded-md w-full'>
        <div className=' flex items-center justify-between pb-6'>
          <div>
            <h2 className='text-gray-600 font-semibold'>
              Transactions History
            </h2>
            <span className='text-xs'>All Transactions</span>
          </div>
          <div className='flex items-center justify-between'>
            <div className='flex bg-gray-50 items-center p-2 rounded-md'>
              <svg
                xmlns='http://www.w3.org/2000/svg'
                className='h-5 w-5 text-gray-400'
                viewBox='0 0 20 20'
                fill='currentColor'
              >
                <path
                  fillRule='evenodd'
                  d='M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z'
                  clipRule='evenodd'
                />
              </svg>
              <input
                className='bg-gray-50 outline-none ml-1 block '
                type='text'
                name=''
                id=''
                placeholder='search...'
              />
            </div>
            <div className='lg:ml-40 ml-10'>
              <button
                className='bg-indigo-600 px-4 py-2 rounded-md text-white font-semibold tracking-wide cursor-pointer'
                onClick={onAddExpense}
              >
                Add Transaction
              </button>
            </div>
          </div>
        </div>

        <div className='flex flex-row gap-8'>
          <div className='text-green-500'>
            <p>Total Savings</p>
            <p>{totalGain.toFixed(2)}</p>
          </div>
          <div>
            <p>Total Spendings</p>
            <p>{totalLoss.toFixed(2)}</p>
          </div>
        </div>

        <div>
          <div className='-mx-4 sm:-mx-8 px-4 sm:px-8 py-4 overflow-x-auto'>
            <div className='inline-block min-w-full shadow rounded-lg overflow-hidden'>
              <table className='min-w-full leading-normal'>
                <thead>
                  <tr>
                    <th className='px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider'>
                      Date
                    </th>
                    <th className='px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider'>
                      Description
                    </th>
                    <th className='px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider'>
                      Category
                    </th>
                    <th className='px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider'>
                      Amount
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {transactions
                    .slice(
                      (currentPage - 1) * itemsPerPage,
                      currentPage * itemsPerPage
                    )
                    .map(({ id, date, description, category, amount }) => {
                      return (
                        <Expense
                          key={id}
                          id={id}
                          date={date}
                          description={description}
                          category={category}
                          amount={amount}
                          onRemoveExpense={onRemoveExpense}
                        />
                      );
                    })}
                </tbody>
              </table>

              <div className='px-5 py-5 bg-white border-t flex flex-col xs:flex-row items-center xs:justify-between          '>
                <span className='text-xs xs:text-sm text-gray-900'>
                  Showing {(currentPage - 1) * itemsPerPage + 1} to{' '}
                  {currentPage * itemsPerPage > transactions.length
                    ? transactions.length
                    : currentPage * itemsPerPage}{' '}
                  of {transactions.length} Transactions
                </span>
                <div className='inline-flex mt-2 xs:mt-0'>
                  <button
                    className='text-sm text-indigo-50 transition duration-150 hover:bg-indigo-500 bg-indigo-600 font-semibold py-2 px-4 rounded-l'
                    onClick={onShowPreviousPage}
                  >
                    Prev
                  </button>
                  &nbsp; &nbsp;
                  <button
                    className='text-sm text-indigo-50 transition duration-150 hover:bg-indigo-500 bg-indigo-600 font-semibold py-2 px-4 rounded-r'
                    onClick={onShowNextPage}
                  >
                    Next
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default TransactionsPage;
