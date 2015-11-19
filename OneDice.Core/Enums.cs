using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core
{
    public enum UserRole
    {
        Admin = 0,
        User
    }

    public enum TournamentStatus
    {
        Finished,
        Ongoing,
        Planned
    }

    public enum CompetitionType
    {
        SinglePlayer = 1,
        RoundRobin,
        SingleElimination,
        DoubleElimination
    }

    public enum ScoringType
    {
        Percentage = 1, //steps 0.01
        Decimal, //steps 0.01
        Integer
    }
}
