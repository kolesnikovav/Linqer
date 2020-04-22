namespace Linqer
{
    /// <summary>
    /// Determine comparison type.
    /// </summary>
   
    public enum PredicateType
    {
    /// <summary>
    /// Represents equality comparison type.
    /// </summary>        
   
        Equal,
    /// <summary>
    /// Represents non equality comparison type.
    /// </summary>         
        NotEqual,
    /// <summary>
    /// Represents greater than comparison type.
    /// </summary>        
        GreaterThan, 
    /// <summary>
    /// Represents greater than or equal comparison type.
    /// </summary>          
        GreaterThanOrEqual,
    /// <summary>
    /// Represents less than comparison type.
    /// </summary>         
        LessThan,
    /// <summary>
    /// Represents less than or equal comparison type.
    /// </summary>         
        LessThanOrEqual
    }
}