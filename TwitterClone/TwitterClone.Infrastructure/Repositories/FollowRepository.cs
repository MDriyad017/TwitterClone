using Microsoft.EntityFrameworkCore;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly TwitterCloneDBContext _context;

        public FollowRepository(TwitterCloneDBContext context)
        {
            _context = context;
        }

        public Follow AddFollow(Follow follow)
        {
            _context.Follows.Add(follow);
            _context.SaveChanges();
            return follow;
        }

        public bool DeleteFollow(Follow follow)
        {
            _context.Follows.Remove(follow);
            _context.SaveChanges();
            return true;
        }

        // Removes the follows where the user is either side of the relationship.
        public int DeleteFollowsByUserId(Guid userId)
        {
            return _context.Follows
                .Where(f => f.FollowerId == userId || f.FollowingId == userId)
                .ExecuteDelete();
        }

        public Follow? GetFollowById(Guid id)
        {
            return _context.Follows.SingleOrDefault(f => f.Id == id);
        }

        public Follow? GetFollowByUsers(Guid followerId, Guid followingId)
        {
            return _context.Follows.FirstOrDefault(f => f.FollowerId == followerId && f.FollowingId == followingId);
        }

        public List<Follow> GetFollows(Guid? followerId, Guid? followingId)
        {
            return _context.Follows
                .Where(f => (followerId == null || f.FollowerId == followerId) &&
                            (followingId == null || f.FollowingId == followingId))
                .ToList();
        }
    }
}
