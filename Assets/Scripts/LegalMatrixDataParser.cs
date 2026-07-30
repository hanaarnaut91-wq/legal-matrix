using System;
using System.Collections.Generic;

public enum LegalMatrixAnswer
{
    Unanswered,
    Yes,
    No
}

[Serializable]
public sealed class LegalMatrixQuestion
{
    public string Text;
    public int SourceLineIndex;
    public LegalMatrixAnswer Answer;
}

[Serializable]
public sealed class LegalMatrixLawBlock
{
    public string LawName;
    public int LawNameLineIndex;
    public int EqualsLineIndex;
    public int PercentLineIndex;
    public readonly List<LegalMatrixQuestion> Questions = new List<LegalMatrixQuestion>();
}

[Serializable]
public sealed class LegalMatrixRisk
{
    public string Category;
    public int Severity;
    public string Article;
    public string Explanation;
    public string Recommendation;
}

[Serializable]
public sealed class LegalMatrixRiskBlock
{
    public string LawName;
    public readonly List<LegalMatrixRisk> Risks = new List<LegalMatrixRisk>();
}

public static class LegalMatrixDataParser
{
    public static List<LegalMatrixLawBlock> ParseQuestionBlocks(string[] lines)
    {
        var blocks = new List<LegalMatrixLawBlock>();

        if (lines == null)
            return blocks;

        LegalMatrixLawBlock currentBlock = null;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = Clean(lines[i]);

            if (line == "=")
            {
                int lawNameIndex = FindPreviousNonEmptyLine(lines, i - 1);
                string lawName = lawNameIndex >= 0 ? Clean(lines[lawNameIndex]) : "Nepoznat zakon";

                currentBlock = new LegalMatrixLawBlock
                {
                    LawName = lawName,
                    LawNameLineIndex = lawNameIndex,
                    EqualsLineIndex = i,
                    PercentLineIndex = -1
                };

                blocks.Add(currentBlock);
                continue;
            }

            if (line == "%")
            {
                if (currentBlock != null)
                    currentBlock.PercentLineIndex = i;

                currentBlock = null;
                continue;
            }

            if (currentBlock == null || string.IsNullOrWhiteSpace(line))
                continue;

            currentBlock.Questions.Add(new LegalMatrixQuestion
            {
                Text = RemoveAnswerMarker(line),
                SourceLineIndex = i,
                Answer = GetAnswer(line)
            });
        }

        return blocks;
    }

    public static List<LegalMatrixRiskBlock> ParseRiskBlocks(string[] lines)
    {
        var blocks = new List<LegalMatrixRiskBlock>();

        if (lines == null)
            return blocks;

        LegalMatrixRiskBlock currentBlock = null;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = Clean(lines[i]);

            if (line == "=")
            {
                int lawNameIndex = FindPreviousNonEmptyLine(lines, i - 1);
                string lawName = lawNameIndex >= 0 ? Clean(lines[lawNameIndex]) : "Nepoznat zakon";

                currentBlock = new LegalMatrixRiskBlock
                {
                    LawName = lawName
                };

                blocks.Add(currentBlock);
                continue;
            }

            if (line == "%")
            {
                currentBlock = null;
                continue;
            }

            if (currentBlock == null || string.IsNullOrWhiteSpace(line))
                continue;

            LegalMatrixRisk risk;
            if (TryParseRisk(line, out risk))
                currentBlock.Risks.Add(risk);
        }

        return blocks;
    }

    public static bool TryParseRisk(string input, out LegalMatrixRisk risk)
    {
        risk = null;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        string[] parts = input.Split(new[] { '|' }, 5, StringSplitOptions.None);

        int severity;
        if (parts.Length != 5 || !int.TryParse(parts[1].Trim(), out severity))
            return false;

        risk = new LegalMatrixRisk
        {
            Category = parts[0].Trim(),
            Severity = severity,
            Article = parts[2].Trim(),
            Explanation = parts[3].Trim(),
            Recommendation = parts[4].Trim()
        };

        return true;
    }

    public static string RemoveAnswerMarker(string line)
    {
        string result = Clean(line);

        while (result.EndsWith("@", StringComparison.Ordinal) ||
               result.EndsWith("#", StringComparison.Ordinal))
        {
            result = result.Substring(0, result.Length - 1).TrimEnd();
        }

        return result;
    }

    public static LegalMatrixAnswer GetAnswer(string line)
    {
        string cleaned = Clean(line);

        if (cleaned.EndsWith("@", StringComparison.Ordinal))
            return LegalMatrixAnswer.Yes;

        if (cleaned.EndsWith("#", StringComparison.Ordinal))
            return LegalMatrixAnswer.No;

        return LegalMatrixAnswer.Unanswered;
    }

    public static string Clean(string value)
    {
        return value == null ? string.Empty : value.Trim().TrimEnd('\r');
    }

    private static int FindPreviousNonEmptyLine(string[] lines, int startIndex)
    {
        for (int i = startIndex; i >= 0; i--)
        {
            if (!string.IsNullOrWhiteSpace(lines[i]))
                return i;
        }

        return -1;
    }
}
