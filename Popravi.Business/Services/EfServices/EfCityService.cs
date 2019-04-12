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
    public class EfCityService : BaseEfService, ICityService
    {
        public EfCityService(PopraviDbContext context) : base(context) { }

        public PagedResponse<CityDto> GetAllCities(int pageNumber, int perPage = 5)
        {
            var ukupno = Context.Cities.Count();

            var totalPages = Math.Ceiling((double)ukupno / perPage);

            var offset = perPage * pageNumber - perPage;

            var cities = Context.Cities.Select(c => new CityDto
            {
                Id = c.Id,
                Name = c.Name,
                ZipCode = c.ZipCode
            }).OrderBy(c => c.Name)
            .Skip(offset)
            .Take(perPage);

            return new PagedResponse<CityDto>
            {
                Items = cities.ToList(),
                CurrentPage = pageNumber,
                PagesNumber = (int)totalPages
            };
        }

        public void AddCity(CityDto dto)
        {
            if (Context.Cities.Any(c => c.Name.ToLower() == dto.Name.ToLower()))
                throw new EntityAlreadyExistsException("Grad pod ovim imenom vec postoji.");
            var newCity = new City
            {
                Name = dto.Name,
                ZipCode = dto.ZipCode 
            };

            Context.Cities.Add(newCity);
            Context.SaveChanges();
        }

        public void DeleteCity(int id)
        {
            var city = Context.Cities.Find(id);

            if(city != null)
            {
                Context.Cities.Remove(city);
                Context.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException("Trazen grad ne postoji.");
            }
        }

        public IEnumerable<CityDto> GetAllCities()
        {
            return Context.Cities.Select(c => new CityDto
            {
                Id = c.Id,
                Name = c.Name,
                ZipCode = c.ZipCode
            }).ToList();
        }

        public void UpdateCity(int id, CityDto dto)
        {
            var city = Context.Cities.Where(c => c.Id == id).FirstOrDefault();

            if (city != null)
            {
                city.Name = dto.Name;
                city.ZipCode = dto.ZipCode;

                Context.SaveChanges();
            }
            else
                throw new EntityNotFoundException("Trazeni grad ne postoji.");
        }

        public CityDto FindCity(int id)
        {
            var city = Context.Cities.Find(id);
            if (city != null)
                return new CityDto
                {
                    Id = city.Id,
                    Name = city.Name,
                    ZipCode = city.ZipCode
                };
            throw new EntityNotFoundException("Trazeni grad ne postoji.");
        }
    }
}
