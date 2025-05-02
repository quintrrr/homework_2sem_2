using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework_2sem_2.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace homework_2sem_2.DataAccess.Repositories
{
    public class LotteryRepository
    {
        private readonly AppDbContext _dbContext;

        public LotteryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddLotteries(IEnumerable<Lottery> lotteries)
        {
            foreach (var lottery in lotteries)
            {
                var lotteryEntity = _dbContext.Lotteries
                    .Include(l => l.NumberRange)
                    .FirstOrDefault(l => l.Id == lottery.Id);

                if (lotteryEntity == null)
                {
                    _dbContext.Lotteries.Add(lottery);
                }
                else
                {
                    _dbContext.Entry(lotteryEntity).CurrentValues.SetValues(lottery);
                    if (lottery.NumberRange != null)
                    {
                        if (lotteryEntity.NumberRange == null)
                        {
                            lotteryEntity.NumberRange = new NumberRange();
                        }
                        _dbContext.Entry(lotteryEntity.NumberRange)
                            .CurrentValues.SetValues(lottery.NumberRange);
                    }
                }
            }
            _dbContext.SaveChanges();
        }

        
    }

}
