unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, Menus,
  ComCtrls, Printers, StdCtrls, ExtCtrls, ValEdit, POSPrinter, BOMParser,
  XMLHelper, frmPrinterSetup;

type
  { TTreeData }
  PTreeData = ^TTreeData;
  TTreeData = class
    private
      FID: Integer;
    published
      property ID: Integer read FID write FID;
  end;

  { TMainForm }

  TMainForm = class(TForm)
    cmbCategory: TComboBox;
    grpProjectInfo: TGroupBox;
    grpComponentTree: TGroupBox;
    grpComponentDetail: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    dlgOpen: TOpenDialog;
    MenuItem3: TMenuItem;
    MenuItem4: TMenuItem;
    mnuSaveXML: TMenuItem;
    mnuPrintTestPage: TMenuItem;
    mnuPrint: TMenuItem;
    pnlRight: TPanel;
    dlgSave: TSaveDialog;
    txtQuantity: TLabeledEdit;
    txtValue: TLabeledEdit;
    txtName: TLabeledEdit;
    lstRefDes: TListBox;
    MenuItem2: TMenuItem;
    mnuSetupPrinter: TMenuItem;
    mnuExit: TMenuItem;
    mnuLoadBOM: TMenuItem;
    mnuMain: TMainMenu;
    MenuItem1: TMenuItem;
    Splitter1: TSplitter;
    statusBar: TStatusBar;
    treeComponents: TTreeView;
    vlsProjectInfo: TValueListEditor;
    procedure FormClose(Sender: TObject; var CloseAction: TCloseAction);
    procedure FormCreate(Sender: TObject);
    procedure mnuExitClick(Sender: TObject);
    procedure mnuLoadBOMClick(Sender: TObject);
    procedure mnuPrintClick(Sender: TObject);
    procedure mnuPrintTestPageClick(Sender: TObject);
    procedure mnuSaveXMLClick(Sender: TObject);
    procedure mnuSetupPrinterClick(Sender: TObject);
    procedure treeComponentsSelectionChanged(Sender: TObject);
  private
    procedure PopulateComponentTree;
    procedure ShowDetail(id: Integer);
  public
    procedure SetPrinter(pname: String; pwidth: Integer; maxline: Integer);
  end;

var
  MainForm: TMainForm;

implementation

var
  BOM: TBOMParser;
  XML: TXMLHelper;

{$R *.lfm}

{ TMainForm }

procedure TMainForm.SetPrinter(pname: String; pwidth: Integer; maxline: Integer);
begin
  SetupPrinter(pname, pwidth, maxline);
  statusBar.Panels.Items[0].Text := pname + ' set as the default printer';
end;

procedure TMainForm.FormCreate(Sender: TObject);
begin
  SetupPrinter('POS58', 58, 32);
end;

procedure TMainForm.FormClose(Sender: TObject; var CloseAction: TCloseAction);
begin
  if Assigned(BOM) then
     BOM.Destroy;
end;

procedure TMainForm.mnuExitClick(Sender: TObject);
begin
  Close;
end;

procedure TMainForm.mnuLoadBOMClick(Sender: TObject);
begin
  if dlgOpen.Execute then
  begin
    BOM := TBOMParser.Create(dlgOpen.FileName);
    BOM.ParseFile;
    XML := TXMLHelper.Create(BOM);

    PopulateComponentTree;
  end;
end;

procedure TMainForm.mnuPrintClick(Sender: TObject);
var
  i, j: Integer;
  str: String;
