using DesignPattern_ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern_ChainOfResponsibility.DAL.Entities;
using DesignPattern_ChainOfResponsibility.Models;

namespace DesignPattern_ChainOfResponsibility.DAL.Context
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            ChainOfRespContext context= new ChainOfRespContext();

            if(req.Amount<=100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar - Cihan Mert PEKER";
                customerProcess.Description = "Müşterinin talep ettiği kredi tutarı tarafımca ödenmiştir";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover != null)
            {
                CustomerProcess customerProcess= new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar - Cihan Mert PEKER";
                customerProcess.Description = "Müşterinin talep ettiği kredi tutarı tarafımca ödenemediği için işlem şube müdür yardımcısına aktarılmıştır";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
