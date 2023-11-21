using Demo_Entity_Framework.Data;
using Demo_Entity_Framework.Data.Entities;
using Demo_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Entity_Framework.Service
{
    public class BlogService
    {
        public List<PostListViewModel> GetAllPosts()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Posts.Select(x => new PostListViewModel()
                {
                    Id = x.Id,
                    Titel = x.Titel,
                    Inhoud = x.Inhoud,
                    PublicatieDatum = x.PublicatieDatum
                }).ToList();
            }
        }

        public void SavePost(CreatePostViewModel model)
        {
            Post post = new Post();
            post.Titel = model.Titel;
            post.Inhoud = model.Inhoud;
            post.PublicatieDatum = DateTime.Now;

            using (var context = new ApplicationDbContext())
            {
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }

        public EditPostViewModel GetPostForEdit(int id)
        {
            using(var context = new ApplicationDbContext())
            {
                Post post = context.Posts.Find(id);

                EditPostViewModel editPost = new EditPostViewModel();
                editPost.Titel = post.Titel;
                editPost.Inhoud = post.Inhoud;

                return editPost;
            }
        }

        public void UpdatePost(int id, EditPostViewModel model)
        {
            using(var context = new ApplicationDbContext())
            {
                Post existing = context.Posts.Find(id);
                existing.Titel = model.Titel;
                existing.Inhoud = model.Inhoud;

                context.SaveChanges();
            }
        }

        public PostDetailsViewModel GetPostDetails(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                PostDetailsViewModel viewModel = new PostDetailsViewModel()
                {
                    Post = context.Posts.Include(x => x.Comments).Single(x => x.Id == id)
                };

                return viewModel;
            }
        }

        public void AddComment(int postId, PostDetailsViewModel model)
        {
            using(var context = new ApplicationDbContext())
            {
                Post post = context.Posts.Include(x => x.Comments).Single(x => x.Id == postId);
                
                Comment comment = new Comment();
                comment.Inhoud = model.Comment;
                comment.Auteur = model.Auteur;
                comment.Tijdstip = DateTime.Now;

                post.Comments.Add(comment);
                context.SaveChanges();
            }
        }
    }
}
