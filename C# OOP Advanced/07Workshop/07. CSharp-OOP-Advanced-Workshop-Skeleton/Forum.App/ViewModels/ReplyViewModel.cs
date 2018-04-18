namespace Forum.App.ViewModels
{
    using Forum.App.Contracts;

    class ReplyViewModel : IReplyViewModel
    {
        public ReplyViewModel(string author, string[] content)
        {
            this.Author = author;
            this.Content = content;
        }

        public string Author { get; }

        public string[] Content { get; }
    }
}
