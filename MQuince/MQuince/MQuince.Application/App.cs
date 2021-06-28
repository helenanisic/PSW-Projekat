using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Application
{
    public class App
    {
        private DbContextOptionsBuilder _optionsBuilder;
        private DbContextOptionsBuilder _optionsBuilderPostgres;

        public App(IConfiguration configuration)
        {
            _optionsBuilder = new DbContextOptionsBuilder();
            //_optionsBuilder.UseSqlServer(configuration.GetConnectionString("FeedbackExampleDB"));
            _optionsBuilder.UseMySql(@"server=localhost;port=3306;database=mquince;user=root;password=root");
            _optionsBuilderPostgres = new DbContextOptionsBuilder();
            _optionsBuilderPostgres.UseNpgsql("Host=localhost;port=5432;Database=apoteka;Username=postgres;Password=postgres");
        }

        public ICountryService GetCountryService()
            => new CountryService(this.GetCountryRepository());

        private ICountryRepository GetCountryRepository()
            => new CountryRepository(_optionsBuilder);
        public ICityService GetCityService()
            => new CityService(this.GetCityRepository());

        private ICityRepository GetCityRepository()
            => new CityRepository(_optionsBuilder);
        public IPatientService GetPatientService()
            => new PatientService(this.GetPatientRepository());

        private IPatientRepository GetPatientRepository()
            => new PatientRepository(_optionsBuilder);
        public IDoctorService GetDoctorService()
            => new DoctorService(this.GetDoctorRepository());

        private IDoctorRepository GetDoctorRepository()
            => new DoctorRepository(_optionsBuilder);

        public IAdressService GetAdressService()
            => new AdressService(this.GetAdressRepository());

        /*public IMedicineService GetMedicineService()
           => new MedicneService(this.GetMedicineRepository());*/

        private IAdressRepository GetAdressRepository()
            => new AdressRepository(_optionsBuilder);

        public IUserService GetUserService(string secret)
            => new UserService(this.GetUserRepository(), secret);

        private IUserRepository GetUserRepository()
            => new UserRepository(_optionsBuilder);
        public IFeedbackService GetFeedbackService()
            => new FeedbackService(this.GetFeedbackRepository());

        private IFeedbackRepository GetFeedbackRepository()
            => new FeedbackRepository(_optionsBuilder);

        private IAppointmentRepository GetAppointmentRepository()
            => new AppointmentRepository(_optionsBuilder);

        public IAppointmentService GetAppointmentService()
           => new AppointmentService(this.GetAppointmentRepository(), this.GetWorkScheduleRepository());

        private IWorkScheduleRepository GetWorkScheduleRepository()
            => new WorkScheduleRepository(_optionsBuilder);

        public IWorkScheduleService GetWorkScheduleService()
           => new WorkScheduleService(this.GetWorkScheduleRepository());

        private IReferralRepository GetReferralRepository()
            => new ReferralRepository(_optionsBuilder);
        /*private IMedicineRepository GetMedicneRepository()
            => new MedicineRepository(_optionsBuilderPostgres);*/

        public IReferralService GetReferralService()
           => new ReferralService(this.GetReferralRepository());
    }
}
