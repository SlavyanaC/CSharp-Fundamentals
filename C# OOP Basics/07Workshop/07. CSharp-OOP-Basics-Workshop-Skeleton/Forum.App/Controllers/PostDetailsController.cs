namespace Forum.App.Controllers
{
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Services;

    public class PostDetailsController : IController, IUserRestrictedController
    {
        public bool LoggedInUser { get; set; }

        public int PostId { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
                case Command.AddReply:
                    return MenuState.AddReplyToPost;
                default:
                    throw new InvalidCommandException();
            }
        }

        public IView GetView(string userName)
        {
            PostViewModel pvm = PostService.GetPostViewModel(PostId);
            return new PostDetailsView(pvm, LoggedInUser);
        }

        public void UserLogIn()
        {
            LoggedInUser = true;
        }

        public void UserLogOut()
        {
            LoggedInUser = false;
        }

        public void SetPostId(int postId)
        {
            PostId = postId;
        }

        private enum Command
        {
            Back,
            AddReply
        }
    }
}