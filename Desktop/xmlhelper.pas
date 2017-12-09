unit XMLHelper;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, DOM, XMLWrite, BOMParser;

type
  TXMLHelper = class
    private
      function StripNonLetterCharacters(str: String): String;
    public
      constructor Create(bom_obj: TBOMParser); overload;
      destructor Destroy; override;

      procedure PopulateProjectInfo(list: TStringList);
      procedure PopulateCategories;
      procedure PopulateComponents;
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

{ Strips any non-letter characters. }
function TXMLHelper.StripNonLetterCharacters(str: String): String;
var
  tmp: String;
  i: Integer;
begin
  tmp := '';

  for i := 0 to Length(str) do
  begin
    if ((str[i] >= #65) and (str[i] <= #90)) or ((str[i] >= #97) and (str[i] <= #122)) then
       tmp := tmp + str[i];
  end;

  StripNonLetterCharacters := tmp;
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
    child := Document.CreateElement(LowerCase(StripNonLetterCharacters(list.Names[i])));
    data := Document.CreateTextNode(list.ValueFromIndex[i]);
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

{ Create each of the component group nodes. }
procedure TXMLHelper.PopulateComponents;
var
  parent, child, item, subitem, data: TDOMNode;
  refs: TStringList;
  i, j, k: Integer;
begin
  for i := 0 to BOM.Categories.Count - 1 do
  begin
    parent := Document.CreateElement('group');
    TDOMElement(parent).SetAttribute('category', BOM.Categories.Strings[i]);

    for j := 0 to Length(BOM.Components) - 1 do
    begin
      if BOM.Components[j].Category = BOM.Categories.Strings[i] then
      begin
        child := Document.CreateElement('component');
        TDOMElement(child).SetAttribute('id', IntToStr(BOM.Components[j].ID));
        TDOMElement(child).SetAttribute('checked', 'false');

        item := Document.CreateElement('quantity');
        data := Document.CreateTextNode(IntToStr(BOM.Components[j].Quantity));
        item.AppendChild(data);
        child.AppendChild(item);

        item := Document.CreateElement('value');
        data := Document.CreateTextNode(BOM.Components[j].Value);
        item.AppendChild(data);
        child.AppendChild(item);

        item := Document.CreateElement('name');
        data := Document.CreateTextNode(BOM.Components[j].Name);
        item.AppendChild(data);
        child.AppendChild(item);

        item := Document.CreateElement('references');
        TDOMElement(item).SetAttribute('text', BOM.Components[j].RefDes);

        refs := TStringList.Create;
        refs.Clear;
        refs.Delimiter := ',';
        refs.StrictDelimiter := false;
        refs.DelimitedText := BOM.Components[j].RefDes;
        for k := 0 to refs.Count - 1 do
        begin
          subitem := Document.CreateElement('refdes');
          data := Document.CreateTextNode(refs.Strings[k]);
          subitem.AppendChild(data);
          item.AppendChild(subitem);
        end;

        child.AppendChild(item);
        parent.AppendChild(child);
      end;
    end;

    root.AppendChild(parent);
  end;
end;

{ Writes the XML file. }
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

