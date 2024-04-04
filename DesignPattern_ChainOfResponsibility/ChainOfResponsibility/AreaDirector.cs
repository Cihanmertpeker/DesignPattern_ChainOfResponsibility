using DesignPattern_ChainOfResponsibility.DAL.Context;
using DesignPattern_ChainOfResponsibility.DAL.Entities;
using DesignPattern_ChainOfResponsibility.Models;

namespace DesignPattern_ChainOfResponsibility.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            ChainOfRespContext context = new ChainOfRespContext();

            if (req.Amount >= 200000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Müdürü - Ahmet PEKER";
                customerProcess.Description = "Müşterinin talep ettiği kredi tutarı tarafımca ödenmiştir.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Müdürü - Ahmet PEKER";
                customerProcess.Description = "Müşterinin talep ettiği kredi tutar bankanın günlük ödeme limitlerini aştığı için işlem gerçekleştirilemedi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }

        }
    }
}
