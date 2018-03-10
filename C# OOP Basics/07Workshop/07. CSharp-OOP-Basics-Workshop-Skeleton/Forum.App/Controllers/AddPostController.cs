using System;
using System.Linq;
using Forum.App.UserInterface;
using Forum.App.UserInterface.Input;
using Forum.App.UserInterface.ViewModels;

namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class AddPostController : IController
    {
        public AddPostController()
        {
            ResetPost();
        }

        private const int COMMAND_COUNT = 4;
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 18;
        private const int POST_MAX_LENGTH = 660;
        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public PostViewModel Post { get; set; }

        private TextArea TextArea { get; set; }

        public bool Error { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.AddTitle:
                    ReadTitle();
                    return MenuState.AddPost;
                case Command.AddCategory:
                    ReadCategory();
                    return MenuState.AddPost;
                case Command.Write:
                    TextArea.Write();
                    Post.Content = TextArea.Lines.ToList();
                    return MenuState.AddPost;
                case Command.Post:
                    bool validPost = PostService.TrySavePost(Post);
                    if (!validPost)
                    {
                        Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.PostAdded;
            }
            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            Post.Author = userName;
            return new AddPostView(Post, TextArea, Error);
        }

        public void ResetPost()
        {
            Error = false;
            Post = new PostViewModel();
            TextArea = new TextArea(centerLeft - 18, centerTop - 7,
                TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }

        public void ReadTitle()
        {
            Post.Title = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadCategory()
        {
            Post.Category = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private enum Command
        {
            AddTitle,
            AddCategory,
            Write,
            Post
        }
    }
}