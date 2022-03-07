using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MVC_PartialView.Models.Repository;
using MVC_PartialView.Controllers;

namespace MVC_PartialView.Controllers
{
    internal class People
    {
        private  PersonRepository _personRepository;

        //PartialView Actions
        /*[HttpGet]
        public IActionResult Last()
        {
            List<People> peopleList = new PersonRepository.GetAll();
            People lastPer = new People();
            foreach (People item in peopleList)
            {
                if (item.Id > lastPer.Id)
                {
                    lastPer = item;

                }
            }
            return PartialView("_shortcodeInfo", lastInfo);


        }*/
    }
}