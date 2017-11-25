unit BOMParser;
{$mode objfpc}{$H+}

{ This is a very simple CSV parser. I know there is CSVDocument, but I just   }
{ wanted a simple implementation that is more customized and easier to use in }
{ this project.                                                               }

interface
uses
  Classes, SysUtils;

type
  TBOMParser = class
    private
      CSVFile: TextFile;
    public
      constructor Create(filepath: String); overload;
      destructor Destroy; override;
      procedure ParseFile(ignore_header: Boolean = true; delimiter: Char = ',');
  end;

implementation

{ Constructor that will open the CSV file for parsing. }
constructor TBOMParser.Create(filepath: String);
begin
  Assign(CSVFile, filepath);
  Reset(CSVFile);
end;

{ Destructor to close the CSV file. }
destructor TBOMParser.Destroy;
begin
  Close(CSVFile);
end;

procedure TBOMParser.ParseFile(ignore_header: Boolean = true; delimiter: Char = ',');
var
  line: String;
  i, idx: Integer;
  at_header: Boolean;
  cols: TStringList;
begin
  i := 0;
  cols := TStringList.Create;

  if ignore_header then
     at_header := true
  else
     at_header := false;

  while not EOF(CSVFile) do
  begin
    ReadLn(CSVFile, line);

    if not at_header then
    begin
      { Splits the line into columns. }
      cols.Clear;
      cols.Delimiter := ',';
      cols.StrictDelimiter := true;
      cols.DelimitedText := line;

      WriteLn('Line ' + IntToStr(i) + ': ' + line);
      for idx := 0 to cols.Count - 1 do
      begin
        WriteLn('Col ' + IntToStr(idx) + ': ' + cols.Strings[idx]);
      end;

      WriteLn('');
    end;

    at_header := false;
    i := i + 1;
  end;
end;

end.

