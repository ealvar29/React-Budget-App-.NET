import React from 'react';

function Transaction({ date, description, category, amount }) {
  const amountTextColor = amount > 0 ? 'text-green-400' : 'text-gray-900';

  return (
    <tr>
      <td className='px-5 py-5 border-b border-gray-200 bg-white text-sm'>
        <div className='flex items-center'>
          <div className='ml-3'>
            <p className='text-gray-900 whitespace-no-wrap'>
              {date.toLocaleString()}
            </p>
          </div>
        </div>
      </td>
      <td className='px-5 py-5 border-b border-gray-200 bg-white text-sm'>
        <p className='text-gray-900 whitespace-no-wrap'>{description}</p>
      </td>
      <td className='px-5 py-5 border-b border-gray-200 bg-white text-sm'>
        <p className='text-gray-900 whitespace-no-wrap'>{category}</p>
      </td>
      <td className='px-5 py-5 border-b border-gray-200 bg-white text-sm'>
        <p className={`${amountTextColor} whitespace-no-wrap`}>{amount}</p>
      </td>
    </tr>
  );
}

export default Transaction;
