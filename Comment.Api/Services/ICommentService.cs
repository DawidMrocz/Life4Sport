using Comment.Api.ApiModels;
using Comment.Api.Models;

namespace Comment.Api.Services
{
    public interface ICommentService
    {
        Task Create(CreateCommentRequest request);
        Task Update(int commentId, UpdateCommentRequest request);
        Task Delete(int commentId);
        Task<List<CommentModel>> GetList(int productId);
    }
}
