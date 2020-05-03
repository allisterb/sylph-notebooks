open System.IO
open Microsoft.FSharp.Quotations

open Sylvester
open Descriptions

let registerExpr (expr:Expr) (writer:TextWriter) = 
    writer.Write(expr.ToString())

let registerAD (ad:AxiomDescription list) (writer:TextWriter) = 
    writer.Write(ad.ToString())

let registerExpr2 (expr:Expr*Expr) (writer:TextWriter) = 
    let (e1, e2) = expr in writer.Write(sprintf "%s, %s" (e1.ToString()) (e2.ToString()))

do Formatter<Expr>.Register( (fun df writer -> registerExpr df writer), mimeType = "text/html")
do Formatter<Expr * Expr>.Register( (fun df writer -> registerExpr2 df writer), mimeType = "text/html")
do Formatter<AxiomDescription list>.Register( (fun df writer -> registerAD df writer), mimeType = "text/html")