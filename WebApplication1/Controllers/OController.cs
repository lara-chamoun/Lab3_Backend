using Domain.Entities;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Persistence;

namespace WebApplication1.Controllers;
public class OController : ODataController
{
    private readonly PostgresContext _dbContext;

    public OController(PostgresContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("GetRoleList")]
    [EnableQuery()]
    public IQueryable<Role> RetrieveRoleList() {
        return _dbContext.Roles.AsQueryable();
    }

    [HttpGet("GetRoleById")]
    [EnableQuery]
    [ODataRoute("({id})")]
    public Role Get([FromODataUri] int id) {
        return _dbContext.Roles.Find(id);
    }
    

}