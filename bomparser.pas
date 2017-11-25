unit BOMParser;
{$mode objfpc}{$H+}

{ This is a very simple CSV parser. I know there is CSVDocument, but I just   }
{ wanted a simple implementation that is more customized and easier to use in }
{ this project.                                                               }

interface
uses
  Classes, SysUtils;

type
  TComponent = record
    ID: Integer;
    RefDes: String;
    Value: String;
    Quantity: Integer;
    Name: String;
    Category: String;
  end;

  TBOMParser = class
    private
      CSVFile: TextFile;
      num_lines: Integer;

      procedure GetNumLines(filepath: String);
    public
      Components: array of TComponent;

      constructor Create(filepath: String); overload;
      destructor Destroy; override;
      procedure ParseFile(delimiter: Char = ',');
  end;

implementation

{ Function to get the number of lines in the file. }
procedure TBOMParser.GetNumLines(filepath: String);
var
  f: TextFile;
  count: Integer;
begin
  Assign(f, filepath);
  Reset(f);
  count := 0;

  while not EOF(f) do
  begin
    ReadLn(f);
    count := count + 1;
  end;

  num_lines := count;
  Close(f);

  WriteLn('File has ' + IntToStr(count) + ' lines');
end;

{ Constructor that will open the CSV file for parsing. }
constructor TBOMParser.Create(filepath: String);
begin
  GetNumLines(filepath);

  Assign(CSVFile, filepath);
  Reset(CSVFile);
end;

{ Destructor to close the CSV file. }
destructor TBOMParser.Destroy;
begin
  Close(CSVFile);
end;

{ Parses the CSV file and splits the columns in each line. }
procedure TBOMParser.ParseFile(delimiter: Char = ',');
var
  line: String;
  count, idx: Integer;
  at_header: Boolean;
  cols: TStringList;
begin
  count := 0;
  cols := TStringList.Create;

  { Ignore the header. }
  at_header := true;
  SetLength(Components, num_lines - 1);

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

      WriteLn('Line ' + IntToStr(count) + ': ' + line);
      for idx := 0 to cols.Count - 1 do
      begin
        WriteLn('Col ' + IntToStr(idx) + ': ' + cols.Strings[idx]);
      end;

      WriteLn('');

      { Create the component and populate the array. }
      Components[count].ID := StrToInt(cols.Strings[0]);
      Components[count].RefDes := cols.Strings[1];
      Components[count].Value := cols.Strings[2];
      Components[count].Quantity := StrToInt(cols.Strings[3]);
      Components[count].Name := cols.Strings[4];
      Components[count].Category := cols.Strings[5];

      count := count + 1;
    end;

    at_header := false;
  end;
end;

end.

