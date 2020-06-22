namespace Compilador.LexicAnalysor
{
    public enum TokenKind
    {
        // Átomos primitivos ex.: O texto literal escrito no código fonte como '1234' ou  'abcd' 
        IntegerNumber = 515,
        Character = 510,
        FloatNumber = 512,
        String = 511,
        FunctionName = 513,
        VaribleName = 514,

        Comma = 425,
        HashTag = 410,
        Quotes = 1,
        Whitespace = 0,
        
        // Identificadores de Tipo ex.: A palavra literal do tipo como 'int' ou 'float'
        FloatIdentifier = 322,
        IntIdentifier = 323,
        StringIdentifier = 317,
        BoolIdentifier = 310,
        CharIdentifier = 314,
        VoidIdentifier = 313,
                                
        // Identificadores Condicionais
        IfConditionalIdentifier = 324,
        ElseConditionalIdentifial = 316,
        WhileConditionalIdentifier = 311,
        
        // Identificadores do Programa
        ProgramIdentifier = 321,
        BeginIdentifier = 325,
        EndIdentifier = 318,
        EndOfLineIdentifier = 414,
        EndOfFile = 2,

        // Palavras-Chave
        ReturnKeyword = 319,
        BreakKeywork = 312,
        TrueKeyword = 315,
        FalseKeyword = 320,

        // Operadores Aritiméticos
        PlusOperator = 417,
        MinusOperator = 432,
        TimesOperator = 424,
        DivideOperator = 413,
        AssignOperator = 419,             // Representa o caractere '='
        ModOperator = 422,
        
        ParenthesisStart = 412,
        ParenthesisEnd = 423,
        
        BracketStart = 415,
        BracketEnd = 426,
        
        CurlyBraceStart = 416,
        CurlyBraceEnd = 428,

        // Operadores lógicos
        EqualsOperator = 430,              // Representa os caracteres '=='
        NotEqualsOperator = 410,
        
        GreaterThenOperator = 431,
        LesserThenOperator = 429,
        
        GreaterOrEqualThenOperator = 420,
        LesserOrEqualThenOperator = 418,
        
        NotOperator = 421,        
        OrOperator = 427,
        AndOperator = 411,

        // Comentários
        SingleLineComment = 3,
        
        MultiLineCommentStart = 4,
        MultiLineCommentEnd = 5,

        // Token Não identificado
        BadToken = 6,
    }
}