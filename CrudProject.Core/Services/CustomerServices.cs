using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudProject.Core.Interfaces;
using CrudProject.DataAccessLayer.Entites;
using CrudProject.DataAccessLayer.Context;

namespace CrudProject.Core.Services
{
    public class CustomerServices : ICustomer
    {
        private DatabaseContext _context;
        public CustomerServices(DatabaseContext context)
        {
            _context = context; 
        }

        public void AddNewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);   
            _context.SaveChanges();
        }

        public List<Customer> AllCustomer()
        {
            return _context.Customers.ToList();
        }

        public void Delete(int? id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void Edit(int id,Customer customer)
        {
            Customer customerToUpdate = _context.Customers.Find(id);
            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;
            customerToUpdate.Email = customer.Email;    
            customerToUpdate.BankAccountNumber = customer.BankAccountNumber;
            customerToUpdate.DateOfBirth = customer.DateOfBirth;
            _context.SaveChanges();
        }

        public Customer GetById(int id)
        {
            Customer customer = _context.Customers.Find(id);
            return customer;
        }

        public bool IsExistEmail(string email)
        {
            Customer customer = _context.Customers.FirstOrDefault(u => u.Email == email);
            if(customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsExistFirstNameLastNameBirthday(string firstName, string lastName, string birthday)
        {
            Customer customer = _context.Customers.FirstOrDefault(
                u => u.FirstName == firstName && u.LastName == lastName && u.DateOfBirth == birthday
                );
            if (customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsExistPhone(string phone)
        {
            Customer customer = _context.Customers.FirstOrDefault(u => u.PhoneNumber == phone);
            if (customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
