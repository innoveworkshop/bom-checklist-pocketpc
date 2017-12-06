unit XMLHelper;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, DOM, XMLWrite, StrUtils, BOMParser;

type
  TXMLHelper = class
    private
      {}
    public
      constructor Create(bom_obj: TBOMParser); overload;
      destructor Destroy; override;

      procedure PopulateProjectInfo(list: TStringList);
      procedure PopulateCategories;
      procedure Write(filename: String);
  end;

implementation

var
  BOM: TBOMParser;
  Document: TXMLDocument;
  root: TDOMNode;

{ Class constructor. }
constructor TXMLHelper.Create(bom_obj: TBOMParser);
begin
  BOM := bom_obj;
  Document := TXMLDocument.Create;
  root := Document.CreateElement('project');

  Document.AppendChild(root);
  root := Document.DocumentElement;
end;

{ Creates the project information node. }
procedure TXMLHelper.PopulateProjectInfo(list: TStringList);
var
  parent, child, data: TDOMNode;
  i: Integer;
begin
  parent := Document.CreateElement('info');

  for i := 0 to list.Count - 1 do
  begin
    WriteLn(IntToStr(i) + ' "' + list.Names[i] + '"');
    child := Document.CreateElement(list.Names[i]);//list.Names[i]);
    data := Document.CreateTextNode('test');//list.ValueFromIndex[i]);
    child.AppendChild(data);
    parent.AppendChild(child);
  end;

  root.AppendChild(parent);
end;

{ Create the categories node. }
procedure TXMLHelper.PopulateCategories;
var
  parent, child, data: TDOMNode;
  i: Integer;
begin
  parent := Document.CreateElement('categories');

  for i := 0 to BOM.Categories.Count - 1 do
  begin
    child := Document.CreateElement('category');
    data := Document.CreateTextNode(BOM.Categories.Strings[i]);
    child.AppendChild(data);
    parent.AppendChild(child);
  end;

  root.AppendChild(parent);
end;

procedure TXMLHelper.Write(filename: String);
begin
  WriteXML(Document, filename);
end;

{ Class destructor. }
destructor TXMLHelper.Destroy;
begin
  Document.Free;
end;

end.

