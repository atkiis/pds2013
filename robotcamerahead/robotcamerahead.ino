const int xpluspin = 2;
const int xminuspin = 3;
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

void setup() {
  Serial.begin(9600);
  pinMode(xpluspin, OUTPUT);
  pinMode(xminuspin, OUTPUT);
  pinMode(ypluspin, OUTPUT);
  pinMode(yminuspin, OUTPUT);
  Serial.println("ready");
  Xval = 0;
  Yval = 0;
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
 Xval = xString.toInt();
 Yval = yString.toInt();
 
 message = "";
 xString = "";
 yString = "";
 }
 
if(Xval == 0){
 digitalWrite(xpluspin, HIGH); 
 digitalWrite(xminuspin, HIGH);
}

if(Yval == 0){
 digitalWrite(ypluspin, HIGH); 
 digitalWrite(yminuspin, HIGH);
}

if(Xval >0){
 digitalWrite(xminuspin, LOW); 
 digitalWrite(xpluspin, HIGH);
 Xval--;
 }

if(Xval <0){
 digitalWrite(xpluspin, LOW); 
 digitalWrite(xminuspin, HIGH);
 Xval++;
 }
 
if(Yval >0){
 digitalWrite(yminuspin, LOW); 
 digitalWrite(ypluspin, HIGH);
 Yval--;
 }
 
if(Yval <0){
 digitalWrite(ypluspin, LOW); 
 digitalWrite(yminuspin, HIGH);
 Yval++;
 }
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    inChar = (char)Serial.read();
    Serial.println(inChar);
    message += inChar;  
  if (inChar == '%') {
      stringComplete = true;
    } 
}
}
