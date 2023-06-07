using Microsoft.EntityFrameworkCore;
using Phone.Models;

namespace Phone.DATA;

public class PhoneDbContext:DbContext
{
    public PhoneDbContext(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<Contact> Contacts =>Set<Contact>();
}
