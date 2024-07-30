using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DbContext
{
    public class BaseDBContext : IdentityDbContext<User>
    {


    }
}
