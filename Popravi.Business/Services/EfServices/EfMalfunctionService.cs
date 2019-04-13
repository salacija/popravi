using Popravi.Business.DataTransfer;
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
    public class EfMalfunctionService : BaseEfService, IMalfunctionService
    {
        public EfMalfunctionService(PopraviDbContext context) : base(context) { }

        public PagedResponse<MalfunctionDto> GetAll(int pageNumber, int perPage = 5)
        {
            var ukupno = Context.MalFunctions.Count();
            var ukupanBrojStranica = Math.Ceiling((double)ukupno / perPage);
            var offset = perPage * pageNumber - perPage;

            var malfunctions = Context.MalFunctions.Select(m => new MalfunctionDto
            {
                Id = m.Id,
                Name = m.Name
            }).OrderBy(m => m.Name).Skip(offset).Take(perPage);

            return new PagedResponse<MalfunctionDto>
            {
                CurrentPage = pageNumber,
                Items = malfunctions.ToList(),
                PagesNumber = (int)ukupanBrojStranica
            };
        }

 

        public void Delete(int id)
        {
            var malfunction = Context.MalFunctions.Find(id);

            if (malfunction != null)
            {
                Context.MalFunctions.Remove(malfunction);
                Context.SaveChanges();
            }
            else
                throw new EntityNotFoundException("Trazen kvar ne postoji.");
        }

        public void Add(MalfunctionDto dto)
        {
            if (Context.MalFunctions.Any(m => m.Name.ToLower() == dto.Name.ToLower()))
                throw new EntityAlreadyExistsException("Kvar pod ovim nazivom vec postoji.");
            var newMalfunction = new Malfunction
            {
                Name = dto.Name
            };
            Context.MalFunctions.Add(newMalfunction);
            Context.SaveChanges();
        }

        public MalfunctionDto Find(int id)
        {
            var malfunction = Context.MalFunctions.Find(id);
            if(malfunction != null)
                return new MalfunctionDto
                {
                    Id = malfunction.Id,
                    Name = malfunction.Name,
                };
            throw new EntityNotFoundException("Trazeni kvar ne postoji.");
        }

        public void Update(int id, MalfunctionDto dto)
        {
            var malfunction = Context.MalFunctions.Where(m => m.Id == id).FirstOrDefault();

            if (malfunction != null)
            {
                malfunction.Name = dto.Name;

                Context.SaveChanges();
            }
            else
                throw new EntityNotFoundException("Trazeni kvar ne postoji.");
        }

        public IEnumerable<MalfunctionDto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
