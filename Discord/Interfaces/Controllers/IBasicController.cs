using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Interfaces.Controllers
{
    public interface IBasicController<T>
    {
        Task<ActionResult> Get(string id);
        Task<ActionResult> Create(T t);
        Task<ActionResult> Edit(T t);
        Task<ActionResult> Delete(string id);
    }
}
