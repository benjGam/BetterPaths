using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPaths
{
    public static class BetterPath
    {
        #region Consts

        #region Prefixes
        public const string LONG_PATH_PREFIX = "\\\\?\\";

        public const string UNC_PATH_PREFIX = "\\\\";

        public const string UNC_LONG_PATH_PREFIX = "\\\\?\\UNC\\";

        #endregion

        #region Separators

        public const char DIRECTORY_SEPARATOR_CHAR = '\\';

        public const char ALT_DIRECTORY_SEPARAROT_CHAR = '/';

        public const char VOLUME_SEPARATOR_CHAR = ':';

        public const char PATH_SEPARATOR_CHAR = ';';

        #endregion

        #region Char Collections

        public static readonly char[] InvalidPathCharsWithAdditionalChecks = new char[38]
        {
        '"', '<', '>', '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005',
        '\u0006', '\a', '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f',
        '\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019',
        '\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f', '*', '?'
        };

        public static readonly char[] InvalidFileNameChars = new char[41]
        {
        '"', '<', '>', '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005',
        '\u0006', '\a', '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f',
        '\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019',
        '\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f', ':', '*', '?', '\\',
        '/'
        };

        internal static readonly char[] s_Base32Char = new char[32]
        {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3',
        '4', '5'
        };

        #endregion

        #region Restrictions Consts

        public const int MAX_PATH_PATH = 260;

        public const int MAX_DIRECTORY_PATH_LENGTH = 248;

        public const int MAX_LONG_PATH_LENGTH = 32767;
        #endregion
        #endregion

        public static bool IsWellFormedPath(string stringToCheck)
        {
            if (stringToCheck.Length < 3)
                return false;
            if (stringToCheck[1] != VOLUME_SEPARATOR_CHAR || stringToCheck[2] != DIRECTORY_SEPARATOR_CHAR || !s_Base32Char.Contains(stringToCheck.ToLower()[0]))
                return false;
            return stringToCheck.ToList().FirstOrDefault(c => InvalidFileNameChars.Contains(c)) != default(char);
        }

        public static string GetExtension(string path)
        {
            if (!IsWellFormedPath(path))
                return null;
            int lastDotIndex = path.LastIndexOf('.');
            return lastDotIndex == -1 ? null : path.Substring(lastDotIndex, path.Length-1);
        }
    }
}
