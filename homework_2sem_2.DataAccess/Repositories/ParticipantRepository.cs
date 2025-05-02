using homework_2sem_2.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace homework_2sem_2.DataAccess.Repositories
{
    public class ParticipantRepository
    {
        private readonly AppDbContext _dbContext;

        public ParticipantRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddParticipants(IEnumerable<Participant> participants)
        {
            foreach (var participant in participants)
            {
                var participantEntity = _dbContext.Participants
                    .Include(p => p.ContactInfo)
                    .FirstOrDefault(p => p.Id == participant.Id);

                if (participantEntity == null)
                {
                    _dbContext.Participants.Add(participant);
                }
                else
                {
                    _dbContext.Entry(participantEntity).CurrentValues.SetValues(participant);
                    if (participant.ContactInfo != null)
                    {
                        if (participantEntity.ContactInfo == null)
                        {
                            participantEntity.ContactInfo = new ContactInfo();
                        }
                        _dbContext.Entry(participantEntity.ContactInfo)
                            .CurrentValues.SetValues(participant.ContactInfo);
                    }
                }
            }
            _dbContext.SaveChanges();
        }

        public object? GetInfoById(Guid id)
        {
            return _dbContext.Participants
                .Where(p => p.Id == id)
                .AsNoTracking()
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.BirthDate,
                    p.ContactInfo.Email,
                    p.ContactInfo.Address,
                    p.ContactInfo.Phone,
                    TicketsCount = p.Tickets.Count(),
                }).FirstOrDefault();
        }
    }

}
