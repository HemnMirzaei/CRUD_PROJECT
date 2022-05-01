using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudProject.DataAccessLayer.Entites;

namespace CrudProject.Core.Interfaces
{
    public interface ICustomer
    {
        List<Customer> AllCustomer();

        void AddNewCustomer(Customer customer);

        bool IsExistEmail (string email);

        bool IsExistPhone (string phone);

        bool IsExistFirstNameLastNameBirthday (string firstName, string lastName,string birthday);
        
        Customer GetById (int id);

        void Edit(int id,Customer customer);

        void Delete(int? id);


    }
}
