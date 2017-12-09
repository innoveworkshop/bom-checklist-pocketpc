program BOM_Checklist;

{$mode objfpc}{$H+}

uses
  {$IFDEF UNIX}{$IFDEF UseCThreads}
  cthreads,
  {$ENDIF}{$ENDIF}
  Interfaces, // this includes the LCL widgetset
  Forms, printer4lazarus, main, frmPrinterSetup, BOMParser, POSPrinter
  { you can add units after this };

{$R *.res}

begin
  Application.Title:='Production Assistant';
  RequireDerivedFormResource:=True;
  Application.Initialize;
  Application.CreateForm(TMainForm, MainForm);
  Application.CreateForm(TfrmPrinterSetup, PrinterSetup);
  Application.Run;
end.

