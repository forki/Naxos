namespace Naxos

open System
open System.Collections.Generic

/// Utilities
module Utils =
    // Null checks
    // See: http://latkin.org/blog/2015/05/18/null-checking-considerations-in-f-its-harder-than-you-think/

    /// Returns true if 'value' is null
    let inline IsNull value = obj.ReferenceEquals(value, null)

    /// Returns true if 'value' is not null
    let inline IsNotNull value = not (obj.ReferenceEquals(value, null))

/// <summary>
/// The class is constructured to take a comparer of string, and a type T that supports equality, and construct a new comparer
/// </summary>
type StringTComparer<'T when 'T:equality>=
    ///  comparer of string used. 
    val private _comp : StringComparer
    /// Constract a comparer that compares a tuple of String*'T, in which 'T supports equality, and comp is a comparer of string
    new  ( comp ) = { _comp = comp }
    interface IEqualityComparer<string*'T> with
        /// Determines whether the specified string are equal.
        override this.Equals (x, y) = 
            let xstring, xval = x
            let ystring, yval = y
            ( this._comp.Equals( xstring, ystring ) && (xval = yval) )
         /// Returns a hash code for the specified string.
        override this.GetHashCode (x) = 
            let xstring, xval = x
            if Utils.IsNull xstring then 
                xval.GetHashCode()
            else
                (17 * 23 + this._comp.GetHashCode( xstring )) * 23 + xval.GetHashCode()