using System.Linq;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using System;

    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;

    public class CategoryController : IController, IPaginationController
    {
        public CategoryController()
        {
            CurrentPage = 0;
            SetCategory(0);
        }

        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public int CurrentPage { get; set; }

        private string[] PostTitles { get; set; }

        private int LastPage => PostTitles.Length / 11;

        private bool IsFirstPage => CurrentPage == 0;

        private bool IsLastPage => CurrentPage == LastPage;

        public int CategoryId { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Back:

                    return MenuState.Back;
                case Command.ViewCategory:

                    return MenuState.ViewPost;
                case Command.PreviousPage:

                    return MenuState.OpenCategory;
                case Command.NextPage:

                    return MenuState.OpenCategory;
            }
            throw new InvalidCommandException();
        }

        public void SetCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

        public IView GetView(string userName)
        {
            GetPosts();
            var categoryName = PostService.GetCategory(this.CategoryId).Name;
            return new CategoryView(categoryName, this.PostTitles, this.IsFirstPage, this.IsLastPage);
        }

        private void ChangePage(bool forward = true)
        {
            CurrentPage += forward ? 1 : -1;
        }

        private void GetPosts()
        {
            var allCategoryPosts = PostService.GetPostsByCategory(CategoryId);
            PostTitles = allCategoryPosts.Skip(this.CurrentPage * PAGE_OFFSET).Take(PAGE_OFFSET)
                .Select(p => p.Title).ToArray();
        }


        private enum Command
        {
            Back = 0,
            ViewCategory = 1,
            PreviousPage = 11,
            NextPage = 12
        }
    }
}