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
        BeginIdentifier,
        EndIdentifier,
        
        // Palavras-Chave
        ReturnKeyword,
        BreakKeywork,

        // Operadores Aritiméticos
        PlusOperator,
        MinusOperator,
        TimesOperator,
        DivideOperator,
        
        ParenthesisStart,
        ParenthesisEnd,
        BracketStart,
        BracketEnd
    }
}