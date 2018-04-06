namespace P02ExtendedDatabase
{
    public static class ErrorMessages
    {
        public static string LengthMoreThanCapacity = "Database elements count cannot be more than capacity";

        public static string EmptyData = "Cannot remove element from empty database";

        public static string IdIsTaken = "Id is already taken";

        public static string UsernameIsTaken = "Username is already taken";

        public static string UsernameDoesntExist = "Username does not exist in database";

        public static string InvalidUsername = "Username cannot be null";

        public static string IdDoesNotExist = "Id does not exist in database";

        public static string InvalidId = "Id cannot be negative";
    }
}
