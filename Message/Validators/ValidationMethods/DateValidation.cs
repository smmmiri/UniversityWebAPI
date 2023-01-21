namespace Message.Validators.ValidationMethods
{
    public static class DateValidation
    {
        public static bool ValidateDateOfStudent(DateTime date)
        {
            var difference = DateTime.Now.Year - date.Year;
            return (difference <= 100) && (18 <= difference);
        }

        public static bool ValidateDateOfProfessor(DateTime date)
        {
            var difference = DateTime.Now.Year - date.Year;
            return (difference <= 100) && (25 <= difference);
        }
    }
}
