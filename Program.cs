using CodeCommentReviewed.Contracts;
using CodeCommentReviewed.Services;
public static class Program
{
    public static void Main()
    {
        string input = "// some comments \nvar result = a / b;";
        CodeCommentRemover codeCommentRemover = new CodeCommentRemover(new CodeWriter());
        foreach (char character in input)
            codeCommentRemover.TrimComment(character);
    }
}