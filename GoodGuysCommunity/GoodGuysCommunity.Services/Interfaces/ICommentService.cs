using System.Threading.Tasks;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface ICommentService
    {
        Task Add(string content, string authorId, int postId);
    }
}
