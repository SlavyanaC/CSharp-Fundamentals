namespace Forum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.UserInterface.ViewModels;
    using Forum.Data;
    using Forum.Models;

    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            ForumData data = new ForumData();
            Category category = data.Categories.Find(x => x.Id.Equals(categoryId));
            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData data = new ForumData();
            Post post = data.Posts.Find(x => x.Id.Equals(postId));

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (var replyId in post.ReplyIds)
            {
                var reply = data.Replies.Find(x => x.Id.Equals(replyId));
                replies.Add(new ReplyViewModel(reply));
            }
            return replies;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            var postIds = forumData.Categories.First(x => x.Id.Equals(categoryId)).Posts;
            IEnumerable<Post> posts = forumData.Posts.Where(x => postIds.Contains(x.Id));
            return posts;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();
            var allCategories = forumData.Categories.Select(c => c.Name).ToArray();
            return allCategories;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(x => x.Id.Equals(postId));
            PostViewModel pvm = new PostViewModel(post);
            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            var category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);
            if (category == null)
            {
                var categories = forumData.Categories;
                var categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }

        internal static bool TrySavePost(PostViewModel postView)
        {
            var emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            var emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            var emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyContent || emptyTitle) return false;

            var forumData = new ForumData();

            var category = EnsureCategory(postView, forumData);
            var postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;
            var author = UserService.GetUser(postView.Author);
            var authorId = author.Id;
            var content = string.Join(string.Empty, postView.Content);

            var post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            postView.PostId = postId;

            return true;
        }

        internal static bool TryAddReply(int postId, ReplyViewModel replyViewModel)
        {
            var forumData = new ForumData();

            var emptyReply = !replyViewModel.Content.Any();

            if (emptyReply) return false;

            var replyId = forumData.Replies.Any() ? forumData.Replies.Last().Id + 1 : 1;

            var content = string.Join("", replyViewModel.Content);

            var authorId = UserService.GetUser(replyViewModel.Author).Id;

            var reply = new Reply(replyId, content, authorId, postId);

            var post = forumData.Posts.FirstOrDefault(p => p.Id == postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();

            return true;
        }
    }
}