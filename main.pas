unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, Menus,
  ComCtrls, Printers, POSPrinter, BOMParser;

type

  { TMainForm }

  TMainForm = class(TForm)
    MenuItem2: TMenuItem;
    mnuSetupPrinter: TMenuItem;
    mnuExit: TMenuItem;
    mnuLoadBOM: TMenuItem;
    mnuMain: TMainMenu;
    MenuItem1: TMenuItem;
    statusBar: TStatusBar;
    procedure FormClose(Sender: TObject; var CloseAction: TCloseAction);
    procedure FormCreate(Sender: TObject);
    procedure MenuItem1Click(Sender: TObject);
    procedure mnuExitClick(Sender: TObject);
    procedure mnuLoadBOMClick(Sender: TObject);
    procedure mnuSetupPrinterClick(Sender: TObject);
  private
    { private declarations }
  public
    { public declarations }
  end;

var
  MainForm: TMainForm;

implementation

var
  BOM: TBOMParser;

{$R *.lfm}

{ TMainForm }

procedure TMainForm.MenuItem1Click(Sender: TObject);
begin

end;

procedure TMainForm.FormCreate(Sender: TObject);
begin
  BOM := TBOMParser.Create('test.csv');
  BOM.ParseFile;
  {SetupPrinter('POS58', 58, 42);

  try
    BeginPrint('Test Page');
    PrintTestPage(false);
    PrinterCut(CUT_PREPARE);
  finally
    EndPrint;
  end;}
end;

procedure TMainForm.FormClose(Sender: TObject; var CloseAction: TCloseAction);
begin
  BOM.Destroy;
end;

procedure TMainForm.mnuExitClick(Sender: TObject);
begin
  Close;
end;

procedure TMainForm.mnuLoadBOMClick(Sender: TObject);
begin
  { TODO: Load the BOM file. }
end;

procedure TMainForm.mnuSetupPrinterClick(Sender: TObject);
begin
  { TODO: Open the printer setup form. }
end;

end.

