import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import TransactionsPage from './components/TransactionsPage';
import NotFoundPage from './components/NotFoundPage';
import './index.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/fetch-data' element={<FetchData />} />
          <Route path='/transactions' element={<TransactionsPage />} />
          <Route path='*' element={<NotFoundPage />} />
        </Routes>
      </Layout>
    );
  }
}
