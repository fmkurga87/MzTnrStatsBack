using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using LinqKit;
using MzTNR.Contracts.Provincias.DTOs;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;

namespace MzTNR.Services.Extensiones
{
    public class DataSeed
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public DataSeed(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public void Seeding()
        {
            if(!_applicationDbContext.Provincias.Any())
            {
                using (var reader = new StreamReader("../MzTNR.Data/Seeds/provincias.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var provinciasCsv = csv.GetRecords<ProvinciaCsv>();

                    provinciasCsv.ForEach(x => {
                            var provinciaNueva = _mapper.Map<Provincia>(x);
                            _applicationDbContext.Provincias.Add(provinciaNueva);
                        });

                    _applicationDbContext.SaveChanges();
                }
            } 
            
        }

    }
}