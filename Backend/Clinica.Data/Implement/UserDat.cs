
using Clinica.Data.Interface;
using Clinica.Entity.Contexts;
using Clinica.Entity.DTO;
using Clinica.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using System;

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
                var usuario = await _context.User.FindAsync(model.DocumentNumber);
                if (usuario == null)
                {
                    throw new Exception("Not found");
                }

                usuario.DocumentTypeId = model.DocumentTypeId;
                usuario.Name = model.Name;
                usuario.FathersLastName = model.FathersLastName;
                usuario.MothersLastName = model.MothersLastName;
                usuario.Address = model.Address;
                usuario.UbigeoCode = model.UbigeoCode;
                usuario.Phone = model.Phone;
                usuario.Email = model.Email;
                usuario.Active = model.Active;


                await _context.SaveChangesAsync();

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
                var usuario = await _context.User.FindAsync(id);
                var d = usuario;
                if (usuario == null)
                {
                    throw new Exception("Not found");
                }

                _context.User.Remove(usuario);
                await _context.SaveChangesAsync();

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
                var model = await _context.User.FindAsync(id);
                if (model == null)
                {
                    throw new Exception("Not found");
                }
                var ubigeo = await _context.Ubigeo.FindAsync(model.UbigeoCode);
                return new UserDTO
                {
                    DocumentNumber = model.DocumentNumber,
                    DocumentTypeId = model.DocumentTypeId,
                    Name = model.Name,
                    FathersLastName = model.FathersLastName,
                    MothersLastName = model.MothersLastName,
                    Address = model.Address,
                    RegionCode = ubigeo.RegionCode,
                    ProvinceCode = ubigeo.ProvinceCode,
                    UbigeoCode = model.UbigeoCode,
                    Phone = model.Phone,
                    Email = model.Email,
                    Password = model.Password,
                    Active = model.Active
                };

            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


    }
}
