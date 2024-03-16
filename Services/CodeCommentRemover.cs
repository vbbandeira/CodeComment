using CodeCommentReviewed.Contracts;
namespace CodeCommentReviewed.Services;
public class CodeCommentRemover(ICodeWriter _codeWriter) : ICodeCommentRemover
{
    private char currentValue = char.MinValue;
    private char previousValue = char.MinValue;
    private bool isAComment = false;

    public void TrimComment(char c)
    {
        PersistValue(c);
        if (IsACommentVerifier(c)) return;
        CodePrinter(c);
    }

    private void PersistValue(char c)
    {
        previousValue = currentValue;
        currentValue = c;
    }

    private bool IsACommentVerifier(char c)
    {
        if(isAComment && c != '\n')
        {
            return true;
        }
        if (currentValue == '\n')
        {
            isAComment = false;
            return false;
        }
        if (previousValue == '/' && c == '/')
        {
            isAComment = true;
            return true;
        }
        return false;
    }

    private void CodePrinter(char c)
    {
        if (c == '/' && previousValue == char.MinValue) return;
        if (previousValue == '/' && c != '/') _codeWriter.Write(previousValue);
        _codeWriter.Write(c);
    }
}