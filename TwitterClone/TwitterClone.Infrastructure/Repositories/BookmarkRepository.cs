using Microsoft.EntityFrameworkCore;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly TwitterCloneDBContext _context;

        public BookmarkRepository(TwitterCloneDBContext context)
        {
            _context = context;
        }

        public Bookmark AddBookmark(Bookmark bookmark)
        {
            _context.Bookmarks.Add(bookmark);
            _context.SaveChanges();
            return bookmark;
        }

        public bool DeleteBookmark(Bookmark bookmark)
        {
            _context.Bookmarks.Remove(bookmark);
            _context.SaveChanges();
            return true;
        }

        public int DeleteBookmarksByUserId(Guid userId)
        {
            return _context.Bookmarks
                .Where(b => b.UserId == userId)
                .ExecuteDelete();
        }

        public int DeleteBookmarksByTweetId(Guid tweetId)
        {
            return _context.Bookmarks
                .Where(b => b.TweetId == tweetId)
                .ExecuteDelete();
        }

        public Bookmark? GetBookmarkById(Guid id)
        {
            return _context.Bookmarks.SingleOrDefault(b => b.Id == id);
        }

        public Bookmark? GetBookmarkByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _context.Bookmarks.FirstOrDefault(b => b.UserId == userId && b.TweetId == tweetId);
        }

        public List<Bookmark> GetBookmarks(Guid? userId)
        {
            return _context.Bookmarks
                .Where(b => userId == null || b.UserId == userId)
                .ToList();
        }
    }
}
