unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, Menus,
  ComCtrls, Printers, StdCtrls, ExtCtrls, Grids, ValEdit, POSPrinter, BOMParser,
  frmPrinterSetup;

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
    mnuPrint: TMenuItem;
    pnlRight: TPanel;
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

{$R *.lfm}

{ TMainForm }

procedure TMainForm.SetPrinter(pname: String; pwidth: Integer; maxline: Integer);
begin
  SetupPrinter(pname, pwidth, maxline);
  statusBar.Panels.Items[0].Text := pname + ' set as the default printer';

  {try
    BeginPrint('Test Page');
    PrintTestPage(false);
    PrinterCut(CUT_PREPARE);
  finally
    EndPrint;
  end;}
end;

procedure TMainForm.FormCreate(Sender: TObject);
begin
  BOM := TBOMParser.Create('test.csv');
  BOM.ParseFile;

  PopulateComponentTree;
  SetupPrinter('POS58', 58, 42);
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

    PopulateComponentTree;
  end;
end;

procedure TMainForm.mnuPrintClick(Sender: TObject);
begin
  { TODO: Print the stuff. }
  WriteLn(vlsProjectInfo.Strings.Strings[0]);
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

