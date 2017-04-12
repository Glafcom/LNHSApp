using LNHSApp.BLLContracts.Interfaces.Services;
using LNHSApp.DALContracts.Interfaces;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Services
{
    public class RoundRobinStageService : BaseService<RoundRobinStage>, IRoundRobinStageService
    {
        public RoundRobinStageService(IGenericRepository<RoundRobinStage> itemRepository)
            : base(itemRepository)
        {
        }
    }
}
