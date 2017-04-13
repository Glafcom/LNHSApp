using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Contracts.DALContracts;
using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Services
{
    public class BreakingService : BaseService<Breaking>, IBreakingService
    {
        public BreakingService(IGenericRepository<Breaking> itemRepository)
            : base(itemRepository)
        {
            
        }

        public IEnumerable<Breaking> GetBreakingsByFilter(BreakingFilter filter)
        {
            var breakings = GetItems();

            if (filter.Detail.HasValue)
                breakings = breakings.Where(b => b.DetailId == filter.Detail);

            if (filter.HockeyTable.HasValue)
                breakings = breakings.Where(b => b.HockeyTableId == filter.HockeyTable);

            if (filter.State.HasValue)
            {
                if ((BreakingState)filter.State == BreakingState.Resolved)
                    breakings = breakings.Where(b => b.IsResolved.HasValue && (bool)b.IsResolved);

                if ((BreakingState)filter.State == BreakingState.Unresolved)
                    breakings = breakings.Where(b => !b.IsResolved.HasValue || !(bool)b.IsResolved);
            }

            if (filter.PeriodStartDate.HasValue)
                breakings = breakings.Where(b => b.GameId.HasValue 
                    && ((b.Game.BeginTime.HasValue && (DateTime)b.Game.BeginTime >= filter.PeriodStartDate)
                    || (b.Game.EndTime.HasValue && (DateTime)b.Game.EndTime >= filter.PeriodStartDate)));

            if (filter.PeriodEndDate.HasValue)
                breakings = breakings.Where(b => b.GameId.HasValue
                    && ((b.Game.EndTime.HasValue && (DateTime)b.Game.EndTime >= filter.PeriodEndDate)
                    || (b.Game.BeginTime.HasValue && (DateTime)b.Game.BeginTime <= filter.PeriodEndDate)));

            return breakings;
        }

        public void ResolveBreaking(Guid breakingId, Order outcomeOrder)
        {
            var breaking = GetItem(breakingId);

            if (breaking == null)
                return;

            if (!CheckIsOrderCanResolveBreaking(outcomeOrder, breaking.Detail))
                return;

            if (outcomeOrder.Items != null 
                && outcomeOrder.Items
                    .Select(i => (Guid?)i.DetailId)
                    .Contains(breaking.DetailId))
            {
                breaking.IsResolved = true;
                breaking.ResolvedWithOrderId = outcomeOrder.Id;
                ChangeItem(breaking.Id, breaking);
            }
        }

        private bool CheckIsOrderCanResolveBreaking(Order order, Detail detail)
        {
            if (detail == null)
                return false;

            var suitableDetailsCount = order.Items.Where(i => i.DetailId == detail.Id).Count();
            var resolvedDetailsCount = (order.ResolvedBreakings != null)
                ? order.ResolvedBreakings.Where(rb => rb.DetailId == detail.Id && rb.IsResolved.HasValue && (bool)rb.IsResolved).Count()
                : 0;

            return (suitableDetailsCount - resolvedDetailsCount) > 0;

        }
    }
}
