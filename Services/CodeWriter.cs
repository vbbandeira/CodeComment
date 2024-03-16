using CodeCommentReviewed.Contracts;
namespace CodeCommentReviewed.Services;
public class CodeWriter : ICodeWriter
{
    public void Write(char c)
    {
        Console.Write(c);
    }
}