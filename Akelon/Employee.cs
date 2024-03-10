namespace Akelon
{
    public class Employee
    {
        public string Name { get; set; }
        public List<Vacation> Vacations { get; set; } = new List<Vacation>();

        public Employee(string name)
        {
            Name = name;
        }

        public void AddVacation(Vacation vacation)
        {
            Vacations.Add(vacation);
        }
    }
}
