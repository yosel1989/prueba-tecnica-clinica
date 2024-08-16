using Clinica.Entity.Models;
using System.Diagnostics.CodeAnalysis;

namespace Clinica.Entity.DTO
{
    public class UserDTO
    {
        public string DocumentNumber { get; set; }

        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string FathersLastName { get; set; }
        public string MothersLastName { get; set; }
        public string Address { get; set; }
        [AllowNull]
        public string? RegionCode { get; set; }
        [AllowNull]
        public string? ProvinceCode { get; set; }
        public string UbigeoCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool Active { get; set; }

        public User _toConvertUserEntity()
        {
            User entity = new User() {
                DocumentNumber = DocumentNumber,
                DocumentTypeId = DocumentTypeId,
                Name = Name,
                FathersLastName = FathersLastName,
                MothersLastName = MothersLastName,
                Address = Address,
                UbigeoCode = UbigeoCode,
                Phone = Phone,
                Email = Email,
                Password = Password,
                Active = Active
            };
            //set entity values here from StudentDTO
            return entity;
        }
    }
}
