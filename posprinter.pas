unit POSPrinter;

{ This is basically a nice wrapper for the ESC/POS protocol. }
{ For more information you can check:                        }
{ Specification Document: http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf }
{ Programming Guide: http://download.delfi.com/SupportDL/Epson/Manuals/TM-T88IV/Programming%20manual%20APG_1005_receipt.pdf }

interface
const
  { Characters used by the ESC/POS protocol. }
  ESC = #27;
  GS  = #29;
  LF  = #10;
  NUL = #00;

  { Barcode types. }
  BARCODE_UPCA    = #00;
  BARCODE_UPCE    = #01;
  BARCODE_JAN13   = #02;
  BARCODE_JAN8    = #03;
  BARCODE_CODE39  = #04;
  BARCODE_ITF     = #05;
  BARCODE_CODABAR = #06;

  { Justification types. }
  JUSTIFY_LEFT   = #00;
  JUSTIFY_CENTER = #01;
  JUSTIFY_RIGHT  = #02;

  { Cut types. }
  CUT_PARTIAL = #66;
  CUT_FULL    = #65;
  CUT_PREPARE = #00;

type
  TPOSPrinter = record
    Name: String;
    Width: Integer;
    MaxCharLine: Integer;
  end;

var
  POS: TPOSPrinter;

procedure SetupPrinter(name: String; width: Integer; max_char: Integer);
procedure BeginPrint(title: String);
procedure EndPrint;

procedure PrinterFeed(num: Integer);
procedure PrinterCut(ctype: Char);
procedure PrinterJustify(jtype: Char);

procedure PrintLine(line: String);
procedure PrintBarcode(number: String; btype: Char; print_num: Boolean);

implementation
uses
  Printers;

{ Sets the printer stuff. }
procedure SetupPrinter(name: String; width: Integer; max_char: Integer);
begin
  POS.Name := name;
  POS.Width := width;
  POS.MaxCharLine := max_char;

  Printer.SetPrinter(name);
  Printer.RawMode := true;
end;

{ Begins the printing process. }
procedure BeginPrint(title: String);
begin
  Printer.Title := title;
  Printer.BeginDoc;
  Printer.Write(ESC + '@');  { Resets the printer formatting. }
end;

{ Ends the printing process. }
procedure EndPrint;
begin
  Printer.EndDoc;
end;

{ Line feeds. }
procedure PrinterFeed(num: Integer);
begin
  if num > 0 then
     Printer.Write(ESC + 'd' + chr(num))
  else if num < 0 then
     Printer.Write(ESC + 'v' + chr(num + (num * 2)));
end;

{ Cuts the paper. }
procedure PrinterCut(ctype: Char);
begin
  if ctype = CUT_PREPARE then
     PrinterFeed(3)
  else
     Printer.Write(ESC + 'V' + ctype);
end;

{ Change the print justification. }
procedure PrinterJustify(jtype: Char);
begin
  Printer.Write(ESC + 'a' + jtype);
end;

{ Prints a standard text line. }
procedure PrintLine(line: String);
begin
  Printer.Write(line + LF);
end;

{ Prints a barcode. }
procedure PrintBarcode(number: String; btype: Char; print_num: Boolean);
begin
  Printer.Write(GS + 'k' + btype + number + NUL);

  { Print the number below the barcode. }
  if print_num then
  begin
     PrintLine(number);
  end;
end;

end.
