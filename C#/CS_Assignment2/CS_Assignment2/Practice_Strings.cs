using System.Text;
using System.Text.RegularExpressions;

namespace CS_Assignment2;

public class Practice_Strings
{
    public void q1(string str)
    {
        StringBuilder str1 = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            str1.Append(str[i]);
        }
        string val = str1.ToString();
        Console.WriteLine($"Reversed String is: {val}");
    }

    public void q2(string str)
    {
        string pattern = @"([.,:;=()&\[\]""'\\\/!? ]+)";
        Regex reg= new Regex(pattern);
        string[] token = reg.Split(str);
        Array.Reverse(token);
        string ans = string.Concat(token);
        Console.WriteLine(ans);
    }

    public void q3(string text)
    {
        static IEnumerable<string> ExtractPalindromes(string text)
        {
            string pattern = @"\w+";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(text);
            HashSet<string> uniquePalindromes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (Match match in matches)
            {
                string word = match.Value;
                if (IsPalindrome(word))
                {
                    uniquePalindromes.Add(word);
                }
            }
            return uniquePalindromes.OrderBy(p => p, StringComparer.OrdinalIgnoreCase);
        }
        static bool IsPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;
            while (left < right)
            {
                if (char.ToLower(word[left]) != char.ToLower(word[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        
        var palindromes = ExtractPalindromes(text);
        Console.WriteLine("Palindromes:");
        Console.WriteLine(string.Join(", ", palindromes));
    }

    public void q4(string url)
    {
        static (string protocol, string server, string resource) ParseUrl(string url)
        {
            string pattern = @"^(?:(?<protocol>\w+):\/\/)?(?<server>[\w.-]+)(?:\/(?<resource>.*))?$";
            var match = Regex.Match(url, pattern);
            string protocol = match.Groups["protocol"].Value;
            string server = match.Groups["server"].Value;
            string resource = match.Groups["resource"].Value;
            if (string.IsNullOrEmpty(server))
            {
                throw new ArgumentException("The server part is mandatory in the URL.");
            }

            return (protocol, server, resource);
        }
        
        var parts = ParseUrl(url);
        Console.WriteLine("[protocol] = \"" + parts.protocol + "\"");
        Console.WriteLine("[server] = \"" + parts.server + "\"");
        Console.WriteLine("[resource] = \"" + parts.resource + "\"");        
    }
}