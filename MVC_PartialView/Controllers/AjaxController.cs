using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_PartialView.Models.Repository;
using MVC_PartialView.ViewModel;

namespace MVC_PartialView.Controllers {
    public class AjaxController : Controller {
        [HttpGet("ajax/getUsers")]
        public IActionResult GetPeople() {
            var people = PersonRepository.GetIns().GetAll();
            var personViewModels = people.Select((a, i) => new PersonViewModel {
                Index = i + 1,
                Id = a.Id,
                City = a.City,
                Name = a.Name,
                PhoneNum = a.PhoneNumber
            });

            return View("/Views/People/People.cshtml", personViewModels);
        }

        [HttpPost("ajax/getUser/{personId}")]
        public IActionResult GetPersonById(int personId) {
            var person = PersonRepository.GetIns().GetById(personId);
            return View("/Views/People/People.cshtml", new[] {person}.Select((a, i) => new PersonViewModel {
                Index = i + 1,
                Id = a.Id,
                City = a.City,
                Name = a.Name,
                PhoneNum = a.PhoneNumber
            }));
        }

        [HttpDelete("ajax/deleteUser/{personId}")]
        public IActionResult DeletePersonById(int personId) {
            PersonRepository.GetIns().Remove(personId);
            return Ok("Your request to delete a user is completed!");
        }
    }
}