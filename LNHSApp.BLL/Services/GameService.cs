﻿using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Contracts.DALContracts;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Services
{
    public class GameService : BaseService<Game>, IGameService
    {
        public GameService(IGenericRepository<Game> itemRepository)
            : base(itemRepository)
        {
        }
    }
}
