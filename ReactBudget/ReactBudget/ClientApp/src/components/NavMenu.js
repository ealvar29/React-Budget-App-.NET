import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    return (
      <header>
        <div className='flex mb-3'>
          <NavLink tag={Link} to='/'>
            ReactBudget
          </NavLink>
          <ul className='flex gap-5 ml-auto'>
            <li>
              <NavLink tag={Link} className='text-dark' to='/'>
                Home
              </NavLink>
            </li>
            <li>
              <NavLink tag={Link} className='text-dark' to='/fetch-data'>
                Fetch data
              </NavLink>
            </li>
            <li>
              <NavLink tag={Link} className='text-dark' to='/transactions'>
                Transactions
              </NavLink>
            </li>
          </ul>
        </div>
      </header>
    );
  }
}
