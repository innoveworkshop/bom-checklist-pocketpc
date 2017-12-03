# BOM Checklist

A simple application to create checklists and other minor things related to BOMs for production. This is a tool created to make our life easier at [Innove Workshop](http://innoveworkshop.com/).

![Windows version](https://i.imgur.com/ZTdA55Z.png)


## Example BOM File

This program accepts a CSV file that is in the following format:

    "#","RefDes","Value","Quantity","Name","Category"
    "1","24V",,"1","KK-254-4","Connector"
    "2","C1, C2, C8","470u 35V","3","CAP300RP","Capacitor"
    "3","C4, C5, C6, C7, C11","100n","5","CAP200","Capacitor"
    "4","ICSP",,"1","HDR-1x4","Connector"
    "5","Q1, Q4",,"2","BC547A","Transistor"
    "6","R1, R5, R8, R9, R11, R12, R15, R24","10k","8","RES400","Resistor"
    "7","R3, R4","4.7k","2","RES400","Resistor"
    "8","R16","100k","1","3362U","Potentiometer"
    "9","U1",,"1","LM78L05ACZ","Voltage Regulator"
    "10","U3",,"1","LM324N","Op Amp"
    "11","U4",,"1","MSP430G2553","Microcontroller"
    "12","U5",,"1","24LC256P","Memory"

This is literally the CSV exported from DipTrace, but with a new column added `Category`. To get this just export the BOM from DipTrace using the following settings and add the `Category` column later in you favorite CSV editor:

![DipTrace BOM Export Settings](https://i.imgur.com/FVBZASp.png)
