using DesignPattern_ChainOfResponsibility.DAL.Context;
using DesignPattern_ChainOfResponsibility.DAL.Entities;
using DesignPattern_ChainOfResponsibility.Models;

namespace DesignPattern_ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAsistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            ChainOfRespContext context = new ChainOfRespContext();

            if (req.Amount >= 200000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Oğuzhan PEKER";
                customerProcess.Description = "Müşterinin talep ettiği kredi tutarı tarafımca ödenmiştir.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Oğuzhan PEKER";
                customerProcess.Description = "Müşterinin talep ettiği kredi tutar tarafımca ödenemediği için işlem şube müdürüne aktarılmıştır";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }

        }
    }
}
