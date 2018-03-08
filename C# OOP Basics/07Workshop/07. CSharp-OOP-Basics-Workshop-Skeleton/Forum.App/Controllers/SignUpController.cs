namespace Forum.App.Controllers
{
	using Forum.App;
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface.Contracts;

	public class SignUpController : IController, IReadUserInfoController
	{
		private const string DETAILS_ERROR = "Invalid Username or Password!";
		private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username => throw new System.NotImplementedException();

        public MenuState ExecuteCommand(int index)
        {
            throw new System.NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void ReadPassword()
        {
            throw new System.NotImplementedException();
        }

        public void ReadUsername()
        {
            throw new System.NotImplementedException();
        }
    }
}
