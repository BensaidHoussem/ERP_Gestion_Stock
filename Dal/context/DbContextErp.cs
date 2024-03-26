using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class DbContextErp:IDbContextErp,IDisposable{

    public DbContextErp(IOptions<DbContextSettings> settings){
        var option=new DbContextOptionsBuilder<ErpDbContext>().UseNpgsql(settings.Value.DbConnectionString,
        npgsqlOptionsAction:s=>
        {
            s.EnableRetryOnFailure(maxRetryCount:10,
            maxRetryDelay:TimeSpan.FromSeconds(30),
            errorCodesToAdd:null);
        }).EnableSensitiveDataLogging().Options;
        DbContext=new ErpDbContext(option);
        DbContext.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.NoTracking;
    }

    public ErpDbContext DbContext { get;  set; }
    public void Dispose()=>DbContext?.Dispose();
    ~DbContextErp()=>Dispose();





}