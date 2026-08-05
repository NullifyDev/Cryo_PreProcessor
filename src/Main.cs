namespace Cryo;

public class PreProcessor
{
    public IEnumerable<Object> GetMethods(string file) {
        foreach(var n in new Converter(new Parser(new Lexer(file).Lex()).Parse().ToArray()).Convert())
            if (n is Cryo.Method)
                yield return (n as Cryo.Method)!;
    }

    public Object GetMethod(string file)
    {
        var o = new Converter(new Parser(new Lexer(file).Lex()).Parse().ToArray()).Convert().GetEnumerator();
        o.MoveNext();
        return o.Current;
    }
}