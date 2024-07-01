using System.Text.RegularExpressions;
public class HTMLParser
{
    public static string CheckHTMLElements(string str)
    {
        // Use a stack to keep track of opening tags
        Stack<string> stack = new Stack<string>();

        // Regular expression to match HTML tags
        Regex tagPattern = new Regex(@"<\/?([a-z]+)>");
        MatchCollection matches = tagPattern.Matches(str);

        // Iterate through each matched tag in the string
        foreach (Match match in matches)
        {
            string tag = match.Value;
            bool isOpeningTag = tag[1] != '/';
            string tagName = isOpeningTag ? tag.Substring(1, tag.Length - 2) : tag.Substring(2, tag.Length - 3);

            if (isOpeningTag)
            {
                // Push opening tags onto the stack
                stack.Push(tagName);
            }
            else
            {
                // If closing tag, check if it matches the top of the stack
                if (stack.Count == 0 || stack.Peek() != tagName)
                {
                    // If not, return the tag that caused the issue
                    return isOpeningTag ? tagName : stack.Count > 0 ? stack.Peek() : tagName;
                }
                else
                {
                    // If it matches, pop the top of the stack
                    stack.Pop();
                }
            }
        }

        // If stack is not empty after processing all tags, return the remaining opening tag
        return stack.Count == 0 ? "true" : stack.Peek();
    }
    public static Stack<string> HTMLElements(string str)
    {
        Stack<string> stack = new Stack<string>();

        string val = string.Empty;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '<')
            {
                val += str[i + 1];
            }
            if (str[i] == '>')
            {
                stack.Push(val);
            }
        }
        return stack;
    }

    public static string CheckHTMLElements1(string str)
    {
        // Stack to keep track of opening tags
        Stack<string> stack = new Stack<string>();

        // Manually parse the string to find tags
        int i = 0;
        while (i < str.Length)
        {
            if (str[i] == '<')
            {
                int end = str.IndexOf('>', i);
                if (end == -1) break;

                string tag = str.Substring(i, end - i + 1);
                i = end + 1;

                if (tag[1] != '/')
                {
                    // Push opening tag onto the stack
                    stack.Push(tag);
                }
                else
                {
                    // Handle closing tag
                    string openingTag = tag.Substring(0, 1) + tag.Substring(2);

                    if (stack.Count == 0 || stack.Peek() != openingTag)
                    {
                        // Return the problematic tag
                        return stack.Count == 0 ? tag.Substring(2, tag.Length - 3) : stack.Peek().Substring(1, stack.Peek().Length - 2);
                    }
                    else
                    {
                        // Pop the matched opening tag from the stack
                        stack.Pop();
                    }
                }
            }
            else
            {
                i++;
            }
        }

        // If stack is not empty, return the first unmatched opening tag
        return stack.Count == 0 ? "true" : stack.Peek().Substring(1, stack.Peek().Length - 2);
    }

/*    public static void Main()
    {
        Console.WriteLine(HTMLParser.CheckHTMLElements1("<div><div><b></b></div></p>")); // Output: div
        Console.WriteLine(HTMLParser.CheckHTMLElements1("<div>abc</div><p><em><i>test test test</b></em></p>")); // Output: i
        Console.WriteLine(HTMLParser.CheckHTMLElements1("<div><b><p>hello world</p></b></div>")); // Output: true
    }
    */
}