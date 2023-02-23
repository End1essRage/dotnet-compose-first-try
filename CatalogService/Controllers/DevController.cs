using CatalogService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {
        [HttpPost("RecreateDataBase")]
        public void ReCreateTables()
        {
            DevFunctionallity.DropTableByType(DevFunctionallity.TableType.All);
            DevFunctionallity.CreateDataTableByType(DevFunctionallity.TableType.Category);
            DevFunctionallity.CreateDataTableByType(DevFunctionallity.TableType.SubCategory);
            DevFunctionallity.CreateDataTableByType(DevFunctionallity.TableType.Product);
        }
    }
}
