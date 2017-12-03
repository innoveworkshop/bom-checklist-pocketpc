unit frmPrinterSetup;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, ExtCtrls,
  StdCtrls, Printers;

type

  { TfrmPrinterSetup }

  TfrmPrinterSetup = class(TForm)
    btSave: TButton;
    grpPrinters: TRadioGroup;
    txtMaxCharLine: TLabeledEdit;
    txtPaperWidth: TLabeledEdit;
    procedure btSaveClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { private declarations }
  public
    { public declarations }
  end;

var
  PrinterSetup: TfrmPrinterSetup;

implementation

uses
  main;

{$R *.lfm}

{ TfrmPrinterSetup }

procedure TfrmPrinterSetup.FormCreate(Sender: TObject);
var
  i: Integer;
begin
  for i := 0 to Printer.Printers.Count - 1 do
  begin
    grpPrinters.Items.Add(Printer.Printers[i]);
  end;

  grpPrinters.ItemIndex := Printer.PrinterIndex;
end;

procedure TfrmPrinterSetup.btSaveClick(Sender: TObject);
begin
  MainForm.SetPrinter(grpPrinters.Items.Strings[grpPrinters.ItemIndex], StrToInt(txtPaperWidth.Text), StrToInt(txtMaxCharLine.Text));
  Close;
end;

end.