begin
  try
    BeginPrint(vlsProjectInfo.Values['Name']);

    PrinterJustify(JUSTIFY_CENTER);
    PrinterBold(true);
    PrintLine(vlsProjectInfo.Values['Name']);
    PrinterFeed(1);
    PrinterBold(false);
    PrintLine('Project Information');
    PrinterJustify(JUSTIFY_LEFT);

    for i := 2 to vlsProjectInfo.Strings.Count do
    begin
      PrintLine(vlsProjectInfo.Keys[i] + ': ', vlsProjectInfo.Values[vlsProjectInfo.Keys[i]]);
    end;

    PrinterFeed(1);
    PrinterJustify(JUSTIFY_CENTER);
    PrintLine('Component List');
    PrinterJustify(JUSTIFY_LEFT);

    for i := 0 to BOM.Categories.Count - 1 do
    begin
      PrintLine(BOM.Categories.Strings[i] + ':');

      for j := 0 to Length(BOM.Components) - 1 do
      begin
        if BOM.Components[j].Category = BOM.Categories.Strings[i] then
        begin
          str := IntToStr(BOM.Components[j].Quantity * StrToInt(vlsProjectInfo.Values['Quantity'])) + 'x ';

          if BOM.Components[j].Value <> '' then
             str := str + BOM.Components[j].Value + ' (' + BOM.Components[j].Name + ')'
          else
             str := str + BOM.Components[j].Name;

          PrintLine(str, '[_]');
          PrinterJustify(JUSTIFY_RIGHT);
          PrintLine(BOM.Components[j].RefDes);
          PrinterJustify(JUSTIFY_LEFT);
        end;
      end;

      PrinterFeed(1);
    end;

    PrinterJustify(JUSTIFY_CENTER);
    PrintBarcode(vlsProjectInfo.Values['Lot'], BARCODE_CODE39, true);
    PrinterCut(CUT_PREPARE);
  finally
    EndPrint;
  end;
end;

procedure TMainForm.mnuPrintTestPageClick(Sender: TObject);
begin
  try
    BeginPrint('Test Page');
    PrintTestPage(true);
    PrinterCut(CUT_PREPARE);
  finally
    EndPrint;
  end;
end;

procedure TMainForm.mnuSaveXMLClick(Sender: TObject);
begin
  if dlgSave.Execute then
  begin
    XML.PopulateProjectInfo(vlsProjectInfo.Strings);
    XML.PopulateCategories;
    XML.PopulateComponents;
    XML.Write(dlgSave.FileName);

    statusBar.Panels.Items[0].Text := 'BOM exported to "' + dlgSave.FileName + '"';
  end;
end;

procedure TMainForm.mnuSetupPrinterClick(Sender: TObject);
begin
  PrinterSetup.ShowModal;
end;

procedure TMainForm.treeComponentsSelectionChanged(Sender: TObject);
begin
  grpComponentDetail.Enabled := true;

  if not treeComponents.Selected.HasChildren then
  begin
    ShowDetail(TTreeData(treeComponents.Selected.Data).ID);
  end;
end;

{ Populates the component TreeView. }
procedure TMainForm.PopulateComponentTree;
var
  i, j: Integer;
  node: TTreeNode;
  data: TTreeData;
begin
  treeComponents.Items.Clear;
  cmbCategory.Items.Clear;

  for i := 0 to BOM.Categories.Count - 1 do
  begin
    cmbCategory.Items.Add(BOM.Categories.Strings[i]);
    node := treeComponents.Items.Add(nil, BOM.Categories.Strings[i]);

    for j := 0 to Length(BOM.Components) - 1 do
    begin
      if BOM.Components[j].Category = BOM.Categories.Strings[i] then
      begin
        data := TTreeData.Create;
        data.ID := j;

        treeComponents.Items.AddChildObject(node, BOM.Components[j].RefDes, data);
      end;
    end;

    node.Expand(true);
  end;

  statusBar.Panels.Items[0].Text := 'BOM file loaded';
end;

{ Populate the detail view. }
procedure TMainForm.ShowDetail(id: Integer);
var
  component: TComponent;
  refs: TStringList;
  i: Integer;
begin
  component := BOM.Components[id];
  refs := TStringList.Create;

  txtQuantity.Text := IntToStr(component.Quantity);
  txtValue.Text := component.Value;
  txtName.Text := component.Name;

  for i := 0 to cmbCategory.Items.Count - 1 do
  begin
    if cmbCategory.Items[i] = component.Category then
       cmbCategory.ItemIndex := i;
  end;

  refs.Clear;
  refs.Delimiter := ',';
  refs.StrictDelimiter := false;
  refs.DelimitedText := component.RefDes;
  lstRefDes.Items.Clear;
  for i := 0 to refs.Count - 1 do
  begin
    lstRefDes.Items.Add(refs.Strings[i]);
  end;
end;

end.

