using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CamilySolorzano.Models;

    public class CamilySolorzanoP1 : DbContext
    {
        public CamilySolorzanoP1 (DbContextOptions<CamilySolorzanoP1> options)
            : base(options)
        {
        }

        public DbSet<CamilySolorzano.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<CamilySolorzano.Models.Reserva> Reserva { get; set; } = default!;

public DbSet<CamilySolorzano.Models.PlanDeRecompensa> PlanDeRecompensa { get; set; } = default!;
    }
