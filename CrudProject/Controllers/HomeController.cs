using Microsoft.AspNetCore.Mvc;



using CrudProject.DataAccessLayer.Entites;
using CrudProject.Core.Interfaces;
using CrudProject.Core.ViewModels;


namespace CrudProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICustomer _customer;
        public HomeController(ICustomer customer)
        {
            _customer = customer;
        }


        public IActionResult Index()
        {
            List<Customer> list = _customer.AllCustomer();
            return View(list);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_customer.IsExistEmail(viewModel.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already in use.");
                    
                }
                else if (_customer.IsExistPhone(viewModel.PhoneNumber))
                {
                    ModelState.AddModelError("PhoneNumber", "This Phone Number is already Exist.");
                }
                else if(_customer.IsExistFirstNameLastNameBirthday(viewModel.FirstName, viewModel.LastName, viewModel.DateOfBirth))
                {
                    ModelState.AddModelError("FirstName", "There is another user with " + 
                        "this First Name, Last Name and birthday");
                }
                else
                {
                    Customer customer = new Customer()
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        DateOfBirth = viewModel.DateOfBirth,
                        PhoneNumber = viewModel.PhoneNumber,
                        Email = viewModel.Email,
                        BankAccountNumber = viewModel.BankAccountNumber
                    };
                    _customer.AddNewCustomer(customer);
                }
                    

            }
            return View(viewModel);
        }




        public IActionResult Details(int id)
        {
            Customer customer = _customer.GetById(id);
            return View(customer);
        }




        public IActionResult Edit(int id)
        {
            Customer customer = _customer.GetById(id);
            return View(customer);
        }



        [HttpPost]
        public IActionResult Edit(int id, Customer modal)
        {
            if (ModelState.IsValid)
            {
                _customer.Edit(id, modal);

            }
            return RedirectToAction("Index","Home");
        }


        public IActionResult Delete(int id)
        {
            Customer customer = _customer.GetById(id);
            return View(customer);
        }



        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _customer.Delete(id);
            return RedirectToAction("Index","Home");
        }
    }
}
