using GHPRS.Core.Entities.ETL;
using Microsoft.EntityFrameworkCore;

namespace GHPRS.Persistence;

public class ETLContext : DbContext
{
    public ETLContext(DbContextOptions<ETLContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "DefaultConnection",
            options => options.EnableRetryOnFailure());

    public DbSet<AgeDisaggregate> AgeDisaggregates { get; set; }
    public DbSet<Council> Councils { get; set; }
    public DbSet<CxStatus> CxStatus { get; set; }
    public DbSet<DataSource> DataSources { get; set; }
    public DbSet<HivStatus> HivStatus { get; set; }
    public DbSet<HivTreatmentStatus> HivTreatmentStatus { get; set; }
    public DbSet<Measure> Measures { get; set; }
    public DbSet<Mechanism> Mechanisms { get; set; }
    public DbSet<Modality> Modalities { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<PlhivEstimate> PlhivEstimates { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<SexDisaggregates> SexDisaggregates { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<TbStatus> TbStatus { get; set; }
    public DbSet<Ward> Wards { get; set; }
}