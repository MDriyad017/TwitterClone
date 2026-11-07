using Microsoft.EntityFrameworkCore;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TwitterCloneDBContext _context;

        public MessageRepository(TwitterCloneDBContext context)
        {
            _context = context;
        }

        public Message AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public Message UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
            return message;
        }

        public bool DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return true;
        }

        // Removes the messages the user sent as well as the ones they received.
        public int DeleteMessagesByUserId(Guid userId)
        {
            return _context.Messages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .ExecuteDelete();
        }

        public Message? GetMessageById(Guid id)
        {
            return _context.Messages.SingleOrDefault(m => m.Id == id);
        }

        public List<Message> GetMessages(Guid? senderId, Guid? receiverId)
        {
            return _context.Messages
                .Where(m => (senderId == null || m.SenderId == senderId) &&
                            (receiverId == null || m.ReceiverId == receiverId))
                .ToList();
        }

        public List<Message> GetConversation(Guid userId, Guid otherUserId)
        {
            return _context.Messages
                .Where(m => (m.SenderId == userId && m.ReceiverId == otherUserId) ||
                            (m.SenderId == otherUserId && m.ReceiverId == userId))
                .ToList();
        }
    }
}
