﻿namespace Akelon
{
    public class Vacation
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Vacation(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
