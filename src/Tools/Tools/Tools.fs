namespace Naxos.Tools

open System
open System.IO

/// <summary>
/// A set of helper routine for string operations
/// </summary>
module  StringTools =

    /// String.Replace, but take a comparison 
    let ReplaceString (str:string) (oldValue:string) (newValue:string) (comparison:StringComparison )=
        let sb = System.Text.StringBuilder()
        let mutable bDoneReplacing = false
        let mutable previousIndex = 0
        while not bDoneReplacing do
            let index = str.IndexOf(oldValue, previousIndex, comparison)
            if index < 0 then 
                bDoneReplacing <- true    
            else
                sb.Append(str.Substring(previousIndex, index - previousIndex)) |> ignore
                sb.Append(newValue) |> ignore
                previousIndex <- index + oldValue.Length
        sb.Append(str.Substring(previousIndex)) |> ignore

        sb.ToString()


    /// Read a byte[] from files
    let ReadBytesFromFile (filename ) = 
        use fileStream= new FileStream( filename, FileMode.Open, FileAccess.Read )
        let len = fileStream.Seek( 0L, SeekOrigin.End )
        fileStream.Seek( 0L, SeekOrigin.Begin ) |> ignore
        if len > int64 Int32.MaxValue then 
            failwith "ReadBytesFromFile isn't capable to deal with file larger than 2GB"
        let bytes = Array.zeroCreate<byte> (int len)
        let readLen = fileStream.Read( bytes, 0, int len )
        if readLen < int len then 
            failwith (sprintf "ReadBytesFromFile failed to read to the end of file (%dB), read in %dB" len readLen )
        bytes

    /// Read an entire stream to byte[]
    let ReadToEnd (stream:Stream ) = 
        let InitialLength = 1024 * 1024
        let mutable buf = Array.zeroCreate<byte> InitialLength
        let mutable bContinueRead = true
        let mutable pos = 0 
        while bContinueRead do
            let readLen = stream.Read( buf, pos, buf.Length - pos ) 
            if readLen = 0 then 
                bContinueRead <- false
            else
                pos <- pos + readLen 
                // If we read the whole buffer, we need to extend the current byte array
                if pos = buf.Length then 
                    let newBuffer = Array.zeroCreate<byte> (buf.Length*2)
                    Buffer.BlockCopy( buf, 0, newBuffer, 0, buf.Length ) 
                    buf <- newBuffer
        let resultBuffer = Array.zeroCreate<byte> pos
        Buffer.BlockCopy( buf, 0, resultBuffer, 0, pos ) 
        resultBuffer

    let CreateFileStreamForWrite( fname ) = 
        let fStream = new FileStream( fname, FileMode.Create, Security.AccessControl.FileSystemRights.FullControl, 
                                      FileShare.Read, (1<<<20), FileOptions.Asynchronous )
        fStream

    let internal CreateFileStreamForWriteWOBuffer( fname ) = 
        let fStream = new FileStream( fname, FileMode.Create, Security.AccessControl.FileSystemRights.FullControl, 
                                      FileShare.Read, 0, FileOptions.WriteThrough )
        fStream

    let CreateFileStreamForRead( fname ) = 
        new FileStream( fname, FileMode.Open, FileAccess.Read, FileShare.Read, (1<<<20), FileOptions.SequentialScan )

