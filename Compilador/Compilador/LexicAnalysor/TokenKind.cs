namespace Compilador.LexicAnalysor
{
    public enum TokenKind
    {
        // Átomos primitivos
        Number,
        String,
        Whitespace,
        
        // Identificadores de Tipo
        FloatIdentifier,
        IntIdentifier,
        StringIdentifier,
        BoolIdentifier,
        CharIdentifier,
        VoidIdentifier,
        FunctionIdentifier,
        
        // Identificadores Condicionais
        IfConditionalIdentifier,
        ElseConditionalIdentifial,
        WhileConditionalIdentifier,
        
        // Identificadores do Programa
        ProgramIdentifier,
        BeginIdentifier,
        EndIdentifier,
        EndOfLineIdentifier,
        EndOfFile,

        // Palavras-Chave
        ReturnKeyword,
        BreakKeywork,
        TrueKeyword,
        FalseKeyword,

        // Operadores Aritiméticos
        PlusOperator,
        MinusOperator,
        TimesOperator,
        DivideOperator,
        AssignOperator,             // Representa o caractere '='
        ModOperator,
        
        ParenthesisStart,
        ParenthesisEnd,
        
        BracketStart,
        BracketEnd,
        
        CurlyBraceStart,
        CurlyBraceEnd,

        // Operadores lógicos
        EqualsOperator,              // Representa os caracteres '=='
        NotEqualsOperator,
        
        GreaterThenOperator,
        LesserThenOperator,
        
        GreaterOrEqualThenOperator,
        LesserOrEqualThenOperator,
        
        NotOperator,        
        OrOperator,
        AndOperator,

        // Comentários
        SingleLineComment,
        
        MultiLineCommentStart,
        MultiLineCommentEnd,

        // Token Não identificado
        BadToken,
    }
}