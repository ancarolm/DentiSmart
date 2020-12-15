using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DentiSmart.Model
{
    public class CitaRepository
    {
        public IList<Cita> Citas{ get; set; }
        public Cita cita
        { get; set; }

        public CitaRepository()
        {
            Task.Run(async () => Citas = (IList<Cita>)await App.Database.GetDoctorAsync()).Wait();
        }

        public IList<Cita> GetAll()
        {
            return Citas;
        }
    }
}
