using Microsoft.AspNetCore.Mvc;
using MVC_PartialView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MVC_PartialView.Models.Repository;
using MVC_PartialView.ViewModel;

namespace MVC_PartialView.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(){}

        public IActionResult Index()
        {
            return View(GetAllUsers());
        }

        //This a contract that represents the result of deleting a person
        [HttpGet("deleteUser/{itemId}")]
        public IActionResult DeletePeopel(int itemId)
        {
            PersonRepository.GetIns().Remove(itemId);
            return View("Index",GetAllUsers());
        }

        //This a contract that represents the result of filtering a person
        [HttpGet("filter")]
        public IActionResult GetFilteredData([FromQuery] string filter)
        {
            var filteredUsers = PersonRepository.GetIns().FilterByName(filter);
            return View("Index", GetUsers(filteredUsers));
        }

        //This a contract that represents the result of adding a person
        [HttpPost("user")] 
        public IActionResult AddPerson([FromForm]CreatePersonViewModel createPerVM) {
            PersonRepository.GetIns().Create(createPerVM.Name, createPerVM.City, createPerVM.PhoneNum);
            return View("Index", GetAllUsers());
        }


        //Get user list from PeopleViewModel
        private IEnumerable<PeopleViewModel> GetAllUsers() {
            return GetUsers(PersonRepository.GetIns().GetAll());
        }

        private IEnumerable<PeopleViewModel> GetUsers(List<Person> source) {
            List<PeopleViewModel> vmList = new List<PeopleViewModel>();


            foreach (var person in source)
            {
                var pvm = new PeopleViewModel();
                pvm.Id = person.Id;
                pvm.Name = person.Name;
                pvm.City = person.City;
                pvm.PhoneNum = person.PhoneNumber;
                //mapper!
                //reason why you should use view model: view model might be different by client request
                vmList.Add(pvm);
            }

            return vmList;
        }
        
    }

}
