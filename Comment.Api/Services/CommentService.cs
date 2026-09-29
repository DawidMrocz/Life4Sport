using Comment.Api.ApiModels;
using Comment.Api.Data;
using Comment.Api.Models;

namespace Comment.Api.Services
{
    public partial class CommentService : ICommentService
    {
        public readonly CommentDbContext _commentDbContext;

        public CommentService(CommentDbContext commentDbContext)
        {
            _commentDbContext = commentDbContext;
        }

        public Task Create(CreateCommentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentModel>> GetList(int productId)
        {
            throw new NotImplementedException();
        }

        public Task Update(int commentId, UpdateCommentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
