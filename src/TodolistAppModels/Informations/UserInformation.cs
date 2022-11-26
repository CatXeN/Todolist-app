using System.ComponentModel.DataAnnotations;
using TodolistAppModels.Entities;

namespace TodolistAppModels.Informations
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
