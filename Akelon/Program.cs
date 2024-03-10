using Akelon;

namespace PracticTask1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>()
            {
                new Employee("Иванов Иван Иванович"),
                new Employee("Петров Петр Петрович"),
                new Employee("Юлина Юлия Юлиановна"),
                new Employee("Сидоров Сидор Сидорович"),
                new Employee("Павлов Павел Павлович"),
                new Employee("Георгиев Георг Георгиевич")
            };

            var aviableWorkingDaysOfWeekWithoutWeekends = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            var vacationManager = new VacationManager(employees, aviableWorkingDaysOfWeekWithoutWeekends);
            vacationManager.GenerateVacations();
            vacationManager.PrintVacations();
        }
    }
}