/* 
 *  ORIGINAL SOURCE:
 *  https://github.com/StasTserk/DndStuff/blob/b77907800beefed61e6c0a1758d5b46135f2dea1/Providers/MarkdownToAnsiRtfProvider.cs
 */

using System;
using System.Text.RegularExpressions;

static class MarkdownConvert
{
    const string ICB = "(?!.*Æ.*\n*)";

    public static string ToPangoString(string input)
    {
        input = System.Security.SecurityElement.Escape(input);//EscapeBackslash(input));

        input = AddCodeBlock(input, "\n\n<tt><span foreground='#505050' background='#e0e0e0'> ", "</span></tt>\n\n");
        input = AddTitleFormatting(input);
        input = Regex.Replace(input, @"^\s*[-\*\+]\s+", @" •  ", RegexOptions.Multiline);
        input = Regex.Replace(input, @"(\r?\n){2,}", "\n\n");
        input = ReplaceSignificantWhitespace(input);
        input = RemoveInsignificantWhitespaceFromString(input);
        input = Regex.Replace(input, @"((?!\n\s•))(\r?\n)+", " ");

        var output = AddFormatting(input.Replace("\\n", "\n")).Replace('Æ', ' ');
        return output;
    }

    private static string EscapeBackslash(string input)
    {

        var backslashRegex = new Regex(@"\\");
        return backslashRegex.Replace(input, @"\\");
    }

    private static string AddTitleFormatting(string input)
    {
        const string p1 = "\n<span weight='bold' font=", p2 = "</span>\n\n";
        input = AddFormatting(input, new Regex(@"(^|\n)###### " + ICB), new Regex("(\n|$)"), p1+"'11'>", p2, 1);
        input = AddFormatting(input, new Regex(@"(^|\n)##### " + ICB), new Regex("(\n|$)"), p1+"'12'>", p2, 1);
        input = AddFormatting(input, new Regex(@"(^|\n)#### " + ICB), new Regex("(\n|$)"), p1+"'13'>", p2, 1);
        input = AddFormatting(input, new Regex(@"(^|\n)### " + ICB), new Regex("(\n|$)"), p1+"'14'>", p2, 1);
        input = AddFormatting(input, new Regex(@"(^|\n)## " + ICB), new Regex("(\n|$)"), p1+"'15'>", p2, 1); 
        input = AddFormatting(input, new Regex(@"(^|\n)# " + ICB), new Regex("(\n|$)"), p1+"'16'>", p2, 1);
        return input;
    }

    private static string AddFormatting(string input)
    {
        input = AddFormatting(input, new Regex(@"\*\*\*" + ICB), "<b><i>", "</i></b>");
        input = AddFormatting(input, new Regex(@"\*\*" + ICB), "<b>", "</b>");
        input = AddFormatting(input, new Regex(@"\*" + ICB), "<i>", "</i>");
        input = AddFormatting(input, new Regex(@"_" + ICB), "<i>", "</i>");
        input = AddFormatting(input, new Regex(@"\~\~" + ICB), "<s>", "</s>");
        input = AddFormatting(input, new Regex(@"`" + ICB), "<tt><span foreground='#505050' background='#e0e0e0'>", "</span></tt>");
        input = Regex.Replace(input, "(^|\n|\\s)(&lt;hr&gt;|---)(\n|$|\\s)" + ICB, "\n<s><span foreground='#A0A0A0'>" + " ".PadRight(135)+"</span></s>\n");
        return input;
    }

    private static string AddFormatting(string input, Regex WrapRegex, string formatStart, string formatEnd)
    {
        return AddFormatting(input, WrapRegex, WrapRegex, formatStart, formatEnd);
    }

    private static string AddFormatting(string input, Regex PreRegex, Regex PostRegex, string PreFormat, string PostFormat, int Spacing = 1)
    {
        Match Match, Match2;
        while ((Match = PreRegex.Match(input)).Success && (Match2 = PostRegex.Match(input, Match.Index + Spacing)).Success)
        {
            input = PreRegex.Replace(input, PreFormat, 1);

            input = PostRegex.Replace(input, PostFormat, 1, Match.Index + Spacing);
        }

        return input;
    }

    private static string AddCodeBlock(string input, string PreFormat, string PostFormat)
    {
        var Regex = new Regex("```");
        Match Match, Match2;
        while ((Match = Regex.Match(input)).Success && (Match2 = Regex.Match(input, Match.Index + 3)).Success)
        {
            int lenCache = Match2.Index - Match.Index;
            int index = Match.Index, maxLength = 0, lastIndex = index, count = 0;

            while ((index = input.IndexOf("\n", index + 1, lenCache)) != -1)
            {
                if (maxLength < index - lastIndex) maxLength = index - lastIndex;
                lenCache -= index - lastIndex;
                lastIndex = index;

                count++;
            }
            index = Match.Index + 2; lastIndex = index;
            for (int i = 0; i < count; i++)
            {
                index = input.IndexOf("\n", index + 1);
                int padding = maxLength - index + lastIndex + 3;
                input = input.Insert(index, "\\n".PadLeft(padding, 'Æ'));
                index += padding;
                lastIndex = index;
            }
            input = Regex.Replace(input, PreFormat, 1);
            input = Regex.Replace(input, PostFormat, 1);
        }
        return input;
    }

    private static string ReplaceSignificantWhitespace(string input)
    {
        // Significant whitespace is 2 or more new lines
        var whitespaceRegex = new Regex(@"(\n)(\s)*(\n)");

        if (whitespaceRegex.IsMatch(input))
        {
            // Replace any Group of whitespace characters with a single space
            return whitespaceRegex.Replace(input, "\\n\\n");
        }

        return input;
    }

    private static string RemoveInsignificantWhitespaceFromString(string input)
    {
        var whitespaceRegex = new Regex(@"((?!\n\s•))\s{2,}");

        if (whitespaceRegex.IsMatch(input))
        {
            // Replace any Group of whitespace characters with a single space
            return whitespaceRegex.Replace(input, " ");
        }

        return input;
    }
}