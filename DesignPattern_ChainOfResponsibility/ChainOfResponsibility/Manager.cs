using DesignPattern_ChainOfResponsibility.DAL.Context;
using DesignPattern_ChainOfResponsibility.DAL.Entities;
using DesignPattern_ChainOfResponsibility.Models;

namespace DesignPattern_ChainOfResponsibility.ChainOfResponsibility
{
    public class Manager:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            ChainOfRespContext context = new ChainOfRespContext();

            if (req.Amount >= 280000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdürü - Yusuf PEKER";
                customerProcess.Description = "Müşterinin talep ettiği kredi tutarı tarafımca ödenmiştir.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdürü - Yusuf PEKER";
                customerProcess.Description = "Müşterinin talep ettiği kredi tutar tarafımca ödenemediği için işlem bölge müdürüne aktarılmıştır";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }

        }
    }
}
