namespace Akelon
{
    public class VacationManager
    {
        private List<Employee> _employees;
        private List<string> _availableWorkingDaysOfWeekWithoutWeekends;

        public VacationManager(List<Employee> employees, List<string> availableWorkingDaysOfWeekWithoutWeekends)
        {
            _employees = employees;
            _availableWorkingDaysOfWeekWithoutWeekends = availableWorkingDaysOfWeekWithoutWeekends;
        }

        private void VacationStep(DateTime endDate, DateTime startDate, int difference, int step)
        {
            endDate = startDate.AddDays(step);
            difference = step;
        }

        public void GenerateVacations()
        {
            foreach (var employee in _employees)
            {
                var gen = new Random();
                var start = new DateTime(DateTime.Now.Year, 1, 1);
                var end = new DateTime(DateTime.Today.Year, 12, 31);
                var vacationCount = 28;

                while (vacationCount > 0)
                {
                    int range = (end - start).Days;
                    var startDate = start.AddDays(gen.Next(range));

                    if (_availableWorkingDaysOfWeekWithoutWeekends.Contains(startDate.DayOfWeek.ToString()))
                    {
                        string[] vacationSteps = { "7", "14" };
                        var vacIndex = gen.Next(vacationSteps.Length);
                        var endDate = new DateTime(DateTime.Now.Year, 12, 31);
                        var difference = 0;

                        if (vacationSteps[vacIndex] == "7")
                        {
                            VacationStep(endDate, startDate, difference, 7);
                        }
                        else if (vacationSteps[vacIndex] == "14")
                        {
                            VacationStep(endDate, startDate, difference, 14);
                        }

                        if (vacationCount <= 7)
                        {
                            VacationStep(endDate, startDate, difference, 7);
                        }

                        // Проверка условий по отпуску
                        var CanCreateVacation = false;
                        var existStart = false;
                        var existEnd = false;

                        if (!employee.Vacations.Any(v => v.StartDate >= startDate && v.EndDate <= endDate))
                        {
                            if (!employee.Vacations.Any(v => v.StartDate.AddDays(3) >= startDate && v.EndDate.AddDays(3) <= endDate))
                            {
                                existStart = employee.Vacations.Any(v => v.StartDate.AddMonths(1) >= startDate && v.StartDate.AddMonths(1) >= endDate);
                                existEnd = employee.Vacations.Any(v => v.EndDate.AddMonths(-1) <= startDate && v.EndDate.AddMonths(-1) <= endDate);

                                if (!existStart || !existEnd)
                                    CanCreateVacation = true;
                            }
                        }

                        if (CanCreateVacation)
                        {
                            employee.AddVacation(new Vacation(startDate, endDate));
                            vacationCount -= vacationCount - difference;
                        }
                    }
                }
            }
        }

        public void PrintVacations()
        {
            foreach (var employee in _employees)
            {
                Console.WriteLine(employee.ToString());

                foreach (var vacation in employee.Vacations)
                {
                    Console.WriteLine(vacation.ToString());
                }

                Console.WriteLine();
            }
        }
    }
}
