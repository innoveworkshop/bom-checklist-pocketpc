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

  { Underline types. }
  UNDERLINE_NOTHING = #00;
  UNDERLINE_LIGHT   = #01;
  UNDERLINE_HEAVY   = #02;

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

procedure PrinterUnderline(utype: Char);
procedure PrinterBold(enable: Boolean);

procedure PrintLine(line: String);
procedure PrintBarcode(number: String; btype: Char; print_num: Boolean);

procedure PrintTestPage(printcs: Boolean);

implementation
uses
  Printers, SysUtils;

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

{ Sets the underline style font. }
procedure PrinterUnderline(utype: Char);
begin
  Printer.Write(ESC + '-' + utype);
end;

procedure PrinterBold(enable: Boolean);
begin
  if enable then
     Printer.Write(ESC + 'E' + #01)
  else
     Printer.Write(ESC + 'E' + #00);
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

procedure PrintTestPage(printcs: Boolean);
var
  idx: Integer;
begin
  PrinterJustify(JUSTIFY_CENTER);
  PrintLine('ESC/POS Printer Test Page');
  PrinterFeed(1);
  PrintLine('Printer Data');
  PrinterJustify(JUSTIFY_LEFT);
  PrintLine('Name: ' + POS.Name);
  PrintLine('Paper Width: ' + IntToStr(POS.Width));
  PrintLine('Max Char. per Line: ' + IntToStr(POS.MaxCharLine));
  PrinterFeed(1);
  PrintLine('Hello world!');
  PrintLine('Forward feed 3');
  PrinterFeed(3);
  PrintLine('Reverse feed 3');
  PrinterFeed(-3);
  PrintLine('No Underline');
  PrinterUnderline(UNDERLINE_LIGHT);
  PrintLine('Light Underline');
  PrinterUnderline(UNDERLINE_HEAVY);
  PrintLine('Heavy Underline');
  PrinterUnderline(UNDERLINE_NOTHING);
  PrintLine('No emphasis');
  PrinterBold(true);
  PrintLine('With emphasis');
  PrinterBold(false);
  { TODO: Fonts here. }
  PrinterFeed(1);
  PrinterJustify(JUSTIFY_LEFT);
  PrintLine('Left');
  PrinterJustify(JUSTIFY_CENTER);
  PrintLine('Center');
  PrinterJustify(JUSTIFY_RIGHT);
  PrintLine('Right');
  PrinterJustify(JUSTIFY_CENTER);

  { Barcodes }
  for idx := 0 to 6 do
  begin
    PrintLine('Barcode ' + IntToStr(idx));
    PrintBarcode('987612', chr(idx), true);
  end;

  if printcs then
  begin
    PrinterFeed(2);
    PrintLine('Character Set');
    PrinterJustify(JUSTIFY_LEFT);

    for idx := 33 to 255 do
    begin
      PrintLine(IntToStr(idx) + ' ' + chr(idx));
    end;
  end;
end;

end.
