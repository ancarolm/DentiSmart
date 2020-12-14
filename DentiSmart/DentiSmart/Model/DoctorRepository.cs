using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DentiSmart.Model
{
    public class DoctorRepository
    {
        public IList<Doctor> Doctors { get; set; }
        public Doctor doctor { get; set; }

        public DoctorRepository()
        {
            Task.Run(async () => Doctors = await App.Database.GetDoctorAsync()).Wait();
        }

        public IList<Doctor> GetAll()
        {
            return Doctors;
        }

    }
}
