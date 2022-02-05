using System.ComponentModel.DataAnnotations;

namespace MVC_PartialView.ViewModel
{
    //Person View Model for creating a person,
    //There are some requirement which need to be
    //fullfild in order to be able creating one person to the list  
    public class CreatePersonViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        public string City { get; set; }

        [Required]
        public long PhoneNum { get; set; }
    }
}
