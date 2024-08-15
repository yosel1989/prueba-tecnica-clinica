
using Clinica.Data.Interface;
using Clinica.Entity.Contexts;
using Clinica.Entity.DTO;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data.Implement
{
	public class UserDat : IUserDat
	{

        private readonly ApplicationDBContext _context;

        public UserDat(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserDTO>> Collection()
        {
            try
            {
                List<UserDTO> collection =  await _context.User.Select(u => new UserDTO()
                {
                    DocumentNumber = u.DocumentNumber, 
                    DocumentTypeId = u.DocumentTypeId,
                    Name = u.Name,
                    FathersLastName = u.FathersLastName,
                    MothersLastName = u.MothersLastName,
                    Address = u.Address,
                    UbigeoCode = u.UbigeoCode,
                    Phone = u.Phone,
                    Email = u.Email,
                    Active = u.Active
                }).ToListAsync();

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<bool> Create(UserDTO model)
        {
            try
            {
                _context.User.Add(model._toConvertUserEntity());
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<bool> Update(UserDTO model)
        {
            try
            {
                return true;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                return true;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<UserDTO> Find(string id)
        {
            try
            {
                return new UserDTO();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


    }
}
