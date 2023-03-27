using System.Buffers;
using System.Buffers.Text;
using System.Runtime.InteropServices;

namespace Base64Guid;
public class Guider
{
    private const char EqualChar = '=';
    private const char SlashChar = '/';
    private const char PlusChar = '+';
    private const char UnderscoreChar = '_';
    private const char DashChar = '-';

    private const byte SlashByte = (byte)'/';
    private const byte PlusByte = (byte)'+';
    private const byte EqualByte = (byte)'=';

    public static string ToStringFromGuid(Guid id)
    {
        Span<byte> bytes = stackalloc byte[16];
        Span<byte> base64Bytes = stackalloc byte[24];
        
        MemoryMarshal.TryWrite(bytes, ref id);
        Base64.EncodeToUtf8(bytes, base64Bytes, out _, out _);

        Span<char> finalChars = stackalloc char[22];

        for (var i = 0; i < 22; i++)
        {
            finalChars[i] = base64Bytes[i] switch
            {
                SlashByte => DashChar,
                PlusByte => UnderscoreChar,
                _ => (char) base64Bytes[i]
            };
        }

        return new string(finalChars);
    }

    public static Guid ToGuidFromString(ReadOnlySpan<char> id)
    {
        Span<char> base64Chars = stackalloc char[24];

        for (var i = 0; i < 22; i++)
        {
            base64Chars[i] = id[i] switch
            {
                '-' => SlashChar,
                '_' => PlusChar,
                _ => id[i]
            };
        }
        
        base64Chars[22] = EqualChar;
        base64Chars[23] = EqualChar;
        
        Span<byte> bytes = stackalloc byte[16];
        
        Convert.TryFromBase64Chars(base64Chars, bytes, out _);

        return new Guid(bytes);
    }
}
