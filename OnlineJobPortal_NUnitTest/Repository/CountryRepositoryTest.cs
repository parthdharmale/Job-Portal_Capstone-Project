using OnlineJobPortal.Data;
using OnlineJobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJobPortal_NUnitTest.Repository
{
    internal class CountryRepositoryTest
    {
        private CountryRepository _countryRepo;
        public CountryRepositoryTest(CountryRepository countryRepo)
        { 
            _countryRepo = countryRepo;
    }
}
