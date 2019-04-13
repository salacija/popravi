using Microsoft.EntityFrameworkCore;
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
    public class EfLocationService : BaseEfService, ILocationService
    {
        public EfLocationService(PopraviDbContext context) : base(context) { }

        public void Add(CreateLocationDto dto)
        {
            if (Context.Locations.Any(l => l.Name.ToLower() == dto.Name.ToLower()))
                throw new EntityAlreadyExistsException("Lokacija pod ovim nazivom vec postoji.");
            var location = new Location
            {
                Name = dto.Name,
                CityId = dto.CityId
            };

            Context.Locations.Add(location);
            Context.SaveChanges();
        }

        public PagedResponse<LocationDto> GetAll(int pageNumber, int perPage = 5)
        {
            var ukupno = Context.Locations.Count();

            var totalPages = Math.Ceiling((double)ukupno / perPage);

            var offset = perPage * pageNumber - perPage;

            var locations = Context.Locations.Select(l => new LocationDto
            {
                Id = l.Id,
                Name = l.Name,
                CityName = l.City.Name
            }).OrderBy(l => l.Name).Skip(offset).Take(perPage);

            return new PagedResponse<LocationDto>
            {
                CurrentPage = pageNumber,
                Items = locations.ToList(),
                PagesNumber = (int)totalPages,
                PerPage = perPage
            };
        }

       

        public void Delete(int id)
        {
            var location = Context.Locations.Find(id);
            
            if(location != null)
            {
                Context.Locations.Remove(location);
                Context.SaveChanges();
            }
            else
                throw new EntityNotFoundException("Trazena lokacija ne postoji.");
        }

        public void Update(int id, CreateLocationDto dto)
        {
            var location = Context.Locations.Where(l => l.Id == id).FirstOrDefault();

            if (location != null)
            {
                location.Name = dto.Name;
                location.CityId = dto.CityId;

                Context.SaveChanges();
            }
            else
                throw new EntityNotFoundException("Lokacija ne postoji.");
        }

        public LocationDto Find(int id)
        {
            var location = Context.Locations.Include(l => l.City).Where(l => l.Id == id).FirstOrDefault();
            if (location != null)
                return new LocationDto
                {
                    CityName = location.City.Name,
                    Id = location.Id,
                    Name = location.Name
                };
            throw new EntityNotFoundException("Trazena lokacija ne postoji.");
        }

        public IEnumerable<LocationDto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
