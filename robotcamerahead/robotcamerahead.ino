#include <TimerOne.h>

const int xpluspin = 4;
const int xminuspin = 5;
const int ypluspin = 6;
const int yminuspin = 7;
int inByte = 0;
String message = "";
String xString = "";
String yString = "";
int Xval, Yval;
char inChar;
boolean stringComplete = false;
int xpos, ypos, delimiterpos, endpos;
boolean set = false;
boolean up = false;
boolean left = false;

void setup() {
  Serial.begin(9600);
  pinMode(xpluspin, OUTPUT);
  pinMode(xminuspin, OUTPUT);
  pinMode(ypluspin, OUTPUT);
  pinMode(yminuspin, OUTPUT);
  Serial.println("ready");
  Xval = 0;
  Yval = 0;
  
  Timer1.initialize(10000); // set a timer of length 100000 microseconds (or 0.1 sec - or 10Hz => the led will blink 5 times, 5 cycles of on-and-off, per second)
  Timer1.attachInterrupt( timerIsr ); // attach the service routine here

}

void loop() {
  // put your main code here, to run repeatedly: 
 if (stringComplete){
   stringComplete = false;
   
 for (int i = 0; i < message.length(); i++){
     if (message.charAt(i) == 'x'){
      xpos =  i+1; 
     }
     if (message.charAt(i) == 'y'){
      ypos =  i+1; 
     }
     if (message.charAt(i) == ','){
      delimiterpos =  i; 
     }
     if (message.charAt(i) == '%'){
      endpos =  i; 
     }
   }
 
 xString = message.substring(xpos, delimiterpos);
 yString = message.substring(ypos, endpos);
 Xval = 2* xString.toInt();
 Yval = 2* yString.toInt();
 set = 1;
 message = "";
 xString = "";
 yString = "";
 }
  
  

 
if(Xval == 0){
  Xstop();
}

if(Yval == 0){
  Ystop();
}

if((Xval >0 && set)||( Xval == -1 && left)){
 left = false;
 Xdec();
 set = 0;
 }

if((Xval <0 && set)||(Xval == 1 && !left)){
 left = true;
 Xinc();
 set = 0;
 }
 
if((Yval >0 && set)||(Yval == -1 && up)){
  up = false;
  Ydec();
  set = 0;
 }
 
if((Yval <0 && set)||(Yval == 1 && !up)){
  up = true;
  Yinc();
  set = 0;
 }
}

void timerIsr()
{
    if(Xval>0)
    Xval--;
    if(Xval<0)
    Xval++;
    if(Yval>0)
    Yval--;
    if(Yval<0)
    Yval++;
}

void Xinc(){
 digitalWrite(xpluspin, LOW); 
 digitalWrite(xminuspin, HIGH); 
}

void Xdec(){
 digitalWrite(xminuspin, LOW); 
 digitalWrite(xpluspin, HIGH); 
}
void Yinc(){
 digitalWrite(ypluspin, LOW); 
 digitalWrite(yminuspin, HIGH); 
}

void Ydec(){
 digitalWrite(yminuspin, LOW); 
 digitalWrite(ypluspin, HIGH); 
}

void Xstop(){
 digitalWrite(xminuspin, HIGH); 
 digitalWrite(xpluspin, HIGH);   
}

void Ystop(){
 digitalWrite(yminuspin, HIGH); 
 digitalWrite(ypluspin, HIGH);   
}


void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    inChar = (char)Serial.read();
    message += inChar;  
  if (inChar == '%') {
      stringComplete = true;
    } 
}
}
