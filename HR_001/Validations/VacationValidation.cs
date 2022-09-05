using System.Globalization;

namespace HR_001.Validations
{
    public class VacationValidation
    {
        HrDbContext context = new HrDbContext();
        public bool VacationAvailability(int EmpId, int CompanyId, int vacationNumber, int vacationType)
        {
            int balnce;
            var takenVacation = 0;
            var Empbalnce = context.EmployeeBlances.Where(c => c.CompanyId == CompanyId).Select(p => new { p.Number, p.IsMonth }).FirstOrDefault();
            int number = Empbalnce.Number;
            if (!Empbalnce.IsMonth)
            {
                balnce = number * 12;
            }
            else
            {
                balnce = number;
            }
            var employeeCreated = context.Employees.Where(c => c.Id == EmpId).Select(p => p.CreatedDate);
            DateTime dt = Convert.ToDateTime(employeeCreated);
            int month = dt.Month;
            int percent = (month / balnce) * 100;
            int realBlance = percent * balnce;
            var vacations = context.Vacations.Where(e => e.EmployeeId == EmpId && e.VacationTypeId == vacationType).Select(v => new {v.FromDate,v.ToDate }).ToList();
            foreach (var v in vacations)
            {
                DateTime from = Convert.ToDateTime(v.FromDate);
                DateTime to = Convert.ToDateTime(v.ToDate);
                takenVacation += (to.Month - from.Month);
            }
            int res = realBlance - takenVacation;
            if(res >= vacationNumber)
            return true;
            return false;
        }
    }
}
