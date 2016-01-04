using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_BirthDay.Logic
{
    class BirthDayLogic
    {
        public static void SendBirthEmail() {
            var BirthDayEmployee = Dao.DaoEmployee.GetAllBirthDayEmployee();
            foreach (Model.snemple LoopEmployee in BirthDayEmployee) {
                Console.WriteLine("Enviando Felicitacion a:"+LoopEmployee.correo_e);
                Logic.EmailLogic.BirthDayEmail(LoopEmployee);
                var NotBirthDayEmployee = Dao.DaoEmployee.GetAllNotBirthDayEmployee(LoopEmployee);
                foreach (Model.snemple NotBirthDay in NotBirthDayEmployee) {
                    Console.WriteLine("Enviando recordatorio a:" + NotBirthDay.correo_e);
                    Logic.EmailLogic.PartnerEmail(LoopEmployee, NotBirthDay);
                }

            }


        }

    }
}
