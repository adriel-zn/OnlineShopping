using AutoMapper.Configuration.Annotations;
using OnlineShopping.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.WebApi.Models
{
    public class UserModel :BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public UserRole Role { get; set; }
    }
}
