using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using AgencyMAnagmentSystem.Models;

namespace AgencyManagmentSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Maid> Maid { get; set; }
        public DbSet<MaidAdress> MaidAdress { get; set; }
        public DbSet<MaidKin> MaidKin { get; set; }
        public DbSet<Agents> Agents { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Contrat> Contrat { get; set; }
        public DbSet<ScannedCoc> ScannedCoc { get; set; }
        public DbSet<ScannedContactPersonID> ScannedContactPersonID { get; set; }
        public DbSet<ScannedMedical> ScannedMedical { get; set; }
        public DbSet<ScannedMiniPhoto> ScannedMiniPhoto { get; set; }
        public DbSet<ScannedNational_Id> ScannedNational_Id { get; set; }
        public DbSet<ScannedPassport> ScannedPassport { get; set; }
        public DbSet<ScannedPoliceClearance> ScannedPoliceClearance { get; set; }
        public DbSet<ScannedSigniture> ScannedSigniture { get; set; }
        public DbSet<ScannedwholePhoto> ScannedwholePhoto { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequest { get; set; }
        public DbSet<BioData> BioData { get; set; }
        public DbSet<Approved> Approved { get; set; }
        public DbSet<VizaAuthonticity> VizaAuthonticity { get; set; }
        public DbSet<CocAuthonticity> CocAuthonticity { get; set; }
        public DbSet<MolsaApprovalLattere> MolsaApprovalLattere { get; set; }
    }
}