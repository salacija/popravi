using Microsoft.EntityFrameworkCore;
using Popravi.Business.DataTransfer;
using Popravi.Business.DataTransfer.User;
using Popravi.Business.Exceptions;
using Popravi.Business.Responses;
using Popravi.Business.Services.Interfaces;
using Popravi.DataAccess;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Popravi.Business.Services.EfServices
{
    public class EfUserService : BaseEfService, IUserService
    {
        

        public EfUserService(PopraviDbContext context) : base(context) { }

        public PagedResponse<UserDto> GetAll(int pageNumber, int perPage = 2)
        {
            var numberOfUsers = Context.Users.Count();
            var totalPages = Math.Ceiling((double)numberOfUsers / perPage);
            var offset = perPage * pageNumber - perPage;

            var users =Context.Users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.Username,
                Phone = u.Phone,
                Email = u.Email
            }).Skip(offset).Take(perPage);

            return new PagedResponse<UserDto>
            {
                CurrentPage = pageNumber,
                Items = users.ToList(),
                PagesNumber = (int)totalPages
            };
        }

        public void Add(RegisterUserDto user)
        {
            var mailAlreadyExists = Context.Users.Where(u => u.Email == user.Email).Any();

            if (mailAlreadyExists)
                throw new Exception("E-mail vec postoji.");

            var usernameAlreadyExists = Context.Users.Where(u => u.Username == user.UserName).Any();

            if (usernameAlreadyExists)
                throw new Exception("Korisnicko ime vec postoji.");

            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.UserName,
                Password = user.Password,
                RoleId = Role.UserRoleId,
                ActivationCode = user.Uuid
            };

            Context.Users.Add(newUser);
            Context.SaveChanges();
        }

        public void ActivateUser(string activationCode)
        {
            var user = Context.Users.Where(u => u.ActivationCode == activationCode).FirstOrDefault();

            if(user != null)
            {
                if (!user.IsActive)
                {
                    user.IsActive = true;
                }
                else
                    throw new UserAlreadyActiveException();

                Context.SaveChanges();
            }
            else
            throw new EntityNotFoundException();
        }

        public LoggedUserDto FindUser(string username, string password)
        {
            var user = Context.Users
                .Include(u => u.Role)
                .Where(u => u.Username == username && u.Password == password && u.IsActive)
                .FirstOrDefault();
            
            if(user != null)
            {
                return new LoggedUserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    RoleName = user.Role.Name
                };
            }
            return null;
        }

        public UserDto Find(int id)
        {
            var user = Context.Users.Find(id);
            if(user != null)
            {
                return new UserDto
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    UserName = user.Username,
                    Id = user.Id
                };
            }
            throw new EntityNotFoundException($"Ne postoji korisnik.");
        }

        public void Update(int id, UserDto dto)
        {
            var user = Context.Users.Where(u => u.Id == id).FirstOrDefault();

            if(user != null)
            {
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Username = dto.UserName;
                user.Phone = dto.Phone;

                Context.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException("Korisnik ne postoji.");
            }
        }

        public bool IsOldPasswordCorrect(string password, int id)
        {
            var user = Context.Users.Where(u => u.Id == id && u.Password == password).FirstOrDefault();

            if(user == null)
            {
                return false;
            }
            return true;
        }
        

        public void UpdateUserPassword(string password, int id)
        {
            var user = Context.Users.Where(u => u.Id == id).FirstOrDefault();

            if(user != null)
            {
                user.Password = password;

                Context.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException("Korisnik ne postoji.");
            }
        }

        public IEnumerable<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
