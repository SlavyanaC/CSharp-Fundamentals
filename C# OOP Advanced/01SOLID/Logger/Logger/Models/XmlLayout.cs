namespace Logger.Models
{
    using Logger.Models.Interfaces;
    using System;
    using System.Globalization;

    public class XmlLayout : ILayout
    {
        const string DateFormat = "HH:mm:ss dd-MMM-yyyy";

        private string Format = "<log>" + Environment.NewLine +
                                    "\t<date>{0}</date>" + Environment.NewLine +
                                    "\t<level>{1}</level>" + Environment.NewLine +
                                    "\t<message>{1}</message>" + Environment.NewLine+
                                "</log>";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            string formattedError = string.Format(Format, dateString, error.Level.ToString(), error.Mesage);

            return formattedError;
        }
    }
}
