using Microsoft.EntityFrameworkCore;
using FinanceTrack.Models;

namespace FinanceTrack.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data directly into SQLite
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin User", Email = "admin@financetrack.com", Role = "Admin" },
                new User { Id = 2, Name = "Staff Member", Email = "staff@financetrack.com", Role = "Staff" }
            );

            var t = new System.DateTime(2025, 6, 1);
            modelBuilder.Entity<Transaction>().HasData(
                // --- Income ---
                new Transaction { Id = 1,  Date = t.AddDays(-5),  Amount = 28000,  Type = "Income",     Status = "Paid",    Category = "Service Fees",     EntityName = "Future Tech Solutions",   DueDate = t.AddDays(-5)  },
                new Transaction { Id = 2,  Date = t.AddDays(-12), Amount = 14500,  Type = "Income",     Status = "Paid",    Category = "Product Sales",    EntityName = "RetailMax Ltd",            DueDate = t.AddDays(-12) },
                new Transaction { Id = 3,  Date = t.AddDays(-20), Amount = 52000,  Type = "Income",     Status = "Paid",    Category = "Consulting",       EntityName = "Apex Consulting Group",    DueDate = t.AddDays(-20) },
                new Transaction { Id = 4,  Date = t.AddDays(-35), Amount = 9800,   Type = "Income",     Status = "Paid",    Category = "Support Contract", EntityName = "Horizon Systems",          DueDate = t.AddDays(-35) },
                new Transaction { Id = 5,  Date = t.AddDays(-48), Amount = 33000,  Type = "Income",     Status = "Paid",    Category = "Service Fees",     EntityName = "BlueSky Enterprises",      DueDate = t.AddDays(-48) },
                new Transaction { Id = 6,  Date = t.AddDays(-60), Amount = 21500,  Type = "Income",     Status = "Paid",    Category = "Product Sales",    EntityName = "TechNova Inc",             DueDate = t.AddDays(-60) },
                new Transaction { Id = 7,  Date = t.AddDays(-75), Amount = 47000,  Type = "Income",     Status = "Paid",    Category = "Licensing",        EntityName = "Pinnacle Software",        DueDate = t.AddDays(-75) },
                new Transaction { Id = 8,  Date = t.AddDays(-90), Amount = 16200,  Type = "Income",     Status = "Paid",    Category = "Consulting",       EntityName = "Sterling Advisory",        DueDate = t.AddDays(-90) },
                new Transaction { Id = 9,  Date = t.AddDays(-100),Amount = 38500,  Type = "Income",     Status = "Paid",    Category = "Service Fees",     EntityName = "Giant Corp",               DueDate = t.AddDays(-100)},
                new Transaction { Id = 10, Date = t.AddDays(-115),Amount = 11000,  Type = "Income",     Status = "Paid",    Category = "Product Sales",    EntityName = "Momentum Retail",          DueDate = t.AddDays(-115)},

                // --- Expenses ---
                new Transaction { Id = 11, Date = t.AddDays(-3),  Amount = 5000,   Type = "Expense",    Status = "Paid",    Category = "Rent",             EntityName = "Silverstone Properties",  DueDate = t.AddDays(-3)  },
                new Transaction { Id = 12, Date = t.AddDays(-3),  Amount = 42000,  Type = "Expense",    Status = "Paid",    Category = "Salaries",         EntityName = "Payroll - June",           DueDate = t.AddDays(-3)  },
                new Transaction { Id = 13, Date = t.AddDays(-5),  Amount = 830,    Type = "Expense",    Status = "Paid",    Category = "Utilities",        EntityName = "EcoSpark Energy",          DueDate = t.AddDays(-5)  },
                new Transaction { Id = 14, Date = t.AddDays(-8),  Amount = 2400,   Type = "Expense",    Status = "Paid",    Category = "Software",         EntityName = "Adobe Systems",            DueDate = t.AddDays(-8)  },
                new Transaction { Id = 15, Date = t.AddDays(-15), Amount = 1200,   Type = "Expense",    Status = "Paid",    Category = "Internet & Comms", EntityName = "Telkom Business",          DueDate = t.AddDays(-15) },
                new Transaction { Id = 16, Date = t.AddDays(-22), Amount = 6700,   Type = "Expense",    Status = "Paid",    Category = "Marketing",        EntityName = "Brandify Agency",          DueDate = t.AddDays(-22) },
                new Transaction { Id = 17, Date = t.AddDays(-33), Amount = 3100,   Type = "Expense",    Status = "Paid",    Category = "Office Supplies",  EntityName = "Officeworks SA",           DueDate = t.AddDays(-33) },
                new Transaction { Id = 18, Date = t.AddDays(-40), Amount = 42000,  Type = "Expense",    Status = "Paid",    Category = "Salaries",         EntityName = "Payroll - May",            DueDate = t.AddDays(-40) },
                new Transaction { Id = 19, Date = t.AddDays(-40), Amount = 5000,   Type = "Expense",    Status = "Paid",    Category = "Rent",             EntityName = "Silverstone Properties",   DueDate = t.AddDays(-40) },
                new Transaction { Id = 20, Date = t.AddDays(-55), Amount = 9500,   Type = "Expense",    Status = "Paid",    Category = "Insurance",        EntityName = "Shield Business Cover",    DueDate = t.AddDays(-55) },
                new Transaction { Id = 21, Date = t.AddDays(-66), Amount = 4200,   Type = "Expense",    Status = "Paid",    Category = "Travel",           EntityName = "FlightCentre Corporate",   DueDate = t.AddDays(-66) },
                new Transaction { Id = 22, Date = t.AddDays(-80), Amount = 1750,   Type = "Expense",    Status = "Paid",    Category = "Utilities",        EntityName = "EcoSpark Energy",          DueDate = t.AddDays(-80) },
                new Transaction { Id = 23, Date = t.AddDays(-5),  Amount = 2900,   Type = "Expense",    Status = "Pending", Category = "Maintenance",      EntityName = "FixIt Facilities",         DueDate = t.AddDays(10)  },
                new Transaction { Id = 24, Date = t.AddDays(-2),  Amount = 680,    Type = "Expense",    Status = "Pending", Category = "Subscriptions",    EntityName = "Microsoft 365",            DueDate = t.AddDays(13)  },

                // --- Receivables ---
                new Transaction { Id = 25, Date = t.AddDays(-10), Amount = 66000,  Type = "Receivable", Status = "Pending", Category = "Service Fees",     EntityName = "Giant Corp",               DueDate = t.AddDays(20)  },
                new Transaction { Id = 26, Date = t.AddDays(-7),  Amount = 29500,  Type = "Receivable", Status = "Pending", Category = "Consulting",       EntityName = "Apex Consulting Group",    DueDate = t.AddDays(23)  },
                new Transaction { Id = 27, Date = t.AddDays(-14), Amount = 13800,  Type = "Receivable", Status = "Pending", Category = "Product Sales",    EntityName = "RetailMax Ltd",            DueDate = t.AddDays(16)  },
                new Transaction { Id = 28, Date = t.AddDays(-20), Amount = 44000,  Type = "Receivable", Status = "Pending", Category = "Licensing",        EntityName = "Pinnacle Software",        DueDate = t.AddDays(10)  },
                new Transaction { Id = 29, Date = t.AddDays(-45), Amount = 18700,  Type = "Receivable", Status = "Paid",    Category = "Support Contract", EntityName = "Horizon Systems",          DueDate = t.AddDays(-15) },
                new Transaction { Id = 30, Date = t.AddDays(-60), Amount = 32000,  Type = "Receivable", Status = "Paid",    Category = "Service Fees",     EntityName = "BlueSky Enterprises",      DueDate = t.AddDays(-30) },

                // --- Liabilities ---
                new Transaction { Id = 31, Date = t.AddDays(-10), Amount = 150000, Type = "Liability",  Status = "Pending", Category = "Business Loan",    EntityName = "FNB Business Banking",     DueDate = t.AddDays(320) },
                new Transaction { Id = 32, Date = t.AddDays(-5),  Amount = 12000,  Type = "Liability",  Status = "Pending", Category = "Credit Line",      EntityName = "Nedbank Credit",           DueDate = t.AddDays(25)  },
                new Transaction { Id = 33, Date = t.AddDays(-90), Amount = 85000,  Type = "Liability",  Status = "Pending", Category = "Equipment Finance", EntityName = "ABSA Asset Finance",      DueDate = t.AddDays(270) },
                new Transaction { Id = 34, Date = t.AddDays(-30), Amount = 7500,   Type = "Liability",  Status = "Pending", Category = "VAT Payable",      EntityName = "SARS",                     DueDate = t.AddDays(30)  },
                new Transaction { Id = 35, Date = t.AddDays(-120),Amount = 220000, Type = "Liability",  Status = "Pending", Category = "Mortgage",         EntityName = "Standard Bank",            DueDate = t.AddDays(240) },
                new Transaction { Id = 36, Date = t.AddDays(-180),Amount = 45000,  Type = "Liability",  Status = "Paid",    Category = "Business Loan",    EntityName = "Capitec Business",         DueDate = t.AddDays(-5)  },

                // --- Assets ---
                new Transaction { Id = 37, Date = t.AddDays(-180),Amount = 170000, Type = "Asset",      Status = "Paid",    Category = "Equipment",        EntityName = "Dell Technologies SA",     DueDate = t.AddDays(-180)},
                new Transaction { Id = 38, Date = t.AddDays(-30), Amount = 55000,  Type = "Asset",      Status = "Paid",    Category = "Cash Equivalents", EntityName = "FNB Business Banking",     DueDate = t.AddDays(-30) },
                new Transaction { Id = 39, Date = t.AddDays(-90), Amount = 320000, Type = "Asset",      Status = "Paid",    Category = "Property",         EntityName = "Cape Town Commercial Park",DueDate = t.AddDays(-90) },
                new Transaction { Id = 40, Date = t.AddDays(-60), Amount = 28000,  Type = "Asset",      Status = "Paid",    Category = "Vehicles",         EntityName = "Avis Fleet SA",            DueDate = t.AddDays(-60) },
                new Transaction { Id = 41, Date = t.AddDays(-15), Amount = 14500,  Type = "Asset",      Status = "Paid",    Category = "Furniture",        EntityName = "Office National",          DueDate = t.AddDays(-15) },
                new Transaction { Id = 42, Date = t.AddDays(-200),Amount = 95000,  Type = "Asset",      Status = "Paid",    Category = "Equipment",        EntityName = "HP Enterprise SA",         DueDate = t.AddDays(-200)},
                new Transaction { Id = 43, Date = t.AddDays(-10), Amount = 7200,   Type = "Asset",      Status = "Paid",    Category = "Investments",      EntityName = "Sanlam Investments",       DueDate = t.AddDays(-10) },
                new Transaction { Id = 44, Date = t.AddDays(-45), Amount = 18000,  Type = "Asset",      Status = "Paid",    Category = "Investments",      EntityName = "Old Mutual Business",      DueDate = t.AddDays(-45) }
            );
        }
    }
}
