using System.Globalization;

namespace Application.Extensions;

public static class StringExternsion
{
    public static DateTime ParseCustomDate(this string? date)
    {
        if (string.IsNullOrWhiteSpace(date))
            return DateTime.MinValue;

        string[] formats = new[] { "MM/dd/yyyy, hh:mm tt, zzz 'UTC'", "MM/dd/yyyy, hh:mm tt, zzz" };
        if (DateTimeOffset.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset dto))
            return dto.UtcDateTime;

        return DateTime.MinValue;
    }
}
