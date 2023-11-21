using Demo_Entity_Framework.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Demo_Entity_Framework.Models
{
    public class PostDetailsViewModel
    {
        [ValidateNever]
        public Post Post { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string Auteur { get; set; }
    }
}
